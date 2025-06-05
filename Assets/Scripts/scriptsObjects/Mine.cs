using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    [SerializeField] private Explosion boom;
    [SerializeField] private float delay;
    [SerializeField] private AudioSource beep;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.layer == Layer.Player)
        {
            StartCoroutine(detonation());
        }
        
    }
    
    private IEnumerator detonation()
    {
        animator.SetBool("Boom",true);
        beep.Play();
        yield return new WaitForSeconds(delay);
        var explotion = ExplotionFactory.Instance.GetFromPool();
        explotion.transform.position = transform.position;
        Destroy(gameObject);
    }

}
