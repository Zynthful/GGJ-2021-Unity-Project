using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private int lockID = 0;
    [SerializeField]
    private Transform connectedDoor = null;
    [SerializeField]
    private Color colour = Color.red;


    private void Start()
    {
        GetComponent<MeshRenderer>().materials[0].color = colour;
    }

    public int GetID()
    {
        return lockID;
    }

    public void Unlock()
    {
        connectedDoor.GetComponent<Door>().Unlock();

        for (int i = 0; i < 2; i++)
        {
            transform.parent.GetChild(0).gameObject.AddComponent<Rigidbody>();
            transform.parent.GetChild(0).parent = null;
        }
    }
}
