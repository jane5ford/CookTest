using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CutGameObjects : MonoBehaviour
{
    public List<GameObject> Pieces;
    private int piece;
    private bool cuted = false;
    void Start()
    {
        piece = Pieces.Count-1;
    }
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.collider.tag == "Cut" && !(cuted))
        {
            Pieces[piece].transform.position = new Vector3(Pieces[piece].transform.position.x - piece*0.02f, Pieces[piece].transform.position.y, Pieces[piece].transform.position.z);
            Pieces[piece].AddComponent<Throwable>();
            Pieces[piece].GetComponent<Rigidbody>().mass = 0.25f;
            gameObject.GetComponent<BoxCollider>().size = new Vector3(1,1,(float)1/Pieces.Count);
            Debug.Log(1 / Pieces.Count);
            cuted = true;
            if (piece > 0) { piece -= 1; }
            else
            {
                Destroy(gameObject.GetComponent<Throwable>());
                Destroy(gameObject.GetComponent<Rigidbody>());
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        cuted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Board")
        {
            gameObject.GetComponent<CutGameObjects>().enabled = true;
        }
    }
}
