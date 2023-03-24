using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollow : MonoBehaviour
{

    public Transform visualTarget;
    private Vector3 initalLocalPos;
    public Vector3 localAxis;
    private XRBaseInteractable interactable;
    private bool isFollowing = false;
    private bool freeze = false;
    private Vector3 offSet;
    private Transform pokeAttachTF;
    // Start is called before the first frame update
    void Start()
    {
        initalLocalPos = visualTarget.position;
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
    }

    private void Reset(HoverExitEventArgs arg)
    {
        if(arg.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    private void Freeze(SelectEnterEventArgs arg)
    {
        if(arg.interactorObject is XRPokeInteractor)
        {
            freeze = true;
        }
    }

    private void Follow(HoverEnterEventArgs arg)
    {
        if(arg.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)arg.interactorObject;
            isFollowing = true;
            freeze = false;
            pokeAttachTF = interactor.attachTransform;
            offSet = visualTarget.position - pokeAttachTF.position;
        }
    }

    private void Update()
    {
        if(freeze)
            return;
        if(isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTF.position+offSet);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition,localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition,initalLocalPos,5 * Time.deltaTime);
        }
    }
    
}
