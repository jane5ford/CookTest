using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakEgg : MonoBehaviour
{

    public GameObject whole;
    public GameObject shell;
    public GameObject content;

    void Start()
    {
        //gameObject.GetComponent<MeshCollider>().sharedMesh = whole.GetComponent<MeshCollider>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BreakEgg")
        {
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.parent.GetComponent<MeshCollider>().convex = false;
            shell.SetActive(true);
            content.SetActive(true);
            content.transform.parent = other.transform.parent;
            content.transform.position = new Vector3(content.transform.position.x - 0.05f, content.transform.position.y, content.transform.position.z);
            whole.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.name);
        if (other.tag == "BreakEgg")
        {
            print("exited"); 
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent.GetComponent<MeshCollider>().convex = true;
        }
    }

}
