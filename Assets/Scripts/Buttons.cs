using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class Buttons : MonoBehaviour
    {
        public CustomEvents.UnityEventHand onHandClick;

        protected Hand currentHand;

        //-------------------------------------------------
        protected virtual void Awake()
        {
            Button button = GetComponent<Button>();
            if (button)
            {
                button.onClick.AddListener(OnButtonClick);
            }
        }


        //-------------------------------------------------
        protected virtual void OnHandHoverBegin(Hand hand)
        {
            currentHand = hand;
            InputModule.instance.HoverBegin(gameObject);
            ControllerButtonHints.ShowButtonHint(hand, hand.uiInteractAction);
        }


        //-------------------------------------------------
        protected virtual void OnHandHoverEnd(Hand hand)
        {
            InputModule.instance.HoverEnd(gameObject);
            ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
            currentHand = null;
        }


        //-------------------------------------------------
        protected virtual void HandHoverUpdate(Hand hand)
        {
            if (hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType))
            {
                InputModule.instance.Submit(gameObject);
                ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
            }
        }


        //-------------------------------------------------
        protected virtual void OnButtonClick()
        {
            onHandClick.Invoke(currentHand);
        }
    }

}