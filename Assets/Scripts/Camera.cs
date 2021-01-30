﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform whereTheKeyCyclerIs;
    [SerializeField]
    private float sensitivity = 1;

    private float xMove;
    private float yMove;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.None){Cursor.lockState = CursorLockMode.Locked;}
            else{Cursor.lockState = CursorLockMode.None;}
        }
    }

    void FixedUpdate()
    {
        xMove -= Input.GetAxis("Mouse Y") * sensitivity;
        yMove += Input.GetAxis("Mouse X") * sensitivity;

        transform.rotation = Quaternion.Euler(xMove, yMove, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.GetComponent<Flip>())
            {
                hitInfo.transform.GetComponent<Flip>().DoAFlip();
            }

            else if (hitInfo.transform.GetComponent<Key>())
            {
                hitInfo.transform.gameObject.SetActive(false);
                whereTheKeyCyclerIs.GetComponent<KeyCycler>().AddKey(hitInfo.transform);
            }

            else if (hitInfo.transform.GetComponent<Lock>())
            {
                Transform currentKey = whereTheKeyCyclerIs.GetComponent<KeyCycler>().GetEquippedKey();

                if (currentKey.GetComponent<Key>().GetID() == hitInfo.transform.GetComponent<Lock>().GetID())
                {
                    hitInfo.transform.GetComponent<Lock>().Unlock();
                }
            }
        }
    }
}
