using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public enum Language
{
    Spanish,
    English
}

public class Localization : MonoBehaviour
{
    [SerializeField] private string _webUrl = "https://docs.google.com/spreadsheets/d/e/2PACX-1vQ_yTJ6DGngVs9rRkD-rgp2DjYqj_HOVgzTx0YhIz7JKBaywuJtR4nSoHFVD8BvQlIWrF2qjTOu2R6R/pub?output=csv";

    [SerializeField] private Language _currentLang;

    public static Localization Instance { get; private set; }

    private Dictionary<Language, Dictionary<string, string>> _localization;
    
    public event Action OnUpdate;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(DownloadCsv(_webUrl));
    }

    public void ChangeLanguage()
    {
        _currentLang = _currentLang == Language.English ? Language.Spanish : Language.English;

        OnUpdate?.Invoke();
    }

    IEnumerator DownloadCsv(string url)
    {
        var web = new UnityWebRequest(url);

        web.downloadHandler = new DownloadHandlerBuffer();

        //www.Abort(); //Cancelar conexion para probar la carga local
        
        yield return web.SendWebRequest();

        if (web.result == UnityWebRequest.Result.Success)
        {
            var textResult = web.downloadHandler.text;

            _localization = LanguageSplit.LoadCsv(textResult, "url");
            
            SaveText(fileName: "Localization.txt", content: textResult);
        }
        else
        {
            var textResult = LoadText(fileName: "Localization.txt");
            _localization = LanguageSplit.LoadCsv(textResult, "local");
        }
        
        OnUpdate?.Invoke();
    }

    public string GetTranslate(string Id)
    {
        var idsDictionary = _localization[_currentLang];

        idsDictionary.TryGetValue(Id, out var result);

        return result;
    }

    void SaveText(string fileName, string content)
    {
        string path = Application.persistentDataPath + "/" + fileName;

        try
        {
            File.WriteAllText(path, content);
            Debug.LogWarning($"File saved successfully at: {path}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save file - {e}");
        }
    }

    string LoadText(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
        
        try
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Debug.LogWarning($"File loaded successfully from: {path}");
                return content;
            }
            else
            {
                Debug.LogWarning($"File not found at: {path}");
                return default;
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load file - {e}");
            return default;
        }
    }
}
