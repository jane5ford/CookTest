using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameManager))]
public class Buttons : MonoBehaviour
{
    public GameManager manager;

    protected Valve.VR.InteractionSystem.Hand currentHand;
    /*
    void Start()
    {
        manager = GetComponent<GameManager>();
    }*/

    protected virtual void Awake()
    {
        Button button = GetComponent<Button>();
        if (button)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public Valve.VR.InteractionSystem.CustomEvents.UnityEventHand onHandClick;

    protected virtual void OnHandHoverBegin(Valve.VR.InteractionSystem.Hand hand)
    {
        currentHand = hand;
        Valve.VR.InteractionSystem.InputModule.instance.HoverBegin(gameObject);
        Valve.VR.InteractionSystem.ControllerButtonHints.ShowButtonHint(hand, hand.uiInteractAction);
    }


    //-------------------------------------------------
    protected virtual void OnHandHoverEnd(Valve.VR.InteractionSystem.Hand hand)
    {
        Valve.VR.InteractionSystem.InputModule.instance.HoverEnd(gameObject);
        Valve.VR.InteractionSystem.ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
        currentHand = null;
    }


    //-------------------------------------------------
    protected virtual void HandHoverUpdate(Valve.VR.InteractionSystem.Hand hand)
    {
        /*if (hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType))
        {
            Valve.VR.InteractionSystem.InputModule.instance.Submit(gameObject);
            Valve.VR.InteractionSystem.ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
        }*/
    }

    protected virtual void OnButtonClick()
    {
        onHandClick.Invoke(currentHand);
    }

    /*public void PlayPressed()
    {
        Debug.Log("Play pressed!");
        manager.GamePlay();
    }

    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }*/
}

