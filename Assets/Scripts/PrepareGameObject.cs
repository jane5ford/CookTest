using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareGameObject : MonoBehaviour
{
    public GameObject NewForm;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Cooking")
        {
            GameObject.Instantiate(NewForm, gameObject.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        
    }
}
