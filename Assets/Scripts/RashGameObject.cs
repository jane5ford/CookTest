using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RashGameObject : MonoBehaviour
{
    public GameObject RashingObject;
    private float angleMin = 90f;
    private float angleMax = 180f;
    void Start()
    {
        print(transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.z >= angleMin && transform.eulerAngles.z < angleMax)
        {
            //GameObject rashingObject = Instantiate(RashingObject);
            //rashingObject.transform.position = gameObject.transform.position;
            //print(transform.eulerAngles.z);
            //RashingObject.transform.position = RashingObject.transform.position;
            //RashingObject.
        }
        else
        {
            //RashingObject.SetActive(false);
        }
    }
}
