using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private int lockID = 0;
    [SerializeField]
    private Transform connectedDoor = null;
    [SerializeField]
    private Color colour = Color.red;
    [SerializeField]
    private bool fridgeLock = false;


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
        if (fridgeLock)
        {
            transform.parent.parent.GetChild(1).gameObject.AddComponent<Rigidbody>();
            transform.parent.parent.GetChild(2).GetComponent<FridgeOpen>().Open();
        }

        else
        {
            connectedDoor.GetComponent<Door>().Unlock();            
        }

        for (int i = 0; i < 2; i++)
        {
            transform.parent.GetChild(0).gameObject.AddComponent<Rigidbody>();
            transform.parent.GetChild(0).parent = null;
        }
    }
}
