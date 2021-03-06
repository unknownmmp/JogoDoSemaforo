﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void LoadScene(string scene)
    {
        Debug.Log("Loading scene: " + scene);
        SceneManager.LoadScene(scene);
    }

    private void OnApplicationPause()
    {
        PlayerPrefs.DeleteAll();
    }
}
