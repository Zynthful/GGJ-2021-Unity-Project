using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
    [SerializeField] private GameObject[] PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject panel in PausePanel)
        {
            panel.SetActive(false);
        }

        Unpause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ReceivedInput();
        }

        if (paused) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (!paused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ReceivedInput() 
    {
        paused = !paused;
        if (paused) Pause();
        else Unpause();
    }

    private void Pause() 
    {
        PausePanel[0].SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    { 
        paused = false;
        Time.timeScale = 1;
        foreach (GameObject panel in PausePanel)
        {
            panel.SetActive(false);
        }
    }
}