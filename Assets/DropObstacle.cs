using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObstacle : MonoBehaviour
{
    public GameObject obstacle;
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
            Destroy(obstacle);
        }
    }
}
