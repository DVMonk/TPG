using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _platform;

    [SerializeField] private float _platformHeight = 1.6f;

    [SerializeField] private float _speed = 4.0f;
    
    [SerializeField] private NavMeshController _navMeshController;

    [SerializeField] private Boolean isCanUp = false;
    [SerializeField] private Boolean isCanDown = false;

    [SerializeField] private String _state = "down";
    [SerializeField] private float _currentHeight = 0f;

    private Player player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<Player>();
            
            if (_state.Equals("down"))
            {
                isCanUp = true;
                player._isCanMove = false;
                player.GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {
                isCanDown = true;
                player._isCanMove = false;
                player.GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }

    private void Update()
    {
        if (isCanUp)
        {
            if (_currentHeight < _platformHeight)
            {
                _platform.transform.Translate(Vector3.up * (_speed * Time.deltaTime));
                player.transform.Translate(Vector3.up * (_speed * Time.deltaTime));
                _currentHeight += _speed * Time.deltaTime;
            }
            else
            {
                isCanUp = false;
                player.GetComponent<NavMeshAgent>().enabled = true;
                player._isCanMove = true;
                _state = "up";
                _navMeshController.UpdateNavMesh();
            }
           
        }
        
        if (isCanDown)
        {
            if (_currentHeight > 0)
            {
                _platform.transform.Translate(Vector3.down * (_speed * Time.deltaTime));
                player.transform.Translate(Vector3.down * (_speed * Time.deltaTime));
                _currentHeight -= _speed * Time.deltaTime;
            }
            else
            {
                isCanDown = false;
                player.GetComponent<NavMeshAgent>().enabled = true;
                player._isCanMove = true;
                _state = "down";
                _navMeshController.UpdateNavMesh();
            }
           
        }
    }
}
