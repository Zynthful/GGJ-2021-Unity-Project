using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField]
    private int lockID = 0;

    public int GetID()
    {
        return lockID;
    }

    public void Unlock()
    {
        print("Unlocked");
    }
}
