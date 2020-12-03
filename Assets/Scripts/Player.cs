using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public LayerMask whatCanBeClickedOn;

    public Boolean _isCanMove = true;

    private NavMeshAgent myAgent;
    
    [SerializeField] private Material _material;
    [SerializeField] private Material _stoneMaterial;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isCanMove && Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }

    public void MakeStone()
    {
        GetComponent<MeshRenderer>().material = _stoneMaterial;
    }
}
