using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    public GameObject pos;
    public GameObject anim;
    public float xRot = 90f;
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

    private void Update()
    {
        if (transform.rotation.x >= xRot)
        {
            Debug.Log("kkkkkkkkk");
            anim.SetActive(true);
            anim.transform.position = pos.transform.position;
        } else
        {
            anim.SetActive(false);
        }
    }
}
