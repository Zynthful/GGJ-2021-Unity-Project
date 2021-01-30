using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;
    [SerializeField] private GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            ReceivedInput();
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
        PausePanel.SetActive(true);
    }

    private void Unpause() 
    {
        PausePanel.SetActive(false);
    }
}
