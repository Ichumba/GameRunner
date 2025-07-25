using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    public Transform[] waypoint ;
    private int actualWaypoint = 0;


    void Update()
    {
        Andar();
    }

    private void Andar()
    {
        if (waypoint.Length <= 0) return;
        if (Vector3.Distance(transform.position, waypoint[actualWaypoint].position) <= 0.1)
        {
            actualWaypoint++;
        }

        if (actualWaypoint >= waypoint.Length)
        {
            actualWaypoint = 0;
        }

        Vector3 movement = Vector3.MoveTowards(transform.position, waypoint[actualWaypoint].position, speed * Time.deltaTime);
        transform.position = movement;
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == Layer.Player)
        {
            col.transform.parent = this.transform;

        }
    }


    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.layer == Layer.Player)
        {
            col.transform.parent = null;

        }
    }

    private class Layer
    {
        public const int Player = 6;
    }
}
