using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHandPose : MonoBehaviour
{
    //public HandData leftHandPose;
    public HandData rightHandPose;

    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    private Quaternion[] startingFingerRotations;
    private Quaternion[] finalFingerRotations;



    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(SetupPose); //On pistol selected/grabbed
        grabInteractable.selectExited.AddListener(UnSetPose);  //On pistol exited/ungrabbed
        //leftHandPose.gameObject.SetActive(false);
        rightHandPose.gameObject.SetActive(false);
    }

    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if(arg.interactorObject is XRDirectInteractor) //Check if the interactor i.e hand is a direct interactor
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>(); //Get hand data from the hands
            handData.animator.enabled = false;
            // if(handData.handType == HandData.HandType.left)
            //     SetHandDataValues(handData, leftHandPose);
            // else
                 SetHandDataValues(handData, rightHandPose);
            SendHandData(handData, finalHandPosition, finalHandRotation, finalFingerRotations); //Set new hand position, rotation taken from the right hand pose
        }
    }

    public void UnSetPose(BaseInteractionEventArgs arg) 
    {
        if (arg.interactorObject is XRDirectInteractor) //Check if the interactor i.e hand is a direct interactor
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>(); //Get hand data from the hands
            handData.animator.enabled = true;

            SendHandData(handData, startingHandPosition, startingHandRotation, startingFingerRotations); // Set hand position and rotation to default values
        }
    }
    public void SetHandDataValues(HandData h1, HandData h2)
    {
        //Store default hand position, rotation to starting hand position and rotation
        startingHandPosition = new Vector3(h1.root.localPosition.x / h1.root.localScale.x,
            h1.root.localPosition.y / h1.root.localScale.y, h1.root.localPosition.z / h1.root.localScale.z);
        finalHandPosition = new Vector3(h2.root.localPosition.x / h2.root.localScale.x,
            h2.root.localPosition.y / h2.root.localScale.y, h2.root.localPosition.z / h2.root.localScale.z);
       
        startingHandRotation = h1.root.localRotation;
        finalHandRotation = h2.root.localRotation;

        startingFingerRotations = new Quaternion[h1.fingerBones.Length];
        finalFingerRotations = new Quaternion[h1.fingerBones.Length];

            for (int i = 0; i < h1.fingerBones.Length; i++)
        {
            startingFingerRotations[i] = h1.fingerBones[i].localRotation;
            finalFingerRotations[i] = h2.fingerBones[i].localRotation;
        }
    }
    public void SendHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerBones[i].localRotation = newBonesRotation[i];
        }
    }
}
