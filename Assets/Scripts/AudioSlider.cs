/// Attach this script to an audio slider

using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] [Tooltip("Enter the name of the VCA from FMOD")]
    private string nameOfVCA = "Master"; // Default to Master

    private VCA vca;    // FMOD Volume Control

    [SerializeField] private float defaultVol = 0.75f;

    private void OnEnable()
    {
        // Assign variables
        vca = RuntimeManager.GetVCA($"vca:/{nameOfVCA}");

        // Initialise volume
        float initialVol = PlayerPrefs.GetFloat(nameOfVCA, defaultVol);      // Retrieves volume prefs if they exist, otherwise defaulting to defaultVol
        vca.setVolume(initialVol);
        GetComponent<Slider>().value = initialVol;
    }

    /// <summary>
    /// Called by OnValueChanged() dynamic float on slider.
    /// Sets the selected VCA's volume.
    /// </summary>
    /// <param name="vol"></param>
    public void SetVolume(float vol)
    {
        vca.setVolume(vol);
        PlayerPrefs.SetFloat(nameOfVCA, vol);
        PlayerPrefs.Save();
    }
}
