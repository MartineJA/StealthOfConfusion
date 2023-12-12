using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public int distance;
    RaycastHit hit;
    public LayerMask pentes;


    // Start is called before the first frame up
    void Update()
    {
       if(Physics.Raycast(transform.position, Vector3.down,out hit, distance, pentes))
        {
            Debug.Log("Hit");
            Debug.DrawRay(transform.position, hit.normal*distance, Color.black);
            Debug.Log(Vector3.Angle(Vector3.down, hit.normal));
            
        }
        else { Debug.Log("rien"); }
    }
}


