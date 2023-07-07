using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsSceneController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [Range(0, 1)] [SerializeField] private float defaultMasterVol;
    [SerializeField] private Slider sfxSlider;
    [Range(0, 1)] [SerializeField] private float defaultSfxVol;
    [SerializeField] private Slider musicSlider;
    [Range(0, 1)] [SerializeField] private float defaultMusicVol;

    private const string MasterVolKey = "MasterVol";
    private const string SfxVolKey = "SfxVol";
    private const string MusicVolKey = "MusicVol";

    public void Start()
    {
        LoadSound();
    }

    public void SetMasterVolume (float sliderValue)
    {
        audioMixer.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSfxVol (float sliderValue)
    {
        audioMixer.SetFloat("sfxVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetMusicVol (float sliderValue)
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void Back()
    {
        PlayerPrefs.SetFloat(MasterVolKey, masterSlider.value);
        PlayerPrefs.SetFloat(SfxVolKey, sfxSlider.value);
        PlayerPrefs.SetFloat(MusicVolKey, musicSlider.value);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Menu");
    }

    public void ResetToDefault()
    {
        masterSlider.value = defaultMasterVol;
        sfxSlider.value = defaultSfxVol;
        musicSlider.value = defaultMusicVol;
    }

    private void LoadSound()
    {
        masterSlider.value = PlayerPrefs.GetFloat(MasterVolKey, defaultMasterVol);
        sfxSlider.value = PlayerPrefs.GetFloat(SfxVolKey, defaultSfxVol);
        musicSlider.value = PlayerPrefs.GetFloat(MusicVolKey, defaultMusicVol);
    }
}
