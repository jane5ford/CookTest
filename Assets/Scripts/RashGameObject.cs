using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashGameObject : MonoBehaviour
{
    public GameObject RashingObject;
    public GameObject RashingObjectCopy;
    private float angleMin = 30f;
    private float angleMax = 180f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z >= angleMin && transform.eulerAngles.z < angleMax)
        {
            
            //RashingObject.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            RashingObject.SetActive(true);
            RashingObjectCopy.SetActive(false);
        }
        else
        {
            //RashingObject.SetActive(false);
        }
    }
}
