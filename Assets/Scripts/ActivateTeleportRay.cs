using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftPrimary; //LeftPrimary Button
    public InputActionProperty rightPrimary; //RightPrimary Button


    // Update is called once per frame
    void Update()
    {
        leftTeleportation.SetActive(leftPrimary.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightPrimary.action.ReadValue<float>() > 0.1f);
    }
}
