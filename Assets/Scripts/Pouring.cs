using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    public ParticleSystem anim;
    private float angleMin = 270f;
    private float angleMax = 360f;
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
        if (transform.eulerAngles.x >= angleMin && transform.eulerAngles.x < angleMax)
        {
            anim.Play();
        } else
        {
            anim.Stop();
        }
    }
}
