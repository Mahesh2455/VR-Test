using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{

    [Range(0,1)]
    public float intensity;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable xRBaseInteractable = GetComponent<XRBaseInteractable>();
        xRBaseInteractable.activated.AddListener(TriggerHaptic);

    }

    private void TriggerHaptic(ActivateEventArgs arg0)
    {
        if(arg0.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        controller.SendHapticImpulse(intensity,duration);
    }
}
