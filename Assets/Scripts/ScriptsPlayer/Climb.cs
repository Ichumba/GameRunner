using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    /*
    public MovePj movepj;
    public Rigidbody body;
    public Transform Orientation;
    public Transform cam;

    public float BorderDetectLength;
    public float BorderDetectRadius;
    public LayerMask Border;

    public float MoveToBorderSpeed;
    public float maxGrabDistance;
    public float minTimeOnBorder;
    private float timeOnBorder;

    public bool hold;

    private Transform lastB;
    private Transform CurrB;

    private RaycastHit Borderhit;


    private void BorderDetec()
    {
        bool BorderDetec = Physics.SphereCast(transform.position, BorderDetectRadius, cam.forward, out Borderhit, BorderDetectLength, Border);
        if (!BorderDetec) return;
        float DistanceToBorder = Vector3.Distance(transform.position, Borderhit.transform.position);

        if (Borderhit.transform == lastB) return;
        
        if (DistanceToBorder < maxGrabDistance && !hold) EnterBorderHold();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BorderDetec();
        State();
    }

    void EnterBorderHold()
    {
        hold = true;
        CurrB = Borderhit.transform;
        lastB = Borderhit.transform;

        body.useGravity = false;
        body.velocity = Vector3.zero;

    }
    private void FrezzeRBonBorder()
    {
        body.useGravity = false;
        Vector3 DirToBorder = CurrB.position - transform.position;
        float DistToBorder = Vector3.Distance(transform.position, CurrB.position);
        if (DistToBorder > 1f)
        {
            if (body.velocity.magnitude < MoveToBorderSpeed)
                body.AddForce(DirToBorder.normalized * MoveToBorderSpeed *1000f * Time.deltaTime);
        }
        else
        {
            
        }
    }
    private void ExitBorderHold()
    {

    }
    private void State()
    {
        float Horizontal = Input.GetAxisRaw("horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        bool AnyKeyPress = Horizontal !=0 || Vertical !=0;

        if (hold)
        {
            FrezzeRBonBorder();
            timeOnBorder += Time.deltaTime;

            if (timeOnBorder < minTimeOnBorder && AnyKeyPress) ExitBorderHold();
        }
    }
    */








    public float grabDistance = 1.0f;
    public LayerMask edgeLayer;
    public float climbSpeed = 2.0f;
    public float jumpForce = 5.0f;
    private bool isHanging = false;
    private Vector3 edgePosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isHanging)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Subir cuando se presiona "E"
            {
                StartCoroutine(ClimbUp());
            }
            else if (Input.GetKeyDown(KeyCode.Space)) // Saltar cuando se presiona "Espacio"
            {
                JumpWhileHanging();
            }
        }
        else
        {
            CheckForEdge();
            if (Input.GetKeyDown(KeyCode.Space)) // Saltar cuando se presiona "Espacio"
            {
                Jump();
            }
        }
    }

    void CheckForEdge()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, edgeLayer))
        {
            if (hit.collider != null)
            {
                isHanging = true;
                edgePosition = hit.point;
                // Posicionar al jugador colgado en el borde
                transform.position = new Vector3(hit.point.x, hit.point.y - 1, hit.point.z);
                // Desactivar la gravedad y el movimiento del jugador
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
            }
        }
    }

    System.Collections.IEnumerator ClimbUp()
    {
        // Lógica para subir al borde
        float climbTime = 1.0f / climbSpeed;
        float elapsedTime = 0.0f;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = edgePosition + new Vector3(0, 1, 0); // Ajustar la posición final

        while (elapsedTime < climbTime)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / climbTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Restaurar el control del jugador
        transform.position = endPosition;
        isHanging = false;
        rb.useGravity = true;
    }

    void Jump()
    {
        // Lógica para saltar
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void JumpWhileHanging()
    {
        // Lógica para saltar mientras está colgado
        rb.useGravity = true; // Reactivar la gravedad
        isHanging = false; // Dejar de estar colgado
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
}






