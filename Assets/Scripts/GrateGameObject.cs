using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GrateGameObject : MonoBehaviour
{
    public GameObject LittlePiece;
    private GameObject littlePiece;
    private GameObject gratedObject;
    private bool Gratable;
    private float pieceSize;
    void Start()
    {
        pieceSize = transform.localScale.x / 100;
        gratedObject = new GameObject();
        gratedObject.transform.position = transform.position;
        gratedObject.AddComponent<Throwable>();
        gratedObject.AddComponent<BoxCollider>();
        gratedObject.GetComponent<BoxCollider>().size = new Vector3(0.1f, 0.1f, 0.1f);
        gratedObject.transform.parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gratable && transform.localScale.x > 0)
        {
            littlePiece = GameObject.Instantiate(LittlePiece, gameObject.transform.position, Quaternion.identity) as GameObject;
            gameObject.transform.localScale = new Vector3(transform.localScale.x - pieceSize, transform.localScale.y, transform.localScale.z);
            littlePiece.transform.parent = gratedObject.transform;
        }
        if (transform.localScale.x <= 0) gameObject.SetActive(false);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Grate")
        {
            Gratable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Grate")
        {
            Gratable = false;
        }
    }
}
