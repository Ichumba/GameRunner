using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
  //Tomas Gomez
    void Start()
    {
        PlayerFPS.death += Level;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    private void Level()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
