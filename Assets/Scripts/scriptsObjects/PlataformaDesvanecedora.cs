using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDesvanecedora : MonoBehaviour
{

    [SerializeField] private float delay;
    [SerializeField] private float durability;
    private bool vanished = false;
    private bool Visible = true;
    [SerializeField] private Transform child;

    void Start()
    {
        delay = durability;
    }

    // Update is called once per frame
    void Update()
    {

        if (delay <= 0)
        {
            Toggle();
            delay = durability;
        }


        if (vanished == true)
        {
            delay -= Time.deltaTime;
        }

    }

    private void OnTriggerStay(Collider col)
    {

        if (col.gameObject.layer == Layer.Player && vanished == false)
        {
            
            delay -= Time.deltaTime;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == Layer.Player && vanished == false)
        {
            delay = durability;
        }
    }

    void Toggle()
    {
        vanished = !vanished;
        Visible = !Visible;
        child.gameObject.SetActive(Visible);
    }

    private class Layer
    {
        public const int Player = 6;
    }

}
