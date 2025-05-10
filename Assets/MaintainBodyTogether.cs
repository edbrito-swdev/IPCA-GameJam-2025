using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainBodyTogether : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    public GameObject legs;

    public float calibrationDistance = 0.1f;
    public float separationDistanceHead = 1.4f;
    public float separationDistanceBody = 1.6f;
    public float separationDistanceLegs = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(head.transform.position.x - body.transform.position.x) > calibrationDistance)
        {
            body.transform.position = new Vector3(head.transform.position.x + calibrationDistance, body.transform.position.y, body.transform.position.z);
        }
        if (Mathf.Abs(body.transform.position.x - legs.transform.position.x) > calibrationDistance)
        {
            legs.transform.position = new Vector3(legs.transform.position.x + calibrationDistance, legs.transform.position.y, body.transform.position.z);
        }
            
        if (Mathf.Abs(head.transform.position.y - body.transform.position.y) > separationDistanceHead)
        {
            body.transform.position = new Vector3(head.transform.position.x, body.transform.position.y + separationDistanceHead, body.transform.position.z);
        }
        if (Mathf.Abs(body.transform.position.y - legs.transform.position.y) > separationDistanceBody)
        {
            legs.transform.Translate(new Vector3(legs.transform.position.x, legs.transform.position.y + separationDistanceBody, body.transform.position.z));
        }
    }
}
