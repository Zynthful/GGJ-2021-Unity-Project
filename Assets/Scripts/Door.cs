using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float swingForce = 1;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
    }

    public void Unlock()
    {
        GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;

        GetComponent<Rigidbody>().AddTorque(transform.up * swingForce, ForceMode.VelocityChange);
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
