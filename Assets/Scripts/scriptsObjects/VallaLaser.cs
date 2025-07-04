using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VallaLaser : MonoBehaviour
{
    [SerializeField] GameObject laser;
    private bool active = false;
    [SerializeField] private AudioSource turnOn;
    [SerializeField] private AudioSource turnOff;
    [SerializeField] private float _turnOnDelay;
    [SerializeField] private float _turnOffDelay;


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
        yield return new WaitForSeconds(_turnOnDelay);
        turnOn.Play();
        laser.SetActive(true);
        yield return new WaitForSeconds(_turnOffDelay);
        turnOff.Play();
        laser.SetActive(false);
        active = false;
    }


}
