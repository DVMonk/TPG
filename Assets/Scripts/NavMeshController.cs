using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    [SerializeField] private NavMeshSurface _navMesh;
    
    public void UpdateNavMesh()
    {
        _navMesh.BuildNavMesh();
    }
    
}
