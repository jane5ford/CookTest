using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutGameObjects : MonoBehaviour
{
    public List<GameObject> Pieces;
    public int piece;
    void Start()
    {
        piece = Pieces.Count - 1;
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cut")
        {
            Pieces[piece].transform.position = new Vector3(Pieces[piece].transform.position.x - piece*0.02f, Pieces[piece].transform.position.y, Pieces[piece].transform.position.z);
            Pieces[piece].AddComponent<Rigidbody>();
            piece -= 1;
        }
        if (piece < 0)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
