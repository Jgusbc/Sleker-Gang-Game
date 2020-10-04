using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            {
                LoadNextLevel();
            }
        }

         void LoadNextLevel()
        {
            SceneManager.LoadScene(1);
        }
    }
}
