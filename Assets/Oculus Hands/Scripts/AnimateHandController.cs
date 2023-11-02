using System;
using System.Collections.Generic;
using Unity.XR.Oculus;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{
    public enum Hand {
        Left,
        Right
    }

    public InputActionReference gripInputActionReference;
    public InputActionReference triggerInputActionReference;
    // public InputActionReference thumbDownInputActionReference; // For some reason, not working

    public Hand hand;

    public bool thumbEnabled = true;
    private UnityEngine.XR.InputDevice? device = null;

    private InputFeatureUsage<float> gripInput = UnityEngine.XR.CommonUsages.grip;
    private InputFeatureUsage<float> triggerInput = UnityEngine.XR.CommonUsages.trigger;
    private InputFeatureUsage<bool>[] thumbInputs = { UnityEngine.XR.CommonUsages.primary2DAxisTouch,
                                                     UnityEngine.XR.CommonUsages.primaryTouch,
                                                     UnityEngine.XR.CommonUsages.secondaryTouch,
                                                     new InputFeatureUsage<bool>("Thumbrest") };
    
    public bool useCapacitiveTrigger = true;
    private InputFeatureUsage<bool> triggerTouch = new InputFeatureUsage<bool>("IndexTouch"); // Capacitive touch override
    private float capacitiveTriggerAmount = 0.2f; // Amount to add towards the triggerValue
    private float capacitiveCurrentAmount = 0;
    private float capacitiveAnimationDuration = 0.05f;

    private Animator handAnimator;
    private float gripValue;
    private float triggerValue;
    private bool thumbDown;

    // Start is called before the first frame update
    void Start()
    {
        handAnimator = GetComponent<Animator>();
        
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(hand == Hand.Left ? XRNode.LeftHand : XRNode.RightHand, devices);

        if (devices.Count > 0)
        {
            device = devices[0];
        }

        // Check if thumb sensor is available
        if (thumbEnabled)
        {
            thumbEnabled = false;

            if (device != null)
            {
                // Check all possible sources for thumb touch
                foreach (var input in thumbInputs)
                {
                    if (device.Value.TryGetFeatureValue(input, out _))
                    {
                        thumbEnabled = true;
                        break;
                    }
                }
            }
        }

        // Check if trigger sensor is available
        if (useCapacitiveTrigger)
        {
            useCapacitiveTrigger = false;

            if (device != null)
            {
                if (device.Value.TryGetFeatureValue(triggerTouch, out _))
                {
                    useCapacitiveTrigger = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
        AnimateThumb();
    }

    private void AnimateGrip()
    {
        gripValue = 0;

        if (device == null)
        {
            gripValue = gripInputActionReference.action.ReadValue<float>();
        }
        else
        {
            float value;
            if (device.Value.TryGetFeatureValue(gripInput, out value))
            {
                gripValue = value;
            }
        }

        handAnimator.SetFloat("Grip", gripValue);
    }

    private void AnimateTrigger()
    {
        triggerValue = 0;

        if (device == null)
        {
            triggerValue = triggerInputActionReference.action.ReadValue<float>();
        }
        else
        {
            float value;
            if (device.Value.TryGetFeatureValue(triggerInput, out value))
            {
                triggerValue = value;
            }

            // If capacitive touch present, apply extra trigger amount
            if (useCapacitiveTrigger)
            {
                bool touched;
                if (device.Value.TryGetFeatureValue(triggerTouch, out touched))
                {
                    // Apply animation delay
                    float changeAmount = (touched ? 1 : -1) * Time.deltaTime / capacitiveAnimationDuration * capacitiveTriggerAmount;
                    capacitiveCurrentAmount = Math.Max(0, Math.Min(capacitiveCurrentAmount + changeAmount, capacitiveTriggerAmount));
                }
                triggerValue = triggerValue / (1 - capacitiveTriggerAmount) + capacitiveCurrentAmount;
            }
        }

        handAnimator.SetFloat("Trigger", triggerValue);
    }

    private void AnimateThumb()
    {
        if (device == null || !thumbEnabled)
        {
            thumbDown = true;
        }
        else
        {
            thumbDown = false;

            // Check all possible sources for thumb touch
            foreach (var input in thumbInputs)
            {
                bool value;
                if (device.Value.TryGetFeatureValue(input, out value) && value)
                {
                    thumbDown = true;
                    break;
                }
            }
        }
        
        // thumbDown = thumbDownInputActionReference.action.ReadValue<bool>();
        handAnimator.SetBool("ThumbDown", thumbDown);
    }
}
