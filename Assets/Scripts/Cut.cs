using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public GameObject whole;
    public GameObject half;
    public GameObject piece;
    public int count = 7;
    public int i = 0;
    private GameObject newPiece;
    private bool activated;
    private Vector3 oldPos;
    void Start()
    {
        oldPos = piece.transform.position;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cut" && count > 0)
        {
            if (activated)
            {
                newPiece = Instantiate(piece);
                newPiece.transform.parent = transform;
                newPiece.transform.position = oldPos;
                //half.transform.localScale = new Vector3(1f - (1f / count) * i, 1f, 1f);
                if (count == 1) half.SetActive(false); //Destroy(half.GetComponent<MeshFilter>()); 
            } else
            {
                whole.SetActive(false);
                half.SetActive(true);
                piece.SetActive(true);
                //GetComponent<BoxCollider>().enabled = false;
                //MeshCollider mesh = gameObject.AddComponent<MeshCollider>();
                //mesh.sharedMesh = half.GetComponent<Mesh>();
                //mesh.convex = true;
                activated = true;
            }
            print(count);
            print(i);
            
            count--;
            i++;
        }
    }
}
