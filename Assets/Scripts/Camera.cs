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

            if (hitInfo.transform.GetComponent<Key>())
            {
                hitInfo.transform.gameObject.SetActive(false);
                whereTheKeyCyclerIs.GetComponent<KeyCycler>().AddKey(hitInfo.transform);
            }
        }
    }
}
