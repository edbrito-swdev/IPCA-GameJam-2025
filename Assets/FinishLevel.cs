using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject finish;
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
        if (other.gameObject.CompareTag("Head") || other.gameObject.CompareTag("Torso") ||
            other.gameObject.CompareTag("Legs"))
        {
            if (!GameState.Instance.thrownHead)
                finish.SetActive(true);
        }
    }
}
