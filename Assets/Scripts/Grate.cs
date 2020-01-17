using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grate : MonoBehaviour
{
    [SerializeField]
    private GameObject whole;
    //[SerializeField]
    //private GameObject grated;
    [SerializeField]
    private GameObject Piece;
    [SerializeField]
    private GameObject newCheese;
    private float wholeScale;
    private Vector3 gratedScale;
    private Vector3 pos;
    private float step = 0.005f;
    private bool grate;
    private bool onBoard = false;
    private int i = 0;
    void Start()
    {
        wholeScale = whole.transform.localScale.x;
        gratedScale = transform.localScale;
        //grated.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (grate && onBoard && i < 100)
        {
            whole.transform.localScale = new Vector3(whole.transform.localScale.x * (1 - step), wholeScale, wholeScale);
            //float increase = 2 * Time.deltaTime;
            //grated.transform.localScale += new Vector3(increase, increase, increase);
            GameObject piece = Instantiate(Piece);
            piece.transform.position = new Vector3(pos.x + 0.03f, pos.y, pos.z);
            //piece.transform.parent = newCheese.transform;
            i++;
            //print(i);
        }
        if (whole && whole.transform.localScale.x <= wholeScale / 10) { Destroy(whole); grate = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grate" && onBoard)
        {
            grate = true;
            pos = other.transform.parent.transform.position;
            newCheese.transform.parent = transform.parent;
            newCheese.transform.position = new Vector3(pos.x + 0.03f, pos.y, pos.z);
            //GameObject piece = Instantiate(Piece);
            //piece.transform.parent = newCheese.transform;
            //newCheese.GetComponent<Rigidbody>().isKinematic = false;
            //newCheese.GetComponent<Rigidbody>().useGravity = true;
            /*if (grated.active == false)
            {
                grated.transform.parent = transform.parent;
                grated.transform.localScale = gratedScale * step;
                grated.transform.position = new Vector3(pos.x + 0.03f, 0.02f, pos.z);
                grated.SetActive(true);
            }*/

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
