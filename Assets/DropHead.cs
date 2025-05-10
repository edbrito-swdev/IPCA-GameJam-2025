using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHead : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject head;
    public GameObject headPrefab;
    public float throwForce;
    public AudioClip throwSound;
    public AudioSource audioSource;
    
    public bool originalHead = false;
    public GameObject fullHeadMesh;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !GameState.Instance.thrownHead)
        {
            GameState.Instance.thrownHead = true;
            GetComponent<BoxCollider>().enabled = false;
            GameObject throwHead = Instantiate(headPrefab, transform.position, Quaternion.identity);
            fullHeadMesh.SetActive(false);
            Rigidbody rb = throwHead.GetComponent<Rigidbody>();
            rb.useGravity = true;
            // rb = head.AddComponent<Rigidbody>();
            // rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            if (GameState.Instance.direction >= 0)
                rb.AddForce((Vector3.up + Vector3.right) * throwForce, ForceMode.Impulse);
            else
                rb.AddForce((Vector3.up + Vector3.left) * throwForce, ForceMode.Impulse);
            audioSource.PlayOneShot(throwSound);
        }
    }
}
