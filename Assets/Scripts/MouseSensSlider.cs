using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSensSlider : MonoBehaviour
{
    [SerializeField] private float defaultSens = 3f;
    [SerializeField] private TextMeshProUGUI sensText = null;
    private Slider slider = null;

    private void Start()
    {
        slider = GetComponent<Slider>();

        // Initialise sensitivity
        SetSens(PlayerPrefs.GetFloat("Mouse Sensitivity", defaultSens)); // Retrieves Sensitivity Prefs if they exist, otherwise defaults to defaultSens
    }

    /// <summary>
    /// Called by OnValueChanged() dynamic float on slider.
    /// Sets the new mouse sensitivity.
    /// </summary>
    /// <param name="sens"></param>
    public void SetSens(float sens)
    {
        sens = Mathf.RoundToInt(sens);
        sensText.text = sens.ToString();
        if (slider != null)
        {
            slider.value = sens;
        }
        PlayerPrefs.SetFloat("Mouse Sensitivity", sens);
        PlayerPrefs.Save();
    }
}
