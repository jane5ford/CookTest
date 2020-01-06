using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareGameObject : MonoBehaviour
{
    public GameObject newForm;
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
            newForm.transform.position = gameObject.transform.position;
            newForm.SetActive(true);
            gameObject.SetActive(false);
            //GameObject.Instantiate(NewForm, gameObject.transform.position, Quaternion.identity);

        }

    }
}
