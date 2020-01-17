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
    private int i = 0;
    private GameObject newPiece;
    private bool activated;
    private bool onBoard = false;
    private Vector3 oldPos;
    void Start()
    {
        half.SetActive(false);
        piece.SetActive(false);
        //newPiece = Instantiate(piece);
        //newPiece.transform.parent = transform.parent;
        oldPos = piece.transform.position;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (other.tag == "Board")
        {
            onBoard = true;
            //print(onBoard);
        }
        if (other.tag == "Cut" && i < count && onBoard)
        {
            if (activated)
            {
                print("2");
                newPiece = Instantiate(piece);
                newPiece.transform.parent = transform.parent;
                newPiece.transform.position = half.transform.position;
                half.transform.localScale = new Vector3(1f - (1f / count) * i, 1f, 1f);
                print("3");

            }
            else
            {
                print("1");
                whole.SetActive(false);
                half.SetActive(true);
                piece.SetActive(true);
                piece.transform.parent = transform.parent;

                activated = true;
            }
            i++;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        print(onBoard);
        if (other.tag == "Board")
        {
            onBoard = true;
            //print(onBoard);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Board")
        {
            //onBoard = false;
            print(onBoard);
        }
    }
}
