using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BridgeTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject _bridge;
    
    [SerializeField]
    private Boolean _isOpened = false;

    [SerializeField] private NavMeshController _navMeshController;
    
    //For window with horizontal light
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _longLight;
    [SerializeField] private WindowTrigger _window;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            String triggerName;
            if (_isOpened)
            {
                triggerName = "Closing";
                if (_window != null && _window._isOpened)
                {
                    _light.SetActive(false);
                    _longLight.SetActive(true);
                }
            }
            else
            {
                triggerName = "Opening";
                if (_window != null && _window._isOpened)
                {
                    _light.SetActive(true);
                    _longLight.SetActive(false);
                }
            }

            _isOpened = !_isOpened;
            
            _bridge.GetComponent<Animator>().SetTrigger(triggerName);

            StartCoroutine(UpdateNavMeshRoutine());
        }
    }


    IEnumerator UpdateNavMeshRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        
        _navMeshController.UpdateNavMesh();
    }
    
}    
