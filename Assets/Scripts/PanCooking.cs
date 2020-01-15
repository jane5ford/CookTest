using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
    public int reciep; // 0 - Carbonara, 1 - Bolognese
    public bool Hot = true;
    [SerializeField]
    GameObject foodInPan;
    [SerializeField]
    Material Meat;
    [SerializeField]
    Material Tomatoes;
    [SerializeField]
    Material MeatAndTomatoes;
    [SerializeField]
    Material Noodles;
    [SerializeField]
    Material DefFood;

    const float perfect = 1f;
    const float good = 0.8f;
    const float wrong = 0.5f;

    Material NewMat;
    GameObject Carbonara;
    GameObject newForm;
    GameObject oldForm;
    GameObject pan;
    bool correct;
    float quality = 1f;
    float totalQuality = 1f;

    private GameObject obj;

    public string[] chain;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        pan = transform.parent.gameObject;
        if (reciep == 0) chain = new string[5];
        if (reciep == 1) chain = new string[5];
        reciep = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        other.transform.parent = transform.parent;
        oldForm = other.gameObject;
        switch (other.name)
        {
            case "Meat":
                NewMat = Meat;
                if (reciep == 0)
                    quality = wrong;
                else quality = perfect;
                break;
            case "TomatoPiece":
                
                NewMat = Tomatoes;
                if (reciep == 0)
                    quality = wrong;
                else quality = perfect;
                break;
            case "GarlicPiece":
                if (reciep == 0)
                    quality = wrong;
                else quality = perfect;
                break;
            case "NoodleInPan":
                NewMat = Noodles;
                if (reciep == 0)
                    quality = perfect;
                else quality = wrong;
                break;
            case "HamPieces":
                if (reciep == 0)
                    quality = perfect;
                else quality = wrong;
                break;
            default:
                quality = wrong;
                break;
        }
        if (quality == wrong) NewMat = DefFood;
        if (NewMat != null)
        {
            print("works2");
            foodInPan.SetActive(true);
            foodInPan.GetComponent<MeshRenderer>().material = NewMat;
            Destroy(oldForm);
            if (obj != null) Destroy(obj);
        }
        else obj = oldForm;
       
    }
    /*
    void ChangeForm()
    {
        newForm = Instantiate(NewForm);
        newForm.transform.parent = foodInPan.transform.parent;
        newForm.transform.position = foodInPan.transform.position;
        GameObject old = foodInPan;
        Destroy(old);
        foodInPan = newForm;
    }
    */
}
