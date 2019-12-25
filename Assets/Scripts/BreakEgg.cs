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
        gameObject.GetComponent<MeshCollider>().sharedMesh = whole.GetComponent<MeshCollider>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BreakEgg")
        {
            shell.SetActive(true);
            content.SetActive(true);
            whole.SetActive(false);
        }

    }
}
