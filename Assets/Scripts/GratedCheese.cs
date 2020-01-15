using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GratedCheese : MonoBehaviour
{
    [SerializeField]
    private GameObject newCheese;
    void Start()
    {
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.tag == "Piece")
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.transform.parent = newCheese.transform;
            print("piece entered");
        }*/
    }
}
