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

    private CookedLevel cl;
    private RectTransform rectComponent;
    private Image imageComp;

    float second;
    float minute;
    float pauseSecond;
    float pauseMinute;

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
        cl = panTrigger.GetComponent<CookedLevel>();

        second = 00;
        minute = 2;
        InvokeRepeating("RunTimer2", -1, 1);
    }

    void Update()
    {
        if (timerText.text != "02:00" && timerText.text != "00:00") on = true;
        else on = false;
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
        
    }

    void RunTimer2()
    {
        on = true;
        if (on == true)
        {
            second--;
            if (second == 00)
            {
                second = 59;
                minute--;
            }
        }

        timerText.text = $"{minute:00} : {second:00}";
        
    }
}
