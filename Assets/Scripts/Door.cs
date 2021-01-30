using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float swingForce = 1;

    public void Unlock()
    {
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;

        GetComponent<Rigidbody>().AddTorque(transform.up * swingForce, ForceMode.VelocityChange);
    }
}
