using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDesvanecedora : MonoBehaviour
{
    // Tomas Gomez
    private Coroutine Vanished;
    [SerializeField] private float durability;
    [SerializeField] private Transform child;
    private Renderer Renderer;
    private Collider Collider;
    public bool prueba = false;

    private void Start()
    {
       // Vanished = StartCoroutine(Vanish());
        Renderer = child.GetComponent<Renderer>();
        Collider = child.GetComponent<Collider>();
    }

    void Update()
    {


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == Layer.Player)
        {
            StartCoroutine(Vanish());
            
        }
    }


   /* private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == Layer.Player)
        {
           StopCoroutine(Vanished);
            prueba = false;
        }
    }
    */
    IEnumerator Vanish()
    {
        prueba = true;
        yield return new WaitForSeconds(durability);
        StartCoroutine(Respawn());
        Renderer.enabled = false;
        Collider.enabled = false;
    }

    IEnumerator Respawn()
    {

        yield return new WaitForSeconds(durability);
        Renderer.enabled = true;
        Collider.enabled = true;
    }

    private class Layer
    {
        public const int Player = 6;
    }

}
