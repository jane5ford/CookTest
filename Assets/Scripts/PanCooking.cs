using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PanCooking : MonoBehaviour
{
    public int recipe; // 0 - Carbonara, 1 - Bolognese
    public bool Hot = true;
    [SerializeField]
    GameObject foodInPan;
    [SerializeField]
    Material Meat;
    [SerializeField]
    Material Tomatoes;
    [SerializeField]
    Material Carrots;
    [SerializeField]
    Material MeatAndTomatoes;
    [SerializeField]
    Material Noodles;
    [SerializeField]
    Material DefFood;

    Material curMat;

    const float perfect = 1f;
    const float good = 0.9f;
    const float wrong = 0.5f;

    Material NewMat;
    GameObject Carbonara;
    
    GameObject pan;
    bool correct;
    float quality = 1f;
    float totalQuality = 1f;

    private GameObject obj;
    private GameObject newFood;
    private GameObject curFood;
    private CookedLevel cl;
    public string[] chain;
    private int count = 0;
    private int recCount;
    private float result;
    // Start is called before the first frame update
    void Start()
    {
        
        recipe = 1;
        if (recipe == 0) recCount = 4;
        if (recipe == 1) recCount = 5;
        cl = GetComponent<CookedLevel>();
        cl.setSize(recCount);
        pan = transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetReciep(int i) { this.recipe = i; }

    private void OnTriggerEnter(Collider other)
    {
        newFood = other.gameObject;
        switch (other.name)
        {
            case "OnionPiece":
                if (recipe == 0)
                    quality = wrong;
                else {
                    if (count == 0) quality = perfect;
                    else quality = good;
                }
                break;
            case "GarlicPiece":
                if (recipe == 0)
                    quality = wrong;
                else
                {
                    if (count == 1) quality = perfect;
                    else quality = good;
                }
                break;
            case "Meat":
                if (curMat == Tomatoes) NewMat = MeatAndTomatoes; 
                else NewMat = Meat;
                if (recipe == 0)
                    quality = wrong;
                else
                {
                    if (count == 2) quality = perfect;
                    else quality = good;
                }
                break;
            case "TomatoPiece":
                if (curMat == Meat) NewMat = MeatAndTomatoes; 
                else if (curMat != MeatAndTomatoes) NewMat = Tomatoes;
                if (recipe == 0)
                    quality = wrong;
                else
                {
                    if (count == 3) quality = perfect;
                    else quality = good;
                }
                break;
            case "CarrotPiece":
                if (recipe == 0)
                    quality = wrong;
                else
                {
                    if (count == 4) quality = perfect;
                    else quality = good;
                }
                break;

            case "NoodleInPan":
                NewMat = Noodles;
                if (recipe == 0)
                    quality = perfect;
                else quality = wrong;
                break;
            case "HamPieces":
                if (recipe == 0)
                    quality = perfect;
                else quality = wrong;
                break;
            default:
                quality = wrong;
                break;
        }
        //print(newFood.transform.parent.name);
        if (newFood != curFood && newFood.transform.parent != transform.parent)
        {
            curFood = newFood;
            curFood.transform.parent = pan.transform;
            if (quality != wrong)
            {
                count++;
                cl.setLevel(count);
                result += (100 / recCount);
            }
            result *= quality;
            print("Quality: "+result);
        }
        //print("still " + count);
        if (quality == wrong) NewMat = DefFood;
        if (NewMat != null)
        {
            foodInPan.SetActive(true);
            foodInPan.GetComponent<MeshRenderer>().material = NewMat;
            curMat = NewMat;
            Destroy(curFood);
            if (obj != null) Destroy(obj);
        }
        else obj = newFood;
    }
}
