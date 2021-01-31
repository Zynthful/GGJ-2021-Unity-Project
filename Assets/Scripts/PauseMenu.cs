using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

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
        Cursor.visible = paused;

        if (paused) 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (!paused)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ReceivedInput() 
    {
        paused = !paused;
        RuntimeManager.GetBus("bus:/").setPaused(paused); // Pauses/unpauses audio
        if (paused) Pause();
        else Unpause();
    }

    private void Pause() 
    {
        PausePanel[1].SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        paused = false;
        RuntimeManager.GetBus("bus:/").setPaused(false);
        Time.timeScale = 1;
        foreach (GameObject panel in PausePanel)
        {
            panel.SetActive(false);
        }
    }
}