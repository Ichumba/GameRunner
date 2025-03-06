using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VallaLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    private bool active = false;
    [SerializeField] private AudioSource turnOn;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == Layer.Player && active == false)
        {
            StartCoroutine(Activation());
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == Layer.Player && active == false)
        {
            StartCoroutine(Activation());
        }
    }

    private IEnumerator Activation()
    {
        active = true;
        turnOn.Play();
        yield return new WaitForSeconds(0.5f);
        laser.SetActive(true);
        yield return new WaitForSeconds(1);
        laser.SetActive(false);
        active = false;
    }

    void Update()
    {
        
    }
}
