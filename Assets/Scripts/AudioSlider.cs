/// Attach this script to an audio slider

using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] [Tooltip("Enter the name of the VCA from FMOD")]
    private string nameOfVCA = "Master"; // Default to Master

    private Slider volSlider = null;
    private VCA vca;    // FMOD Volume Control

    [SerializeField] private float defaultVol = 0.75f;
    private float currentVol;

    private void OnEnable()
    {
        // Assign variables
        vca = RuntimeManager.GetVCA($"vca:/{nameOfVCA}");
        volSlider = GetComponent<Slider>();

        // Initialise volume
        currentVol = PlayerPrefs.GetFloat(nameOfVCA, defaultVol);      // Retrieves volume prefs if they exist, otherwise defaulting to 0.75f
        Debug.Log(currentVol);
        vca.setVolume(currentVol);
        volSlider.value = currentVol;
        //Debug.Log(currentVol);
    }

    /// <summary>
    /// Called by Volume Slider as a dynamic float
    /// Sets the selected VCA's volume
    /// </summary>
    /// <param name="vol"></param>
    public void SetVolume(float vol)
    {
        vca.setVolume(vol);
        PlayerPrefs.SetFloat(nameOfVCA, vol);
        PlayerPrefs.Save();
    }
}
