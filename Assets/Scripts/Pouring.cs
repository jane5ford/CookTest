using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    public GameObject anim;
    private float angleMin = 60f;
    private float angleMax = 300f;

    private void Start()
    {
        anim.SetActive(false);
    }

    private void Update()
    {
        
        if (transform.rotation.eulerAngles.z >= angleMin && transform.rotation.eulerAngles.z < angleMax)
        {
            anim.SetActive(true);
            //anim.Play();
        } else
        {
            anim.SetActive(false);
            //anim.Stop();
        }
    }
}
