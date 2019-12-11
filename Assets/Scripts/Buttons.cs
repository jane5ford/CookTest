using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class Buttons : MonoBehaviour
{
    public GameManager manager;

    /*void Start()
    {
        manager = GetComponent<GameManager>();
    }*/

    /*protected virtual void Awake()
    {
        Button button = GetComponent<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    protected virtual void OnButtonClick()
    {

    }*/

    public void PlayPressed()
    {
        Debug.Log("Play pressed!");
        manager.GamePlay();
    }

    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}

