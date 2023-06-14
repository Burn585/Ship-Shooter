using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveHuman : MonoBehaviour
{
    private Castle _target;
    private NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _target = FindObjectOfType<Castle>();
    }

    private void Update()
    {
        _navMesh.destination = _target.transform.position;
    }
}
