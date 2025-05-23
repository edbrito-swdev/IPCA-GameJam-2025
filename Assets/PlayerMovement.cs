using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask collisionLayers;
    public float lookahead = 0.5f;
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        DropHead dh = gameObject.GetComponent<DropHead>();
        if ((dh != null) && !dh.originalHead)
            return;
    
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            GameState.Instance.direction = 1;
        }


        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            GameState.Instance.direction = -1;
        }

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        DropHead dh = gameObject.GetComponent<DropHead>();
        if ((dh != null) && !dh.originalHead)
            return;
        // if (GameState.Instance.thrownHead && CompareTag("Head"))
        //     return;
        
        Vector3 moveDelta = movement * speed * Time.fixedDeltaTime;
        Debug.DrawRay(Vector3.right, moveDelta, Color.red);
        
        // Cast forward to check for collision before moving
        if (!IsBlocked(moveDelta))
        {
            rb.MovePosition(rb.position + moveDelta);
        }
        else
        {
            Debug.Log("Movement blocked by obstacle.");
        }
    }
    bool IsBlocked(Vector3 moveDelta)
    {
        float castDistance = moveDelta.magnitude + lookahead;
        Vector3 origin = rb.position;
        Vector3 direction = moveDelta.normalized;

        // Draw the ray for visualization
        Debug.DrawRay(origin, direction * castDistance, Color.green);

        return Physics.Raycast(origin, direction, castDistance, collisionLayers);
    }

}