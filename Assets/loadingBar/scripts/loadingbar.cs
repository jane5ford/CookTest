using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    [SerializeField]
    private GameObject panTrigger;
    [SerializeField]
    private Text timerText;
    private float speed = 0.2f;
    public bool on = true;
    private int level;
    private int size;

    public GameObject panel;

    private CookedLevel cl;
    private RectTransform rectComponent;
    private Image imageComp;

    float second;
    float minute;

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
        cl = panTrigger.GetComponent<CookedLevel>();
        on = true;
        second = 00;
        minute = 2;
        InvokeRepeating("RunTimer", 1, 1);
    }

    void Update()
    {
        //if (timerText.text != "02 : 00" && timerText.text != "00 : 00") on = true;
        //else on = false;
        level = cl.getLevel();
        size = cl.getSize();
        float len = (float) 1f / size * level;
        if (on && imageComp.fillAmount < len)
        {
            if (imageComp.fillAmount != 1f)
            {
                imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            }
            else
            {
                imageComp.fillAmount = 0.0f;
            }
        }
        if (timerText.text == "00 : 00") 
        { 
            cl.turnOn(false);
            transform.parent.gameObject.SetActive(false);
            panTrigger.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            panTrigger.transform.parent.gameObject.GetComponent<MeshCollider>().convex = true;
        }
        
    }

    void RunTimer()
    {
        if (cl.isTurn() && panel.activeInHierarchy)
        {
            second--;
            if (second == -1)
            {
                second = 59;
                minute--;
            }
        } 
            timerText.text = $"{minute:00} : {second:00}";
    }
}
