using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    
    public Boolean _isOpened = true;

    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _windowDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (_isOpened)
            {
                _windowDoor.GetComponent<Animator>().SetTrigger("IsClosing");
                _isOpened = false;
                _light.GetComponent<MeshRenderer>().enabled = false;
                _light.GetComponent<Light>().IsShowing = false;
            }
            else
            {
                _windowDoor.GetComponent<Animator>().SetTrigger("IsOpening");
                _isOpened = true;
                _light.GetComponent<MeshRenderer>().enabled = true;
                _light.GetComponent<Light>().IsShowing = true;
            }
        }
    }
}
