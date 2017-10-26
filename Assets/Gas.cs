using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class Gas : MonoBehaviour
    {
        public float drift;
        private bool usingGasThrottle;
        private bool pressingGas;
        private bool turning;

        // Use this for initialization
        void Start()
        {
            usingGasThrottle = false;
            pressingGas = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (usingGasThrottle)
            {
                for (int i = 0; i < Player.instance.handCount; i++)
                {
                    Hand hand = Player.instance.GetHand(i);

                    if (hand.controller != null)
                    {
                        if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                        {
                            pressingGas = true;
                        }
                        if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                        {
                            pressingGas = false;

                        }
                        if (hand.controller.GetTouchDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                        {
                            turning = true;
                        }
                        if (hand.controller.GetTouchUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                        {
                            turning = false;
                        }
                    }
                }
            }

            if (pressingGas)
            {
                transform.parent.Rotate(0, 0, .1f * drift);

                if (GetComponentInParent<Jetski>().speed <= 5)
                {
                    GetComponentInParent<Jetski>().speed += .01f;
                }

            }
            else
            {
                GetComponentInParent<Jetski>().speed -= .01f;
            }

        }

        private void OnHandHoverBegin(Hand hand)
        {
            usingGasThrottle = true;
        }


        //-------------------------------------------------
        // Called when a Hand stops hovering over this object
        //-------------------------------------------------
        private void OnHandHoverEnd(Hand hand)
        {
            usingGasThrottle = false;

        }


    }

}

