using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    void Start()
    {
        PlayerFPS.death += Level;
    }


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Level()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
