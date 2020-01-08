using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    bool filling = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (filling)
        {

        }
    }

    void isFilling(bool filling)
    {
        this.filling = filling;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pouring>())
        {
            other.GetComponent<Pouring>().enabled = true;
        }
    }
}
