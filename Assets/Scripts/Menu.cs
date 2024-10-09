using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Demo()
    {
        SceneManager.LoadScene("LvlDemo1");
    }
    public void Prototype()
    {
        SceneManager.LoadScene("Prototype");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
