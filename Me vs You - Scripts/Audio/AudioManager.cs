using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer masterMixer;

    [SerializeField] Slider game = null;
    [SerializeField] Slider music = null;
    [SerializeField] Slider sound = null;

    Dictionary<string, AudioClip> allSounds;

    void Awake()
    {
        instance = this;


        //Load Sounds:
        allSounds = new Dictionary<string, AudioClip>();
        foreach (AudioClip ac in Resources.LoadAll<AudioClip>("Audio"))
        {
            allSounds.Add(ac.name, ac);
        }
    }

    private void Start()
    {
        if (game != null)
            game.value = 0;
        if (music != null)
            music.value = 0;
        if (sound != null)
            sound.value = -5f;
    }

    public static AudioClip GetSound(string soundName)
    {
        return instance.allSounds[soundName];
    }


    public void ChangeMaster()
    {
        masterMixer.SetFloat("MasterSFX", game.value);
    }

    public void ChangeMusic()
    {
        masterMixer.SetFloat("MusicSFX", music.value);
    }

    public void ChangeSound()
    {
        masterMixer.SetFloat("SoundSFX", sound.value);
    }

}
