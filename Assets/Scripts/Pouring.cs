using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    [SerializeField]
    private GameObject anim;
    private float angleMin = 60f;
    private float angleMax = 300f;
    public bool tilted = false;
    private void Start()
    {
        anim.SetActive(false);
    }

    private void Update()
    {
        
        if (transform.rotation.eulerAngles.z >= angleMin && transform.rotation.eulerAngles.z < angleMax)
        {
            print("works");
            anim.SetActive(true);
            tilted = true;
            //anim.Play();
        } else
        {
            anim.SetActive(false);
            tilted = false;
            //anim.Stop();
        }
    }

    private void OnDisable()
    {
        anim.SetActive(false);
        //anim.Stop();
        tilted = false;
    }


}

