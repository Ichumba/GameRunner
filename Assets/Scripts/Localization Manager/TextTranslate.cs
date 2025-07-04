using TMPro;
using UnityEngine;

public class TextTranslate : MonoBehaviour
{
    [SerializeField] private string _id;

    private Localization _localization;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        
       
    }

    private void Start()
    {
        _localization = Localization.Instance;
        _localization.OnUpdate += ChangeLang;
    }

    void ChangeLang()
    {
        _text.text = _localization.GetTranslate(_id);
    }
    
    private void OnDestroy()
    {
        _localization.OnUpdate -= ChangeLang;
    }
}
