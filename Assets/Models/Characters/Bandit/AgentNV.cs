using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNV : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField]
    private Transform _zoneB;
    [SerializeField]
    private Transform _zoneA;

    private Transform _destination;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        _destination = _zoneA;
        _agent.SetDestination(_destination.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ZoneA"))
        {
            
            _destination.position = _zoneB.position;
            _agent.SetDestination(_destination.position);
           
            
        }
        if (other.CompareTag("ZoneB"))
        {

            _destination.position = _zoneA.position;
            _agent.SetDestination(_destination.position);
           

        }


    }




}
