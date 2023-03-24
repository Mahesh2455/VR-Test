using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.3f;
    [SerializeField] Animator spiderAnimator;
    private void Start()
    {

    }

    private void Update()
    {
       transform.position -= transform.forward * moveSpeed * Time.deltaTime;
       spiderAnimator.SetBool("walk",true);
    }

    private void OnCollisionEnter(Collision other)
    {
       if(other.collider.CompareTag("Wall"))
       {
            moveSpeed = -moveSpeed;
       } 
    }
  
}