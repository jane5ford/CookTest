using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour
{
    public GameObject content;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "WaterDrop")
        {
            if (content.transform.localScale != new Vector3(1f , 1f, 1f))
            {
                content.transform.localScale *= 1.1f;
            }
        }
    }
}