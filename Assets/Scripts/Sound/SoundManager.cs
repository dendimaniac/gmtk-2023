using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] public Sound[] sounds;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;
    [SerializeField] public Sound[] policeSpawningSound;
    
    private const string MasterVolKey = "MasterVol";
    private const string SfxVolKey = "SfxVol";
    private const string MusicVolKey = "MusicVol";
 
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volumn;
            sound.source.outputAudioMixerGroup = sfxMixerGroup;
        }
        foreach (Sound sound in policeSpawningSound)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volumn;
            sound.source.outputAudioMixerGroup = sfxMixerGroup;
        }
    }

    private void Start()
    {
        var master = PlayerPrefs.GetFloat(MasterVolKey, 1);
        var sfx = PlayerPrefs.GetFloat(SfxVolKey, 1);
        var music = PlayerPrefs.GetFloat(MusicVolKey, 1);
        
        audioMixer.SetFloat("masterVol", Mathf.Log10(master) * 20);
        audioMixer.SetFloat("sfxVol", Mathf.Log10(sfx) * 20);
        audioMixer.SetFloat("musicVol", Mathf.Log10(music) * 20);
    }

    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.source.Play();
    }

    public void GetRandomPoliceSpawnSound()
    {
        Sound sound = policeSpawningSound[Random.Range(0, policeSpawningSound.Length)];
        sound.source.Play();
    }
    
    public void StopSound(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.source.Stop();
    }
}
