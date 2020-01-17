using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sausePan : MonoBehaviour
{
    public GameObject noodle;
    public GameObject wrongFood;
    private GameObject NewForm;
    [SerializeField]
    private GameObject newForm;
    [SerializeField]
    private GameObject steam;
    private CookedLevel cl;
    float defaultScale;
    float defaultScale2;
    bool isFirst = true;
    GameObject food;
    private int time = 1;
    void Start()
    {
        cl = GetComponent<CookedLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (food != null)
        {
            if (isFirst) defaultScale = food.transform.localScale.x;
            
            if (food.name == "pastaNoodle")
            {
                if (isFirst) NewForm = noodle;
                float decrease = (defaultScale / 100) * Time.deltaTime;
                food.transform.localScale -= new Vector3(decrease, decrease, decrease);
                if (food.transform.localScale.x < defaultScale * 0.8)
                {
                    Destroy(food);
                    transform.parent.GetComponent<MeshCollider>().convex = true;
                    transform.parent.GetComponent<Rigidbody>().isKinematic = false;
                    GetComponent<CookedLevel>().turnOn(false);
                    steam.SetActive(false);
                }               
                
            }
            else
            {
                if (isFirst) NewForm = wrongFood;
                food.SetActive(false);
                /*
                float decrease = (defaultScale / 10) * Time.deltaTime;
                food.transform.localScale -= new Vector3(decrease, decrease, decrease);
                if (food.transform.localScale.x < defaultScale * 0.1)
                {
                    Destroy(food);
                }
                */
            }

            if (NewForm != null && isFirst)
            {
                print("works");
                //newForm = GameObject.Instantiate(NewForm, gameObject.transform.position, Quaternion.identity);
                newForm.SetActive(true);
                //newForm.transform.parent = gameObject.transform.parent;
                NewForm = null;
                defaultScale2 = newForm.transform.localScale.z;
                newForm.transform.localScale = new Vector3(defaultScale2 / 10, defaultScale2 / 10, defaultScale2 / 10);
                isFirst = false;
            }
            if (newForm != null && newForm.transform.localScale.z < defaultScale2)
            {
                float increase = (defaultScale2 / 20) * Time.deltaTime;
                newForm.transform.localScale += new Vector3(increase, increase / 2, increase);
                cl.setSize((int)defaultScale2);
                cl.setLevel((int)newForm.transform.localScale.x);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ForPan")
        {
            food = other.gameObject;
        }
    }
}
