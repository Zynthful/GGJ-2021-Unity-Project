using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;
    [SerializeField] private GameObject[] PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject item in PausePanel)
        {
            item.SetActive(false);
        }
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
        PausePanel[0].SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause() 
    {
        foreach (GameObject item in PausePanel)
        {
            item.SetActive(false);
        }

        PausePanel[0].SetActive(false);
        Time.timeScale = 1;
    }
}
