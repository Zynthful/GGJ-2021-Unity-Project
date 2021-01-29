using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int keyID = 0;
    [SerializeField]
    private Sprite image = null;

    private int GetID()
    {
        return keyID;
    }

    private Sprite getImage()
    {
        return image;
    }
}
