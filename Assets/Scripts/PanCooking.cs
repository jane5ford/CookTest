using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
    public bool Hot = true;
    [SerializeField]
    GameObject food;
    [SerializeField]
    GameObject Meat;
    [SerializeField]
    GameObject Tomatoes;
    [SerializeField]
    GameObject Noodles;
    [SerializeField]
    GameObject Ham;
    [SerializeField]
    GameObject WrongFood;

    GameObject NewForm;
    GameObject newForm;
    // Start is called before the first frame update
    void Start()
    {
        newForm.transform.parent = transform.parent;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform.parent;
        if (other.tag == "ForPan")
        {
            switch (other.name)
            {
                case "Meat":
                    NewForm = Meat;
                    break;
                case "TomatoPiece":
                    NewForm = Tomatoes;
                    break;
                case "NoodleInPan":
                    NewForm = Noodles;
                    break;
                case "HamPieces":
                    NewForm = Ham;
                    break;
                default:
                    NewForm = WrongFood;
                    break;
            }
            newForm = Instantiate(NewForm);
            newForm.transform.position = other.transform.position;
        }
        else
        {

        }
    }

}
