using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCycler : MonoBehaviour
{
    // Key info
    [SerializeField] private List<Transform> keys;

    // UI
    [SerializeField] [Tooltip("Assign this to the parent of the Key Preview Images")]
    private Transform keyPreviewsParent;
    private Image[] keyPreviews;

    // Inputs
    [SerializeField] [Tooltip("Key used to cycle through each key")]
    private KeyCode cycleKey = KeyCode.Q;

    private void Start()
    {
        // Initialise array
        keyPreviews = new Image[keyPreviewsParent.transform.childCount];

        // Get keyPreviews images
        for (int i = 0; i < keyPreviewsParent.childCount; i++)
        {
            keyPreviews[i] = keyPreviewsParent.GetChild(i).GetComponent<Image>();
        }
    }

    private void Update()
    {
        // Check for input
        if (Input.GetKeyDown(cycleKey))
        {
            CycleKey();
        }
    }

    /// <summary>
    /// Moves the key at the end of the list to the start
    /// </summary>
    private void CycleKey()
    {
        // Checks to make sure the player has a key to switch to
        if (keys.Count > 1)
        {
            keys.Add(keys[0]);
            keys.RemoveAt(0);
        }
        else
        {
            Debug.Log("No other keys to switch to.");
        }
    }

    /*
    // TODO
    private void DisplayPreviews()
    {
        for (int i = 0; i < keyPreviews.Length; i++)
        {

        }
    }
    */
}
