using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling : MonoBehaviour
{
    public GameObject content;
    private bool isPouring;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (content.transform.localScale.x >= 0.1f && content.transform.localScale.x < 0.9f && isPouring)
        {
            float increase = 0.1f * Time.deltaTime;
            content.transform.localScale += new Vector3(increase, increase, increase);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Filling")
        {
            isPouring = true;
            if (content.transform.localScale.x == 0)
            {
                content.SetActive(true); 
                content.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
        
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Filling")
        {
            //isPouring = false;
        }
    }
}