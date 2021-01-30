using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int keyID = 0;
    [SerializeField]
    private Sprite image = null;

    public int GetID()
    {
        return keyID;
    }

    public Sprite getImage()
    {
        return image;
    }
}
