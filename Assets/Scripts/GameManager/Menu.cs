using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Tomas Gomez
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
