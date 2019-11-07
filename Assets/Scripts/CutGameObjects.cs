using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutGameObjects : MonoBehaviour
{
    public List<GameObject> Pieces;
    private int piece = 100;
    void Start()
    {
        piece = Pieces.Count-1;
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
            Pieces[piece].GetComponent<Rigidbody>().mass = 0.25f;
            if (piece > -1) piece -= 1;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Board")
        {
            gameObject.GetComponent<CutGameObjects>().enabled = true;
        }
    }
}
