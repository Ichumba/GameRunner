using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Tomas Gomez

    public int damage;
    [SerializeField] private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private  void OnTriggerEnter(Collider col)
    {
        IDamage damages = col.GetComponent<IDamage>();

        if (damages!=null)
        {
            damages.TakeDamage(damage);
            BulletFactory.Instance.ReturnToPool(this);
        }
        else
        {
            BulletFactory.Instance.ReturnToPool(this);
        }

    }

    public static void TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Quaternion rotation = Quaternion.Euler(0f, rb.rotation.y, 0f);
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * (Vector3)(rotation * transform.up));
    }

    private class Layer
    {
        public const int Player = 6;
        public const int Pared = 8;
    }


}
