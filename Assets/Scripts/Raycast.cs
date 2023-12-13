using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Raycast : MonoBehaviour
{
    public int distance;
    RaycastHit hit;
    RaycastHit stair;
    public LayerMask pentes;
    public LayerMask stairs;

    public Transform[] stepDetector;
    public Transform upDetection;


    // Start is called before the first frame up
    void Update()
    {
       if(Physics.Raycast(transform.position, Vector3.down,out hit, distance, pentes))
        {
            //Debug.Log("Hit");
            Debug.DrawRay(transform.position, hit.normal*distance, Color.black);
            Debug.Log(Vector3.Angle(Vector3.down, hit.normal));
            
        }
        else { /*Debug.Log("rien"); */}

       for (int i = 0; i < stepDetector.Length; i++) { 
        if (Physics.Raycast(stepDetector[i].position, Vector3.forward, out stair, distance, stairs))
        {
            Debug.Log("Escalier en vue");
            Debug.DrawRay(stepDetector[i].position, stair.normal * distance, Color.black);
            
        }
        }
    }
}


