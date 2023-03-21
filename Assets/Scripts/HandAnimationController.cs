using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationController : MonoBehaviour
{
    [SerializeField] private InputActionProperty _pinchAnimationAction;
    [SerializeField] private InputActionProperty _gripAnimationAction;
    private Animator _handAnimator;
    float triggerValue;
    // Start is called before the first frame update
    void Start()
    {
        _pinchAnimationAction.action.performed += PinchHand;
        _gripAnimationAction.action.performed += GripHand;
        _handAnimator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void OnDisable()
    {
        _pinchAnimationAction.action.performed -= PinchHand;
        _gripAnimationAction.action.performed -= GripHand;
    }

    private void PinchHand(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripHand(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

}
