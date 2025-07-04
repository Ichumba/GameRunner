using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDebugger : MonoBehaviour
{
    //[SerializeField] private GameplayScreen _miniGameplay;

    [SerializeField] private SimpleUiScreen _pauseScreen;
    
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) //Instanciar minijuegos como el de la cerradura en skyrim
        {
            ScreenManager.Instance.Push(Instantiate(_miniGameplay));
        }*/
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pausa");
            ScreenManager.Instance.Push(_pauseScreen);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0f;  
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
        }
    }
}
