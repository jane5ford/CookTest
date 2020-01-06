using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sausePan : MonoBehaviour
{
    public GameObject noodle;
    public GameObject wrongFood;
    private GameObject NewForm;
    private GameObject newForm;
    //string name;
    float defaultScale;
    float defaultScale2;
    bool isFirst = true;
    GameObject food;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (food != null)
        {
            if (isFirst) defaultScale = food.transform.localScale.x;
            
            if (food.name == "pastaNoodle")
            {
                if (isFirst)
                {
                    defaultScale = food.transform.localScale.x;

                }
                if (isFirst) NewForm = noodle;
                float decrease = (defaultScale / 100) * Time.deltaTime;
                food.transform.localScale -= new Vector3(decrease, decrease, decrease);
                if (food.transform.localScale.x < defaultScale * 0.8)
                {
                    Destroy(food);
                }
            }
            else
            {       
                    
            }

            if (NewForm != null && isFirst)
            {
                newForm = GameObject.Instantiate(NewForm, gameObject.transform.position, Quaternion.identity);
                newForm.transform.parent = gameObject.transform.parent;
                NewForm = null;
                defaultScale2 = newForm.transform.localScale.z;
                newForm.transform.localScale = new Vector3(defaultScale2 / 10, defaultScale2 / 10, defaultScale2 / 10);
                isFirst = false;
            }
            if (newForm.transform.localScale.z < defaultScale2)
            {
                float increase = (defaultScale2 / 20) * Time.deltaTime;
                newForm.transform.localScale += new Vector3(increase, increase / 2, increase);
            }
        }

        

        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //name = other.name;
        food = other.gameObject;
        
        //print(defaultScale);
        
    }
}
