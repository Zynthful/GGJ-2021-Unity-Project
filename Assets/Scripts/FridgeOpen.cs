using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FridgeOpen : MonoBehaviour
{
    private bool openDoor = false;
    [SerializeField]
    private int maxAngle = 50;
    [SerializeField]
    private float speed = -1;


    void Update()
    {
        if (openDoor)
        {
            transform.Rotate(Vector3.up * speed);

            if (transform.rotation.eulerAngles.y < maxAngle)
            {
                SceneManager.LoadScene(3);
            }
        }      
    }


    public void Open()
    {
        openDoor = true;
    }
}
