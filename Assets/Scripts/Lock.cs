using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private int lockID = 0;
    [SerializeField]
    private Transform connectedDoor = null;

    public int GetID()
    {
        return lockID;
    }

    public void Unlock()
    {
        connectedDoor.GetComponent<Door>().Unlock();
        gameObject.SetActive(false);
    }
}
