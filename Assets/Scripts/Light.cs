using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Light : MonoBehaviour
{

    public Boolean IsShowing = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && IsShowing)
        {
            var player = other.GetComponent<Player>();
            player.MakeStone();
            player.GetComponent<NavMeshAgent>().isStopped = true;
            player._isCanMove = false;
        }
    }
}
