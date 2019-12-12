using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    public ParticleSystem anim;
    private float angleMin = 30f;
    private float angleMax = 180f;
    /*private bool rotatable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ForPouring"))
        {
            Debug.Log("hhhhh");
            rotatable = true;
            Quaternion rotY = Quaternion.AngleAxis(1, Vector3.up);
            transform.rotation *= rotY;
            
        }
    }*/

    private void Start()
    {
        //anim.Stop();
    }

    private void Update()
    {
        if (transform.eulerAngles.z >= angleMin && transform.eulerAngles.z < angleMax)
        {
            anim.Play();
        } else
        {
            //anim.Stop();
        }
    }
}
