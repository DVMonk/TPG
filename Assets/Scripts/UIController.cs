using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public String LevelName;

    public void RestartLevel()
    {
        SceneManager.LoadScene(LevelName);
    }

}
