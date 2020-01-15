using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grate : MonoBehaviour
{
    [SerializeField]
    private GameObject whole;
    [SerializeField]
    private GameObject grated;
    private float wholeScale;
    private Vector3 gratedScale;
    private float step = 0.005f;
    private bool grate;
    private bool onBoard = false;
    void Start()
    {
        wholeScale = whole.transform.localScale.x;
        gratedScale = transform.localScale;
        grated.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (grate && onBoard)
        {
            whole.transform.localScale = new Vector3(whole.transform.localScale.x * (1 - step), wholeScale, wholeScale);
            float increase = 2 * Time.deltaTime;
            grated.transform.localScale += new Vector3(increase, increase, increase);
        }
        if (whole && whole.transform.localScale.x <= wholeScale / 10) { Destroy(whole); grate = false; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Grate")
        {
            print("col");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grate" && onBoard)
        {
            print("trig");
            grate = true;
            if (grated.active == false)
            {
                grated.transform.parent = transform.parent;
                grated.transform.localScale = gratedScale * step;
                grated.SetActive(true);
            }
        }
        if (other.tag == "Board")
        {
            onBoard = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Grate")
        {
            grate = false;
        }
        if (collision.collider.tag == "Board")
        {
            onBoard = false;
        }
    }
}
