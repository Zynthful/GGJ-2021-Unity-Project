using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool startFlip;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float turnSpeed = 5;
    private bool flipping;
    [SerializeField]
    private float spinTime = 2;
    private float timer;


    private void FixedUpdate()
    {
        if (startFlip)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.VelocityChange);

            flipping = true;
            timer = spinTime;
            startFlip = false;
        }

        if (flipping)
        {
            transform.Rotate(Vector3.right * turnSpeed);

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                flipping = false;
            }
        }
    }


    public void DoAFlip()
    {
        startFlip = true;
    }
}
