using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] public int imageNumber;

    // Update is called once per frame

    private void Start()
    {

    }
    void Update()
    {

    }
    int OnCollisionEnter2D(Collision2D colission) {
        switch (colission.gameObject.tag)
        {
            case "Finish":

                break;
            default:
                break;
        }
                return imageNumber;

    }
}
