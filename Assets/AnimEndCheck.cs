using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimEndCheck : MonoBehaviour
{
    public bool animationEnd;
    void Update()
    {
        if(animationEnd)
        {
            // Unlock cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }
}
