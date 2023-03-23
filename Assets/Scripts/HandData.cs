using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandData : MonoBehaviour
{

    public enum HandType
    {
        left,
        right
    }
    public HandType handType;
    public Transform root;
    public Animator animator;
    public Transform[] fingerBones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
