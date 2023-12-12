using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 direction = new Vector3();
    Rigidbody rGB;
    Transform camTransform;
    Animator animator;

    public float speed = 5f;
    public float jumpHeight = 20f;
    public int jumpCount;
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
    }

    // Update is called once per frame
    void Update()
    {
        direction = ((camTransform.forward * Input.GetAxis("Vertical")) + (camTransform.forward * Input.GetAxis("Horizontal"))) * speed;
        
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
            animator.SetTrigger("Sneak");
            speed /= 2;
    
        }







    }


}
