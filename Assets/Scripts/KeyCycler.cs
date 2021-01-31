using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

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

    // FMOD
    [EventRef] private string eSwitchKey = "{e68de96c-396d-405d-b319-d7e5432f860f}";

    private void Start()
    {
        // Initialise array
        keyPreviews = new Image[keyPreviewsParent.transform.childCount];

        // Get keyPreviews images
        for (int i = 0; i < keyPreviewsParent.childCount; i++)
        {
            keyPreviews[i] = keyPreviewsParent.GetChild(i).GetComponent<Image>();
        }

        SetImages();
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
            SetImages();

            // SwitchKey SFX
            RuntimeManager.PlayOneShot(eSwitchKey);
        }
        else
        {
            Debug.Log("No other keys to switch to.");
        }
    }


    private void SetImages()
    {
        for (int i = 0; i < keyPreviews.Length; i++)
        {
            if (i < keys.Count)
            {
                keyPreviews[i].color = keys[i].GetComponent<Key>().getColour();
            }
        }      
    }


    public Transform GetEquippedKey()
    {
        if (keys.Count > 0)
        {
            return keys[0];
        }

        else
        {
            return null;
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

    public void AddKey(Transform key)
    {
        keys.Add(key);
        SetImages();
    }
}
