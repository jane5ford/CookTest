using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBottom : MonoBehaviour
{
    [SerializeField]
    private GameObject eggs;
    void Start()
    {
        eggs.SetActive(false);
        eggs.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (eggs && eggs.transform.localScale.x >= 0f && eggs.transform.localScale.x < 0.9f)
        {
            print("eggIncrease");
            float increase = 0.11f * Time.deltaTime;
            eggs.transform.localScale += new Vector3(increase, increase, increase);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Egg_inside")
        {
            other.gameObject.SetActive(false);
            eggs.SetActive(true);
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.parent.GetComponent<MeshCollider>().convex = true;
        }
    }
}
