using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private int keyID = 0;
    [SerializeField]
    private Color colour = Color.red;


    private void Start()
    {
        GetComponent<MeshRenderer>().materials[1].color = colour;
    }


    public int GetID()
    {
        return keyID;
    }

    public Color getColour()
    {
        return colour;
    }
}
