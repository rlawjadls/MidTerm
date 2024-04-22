using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    private Vector3 movement = Vector3.zero;
    private Rigidbody rigid;
    private Animator animator;
    public float turnSpeed = 20;
    private Quaternion rotation = Quaternion.identity;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
     
        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();
       
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
     
        bool isWalking = hasHorizontalInput || hasVerticalInput;
 
        animator.SetBool("isWalk", isWalking);
     
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0f);
  
        rotation = Quaternion.LookRotation(desiredForward);
     
    }

    private void OnAnimatorMove()
    {
        rigid.MovePosition(rigid.position + movement * animator.deltaPosition.magnitude);
        rigid.MoveRotation(rotation);
       
    }
}