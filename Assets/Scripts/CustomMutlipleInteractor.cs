using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomMutlipleInteractor : XRBaseInteractable
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        
    }

    private bool hasMultipleInteractors()
    {
        return interactorsSelecting.Count > 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
