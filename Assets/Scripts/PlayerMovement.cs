using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum PlayerMove
        {
            IDLE,
            WALK,
            RUN        
        }
    private PlayerMove currentMove;

    Vector3 direction = new Vector3();
    Rigidbody rGB;
    Transform camTransform;
    Animator animator;

    public float speed = 5f;
    public float jumpHeight = 20f;

    public LayerMask jumpMask;

    private void Awake()
    {
        rGB = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }



    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        TransitionToState(PlayerMove.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        direction = ((camTransform.forward * Input.GetAxis("Vertical")) + (camTransform.right * Input.GetAxis("Horizontal"))) * speed;
        
    }

    private void FixedUpdate()

        
    {   direction.y = rGB.velocity.y;
        rGB.velocity = direction;

        if (direction.magnitude > 0 )
        {
            Vector3 lookDirection = camTransform.forward;
            lookDirection.y = 0;
            Quaternion rotation = Quaternion.LookRotation( lookDirection ); 
            rotation = Quaternion.RotateTowards(rGB.rotation, rotation, speed);
            rGB.rotation = rotation;

        }

        if (Input.GetButton("Jump"))
        {
            rGB.AddForce(transform.up * jumpHeight);
        }

        if (Input.GetButton("Fire2")) //left ALT
        {
            Debug.Log("Crouch");
            //animator.SetBool("Sneak", true);
            animator.SetBool("iSneaking", true);
            speed /= 2;
    
        }

    }

    private void OnStateEnter()
    {
        switch(currentMove) 
        
        {
            case PlayerMove.IDLE:{ break; }
            case PlayerMove.WALK: { break; }
            case PlayerMove.RUN: { break; }
        }
    }
    private void OnStateUpdate()
    {
        switch (currentMove)

        {
            case PlayerMove.IDLE: { break; }
            case PlayerMove.WALK: { break; }
            case PlayerMove.RUN: { break; }
        }
    }
    private void OnStateExit()
    {
        switch (currentMove)

        {
            case PlayerMove.IDLE: { break; }
            case PlayerMove.WALK: { break; }
            case PlayerMove.RUN: { break; }
        }
    }

    private void TransitionToState(PlayerMove ToState)
    {
        OnStateExit();  
        currentMove = ToState;
        OnStateEnter();
    }


}
