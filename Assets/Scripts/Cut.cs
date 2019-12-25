using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cut : MonoBehaviour
{
    public GameObject whole;
    public GameObject half;
    public GameObject piece;
    public int count = 7;
    public int i = 0;
    private GameObject newPiece;
    private bool activated;
    private bool onBoard = false;
    private Vector3 oldPos;
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cut" && i < count && onBoard)
        {
            if (activated)
            {
                newPiece = Instantiate(piece);
                newPiece.transform.parent = transform;
                newPiece.transform.position = oldPos;
                half.transform.localScale = new Vector3(1f - (1f / count) * i, 1f, 1f);
            }
            else
            {
                whole.SetActive(false);
                half.SetActive(true);
                piece.SetActive(true);
                activated = true;
            }
            i++;
        }
        if (i == count)
        {
            //for(int k = 2; k <= count; k++) Destroy(gameObject.transform.GetChild(k).GetComponent<Rigidbody>()); //gameObject.transform.GetChild(k).GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Board")
        {
            onBoard = true;
            oldPos = piece.transform.position;
            print(onBoard);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Board")
        {
            onBoard = false;
            print(onBoard);
        }
    }
}
