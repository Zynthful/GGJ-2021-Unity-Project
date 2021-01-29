﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExplosionTimer : MonoBehaviour
{
    [SerializeField] [Tooltip("Time in seconds before the nuke arrives and brings destruction to all")]
    private float timeToExplode = 120f;

    private Slider slider = null;
    private TextMeshProUGUI timeLeftText = null;

    private void Start()
    {
        // Initialise variables
        timeLeftText = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponent<Slider>();
        
        // Reign destruction
        StartCoroutine(Timer());
    }

    /// <summary>
    /// Counts down from timeToExplode seconds
    /// Updates text and slider value
    /// </summary>
    /// <returns></returns>
    private IEnumerator Timer()
    {
        float currentTime = timeToExplode;
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeLeftText.text = $"Time left: {Mathf.CeilToInt(currentTime)}";   // Update text
            slider.value = currentTime / timeToExplode;                         // Update slider value
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Dead");
    }
}
