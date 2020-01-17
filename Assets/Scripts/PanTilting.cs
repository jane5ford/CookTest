using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanTilting : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pan")
        {
            other.transform.rotation = 
        }
    }
}
