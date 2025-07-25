using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void MMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   
    public void Demo()
    {
        SceneManager.LoadScene("LvlDemo1");
    }
    public void Prototype()
    {
        SceneManager.LoadScene("NewPrototype");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
