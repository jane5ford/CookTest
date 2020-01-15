using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour
{
    public GameObject cream;
    private Pouring pouring;
    void Start()
    {
        cream.transform.localScale = Vector3.zero;
        cream.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pouring)
        {
            if (pouring.tilted && cream.transform.localScale.x >= 0f && cream.transform.localScale.x < 0.9f)
            {
                float increase = 0.1f * Time.deltaTime;
                cream.transform.localScale += new Vector3(increase, increase, increase);
            }
            if (cream.transform.localScale.x > 0.9f)
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
            cream.SetActive(true);
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