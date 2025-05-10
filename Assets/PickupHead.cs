using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHead : MonoBehaviour
{
    public GameObject originalHeadRenderer;
    public BoxCollider originalHeadCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            originalHeadRenderer.SetActive(true);
            originalHeadCollider.enabled = true;
            GameState.Instance.thrownHead = false;
            Destroy(other.gameObject);
        }
    }
}
