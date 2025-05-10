using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHead : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject head;
    public float throwForce;
    private Rigidbody rb;
    void Start()
    {
        rb = head.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameState.Instance.thrownHead)
        {
            GameState.Instance.thrownHead = true;
            rb.useGravity = true;
            // rb = head.AddComponent<Rigidbody>();
            // rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            rb.AddForce((Vector3.up + Vector3.right) * throwForce, ForceMode.Impulse);
        }
    }
}
