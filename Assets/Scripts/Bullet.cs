using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bullet : MonoBehaviour
{
    public PlayerFPS PJ;
    public int damage;
    [SerializeField] private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private  void OnTriggerEnter(Collider col)
    {
        //Por alguna razon al colisionar al player no detecta la ref a su clase apesar que en el codigo no salta ningun error
        if (col.gameObject.layer == Layer.Player)
        {
            print("Direct impact");
            PJ.TakeDamage (damage);
            Destroy(gameObject);
        }
        else
        if (col.gameObject.layer == Layer.Pared)
        {
            Destroy(gameObject);
        }

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
