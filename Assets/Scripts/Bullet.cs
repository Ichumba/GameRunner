using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bullet : MonoBehaviour
{
    public PlayerFPS Jugador;
    public float damage;
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

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.layer == Layer.Player)
        {
            Jugador._life -= damage;
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
        public const int Obstacle = 7;
        public const int Misile = 11;
    }


}
