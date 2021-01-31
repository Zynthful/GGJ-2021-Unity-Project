using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("GameController").Length == 1)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            DestroyImmediate(gameObject);
        }
    }

    /*
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene(3);
        }
    }
    */

    public float endTime;
}
