using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

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

    // FMOD
    [EventRef] private string eFlip = "{61f53cd3-f8ed-4854-858f-c1ddff981a42}";


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

        // FMOD: Create instance of event, set size and play sound
        EventInstance iFlip = RuntimeManager.CreateInstance(eFlip);
        iFlip.setParameterByName("objectSize", GetComponent<Collider>().bounds.size.magnitude);
        iFlip.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        iFlip.start();
        iFlip.release();
    }
}
