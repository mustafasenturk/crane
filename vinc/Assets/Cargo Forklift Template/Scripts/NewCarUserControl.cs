using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (NewCarController))]
public class NewCarUserControl : MonoBehaviour
    {
        private NewCarController m_Car; // the car controller we want to use

    private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<NewCarController>();
        }


        private void FixedUpdate()
        {
        // pass the input to the car!
        float h = 0f;
        float v = 0f;
        float handbrake = 0f;

#if !MOBILE_INPUT
             h = Input.GetAxis("Horizontal");
                v = Input.GetAxis("Vertical");
        handbrake = Input.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            
#else
        h = CrossPlatformInputManager.GetAxis("Horizontal");
        v = CrossPlatformInputManager.GetAxis("Vertical");
        m_Car.Move(h, v, v, 0f);
#endif
        }
    }

