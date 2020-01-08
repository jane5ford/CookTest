using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour
{
    public GameObject content;
    private Pouring pouring;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pouring)
        {
            if (pouring.tilted && content.transform.localScale.x >= 0f && content.transform.localScale.x < 0.9f)
            {
                float increase = 0.1f * Time.deltaTime;
                content.transform.localScale += new Vector3(increase, increase, increase);
            }
            if (content.transform.localScale.x > 0.9f)
            {
                pouring.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pouring>())
        {
            pouring = other.GetComponent<Pouring>();
            pouring.enabled = true;
            
        }
    }
 
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Pouring>())
        {
            pouring = other.GetComponent<Pouring>();
            pouring.enabled = false;
        }
    }
}