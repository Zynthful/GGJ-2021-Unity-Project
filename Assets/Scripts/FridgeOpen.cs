﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FridgeOpen : MonoBehaviour
{
    private bool openDoor = false;
    [SerializeField]
    private int maxAngle = 50;
    [SerializeField]
    private float speed = -1;

    [SerializeField] GameObject endAnim;
    [SerializeField] GameObject oldFridge;


    void Update()
    {
        if (openDoor)
        {
            transform.Rotate(Vector3.up * speed);

            if (transform.rotation.eulerAngles.y < maxAngle)
            {
                GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
                oldFridge.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").SetActive(false);
                endAnim.SetActive(true);
                DestroyImmediate(this);
            }
        }      
    }


    public void Open()
    {
        openDoor = true;
    }
}
