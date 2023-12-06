using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 direction = new Vector3();
    Rigidbody rGB;

    Transform camTransform;

    public float speed = 5f; 

    private void Awake()
    {
        rGB = GetComponent<Rigidbody>();
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

        // revoir cette ligne 
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
    }
}
