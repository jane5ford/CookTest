using UnityEngine.UI;
using UnityEngine;

public class TimeBar : MonoBehaviour
{

    public Image bar;
    public float fill;

    void Start()
    {
        fill = 1f;
    }


    void Update()
    {
        fill -= Time.deltaTime * 0.1f;
        bar.fillAmount = fill;
    }
}
