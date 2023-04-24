using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioMixer mainMixer;
    [SerializeField] EventSystem system;
    [Space]
    [SerializeField] Image fadeOut;
    [SerializeField] string startName;

    [SerializeField] Slider slider;
    [SerializeField] AudioTrigger buttonHoverSound;
    [SerializeField] AudioTrigger buttonPressed;
    [SerializeField] AudioTrigger startNewGame;
    [SerializeField] AudioTrigger resumeGame;

    [SerializeField] InputActionAsset systems;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        Time.timeScale = 1f;
        anim.SetTrigger("fadeIn");
        slider.value = -15f;
        system.enabled = false;
        yield return new WaitForSeconds(3f);
        system.enabled = true;
    }

    public void QuitGame()
    {
        buttonPressed.Play(Camera.main.transform.position);
        Application.Quit();
    }

    public void Resume()
    {
        if (!system.enabled) return;
        anim.SetTrigger("fadeOut");
        system.enabled = false;
        resumeGame.Play(Camera.main.transform.position);
        StartCoroutine(LoadGamer());
    }

    public void NewGame()
    {
        if (!system.enabled) return;
        anim.SetTrigger("fadeOut");
        system.enabled = false;
        startNewGame.Play(Camera.main.transform.position);
        ES3.DeleteFile();
        StartCoroutine(StartNewGame());
    }

    public void LoadGame()
    {
        if (!system.enabled) return;
        anim.SetTrigger("fadeOut");
        system.enabled = false;
        buttonPressed.Play(Camera.main.transform.position);
        StartCoroutine(LoadGamer());
    }

    public void Youtube()
    {
        if (!system.enabled) return;
        buttonPressed.Play(Camera.main.transform.position);
        Application.OpenURL("https://www.youtube.com/channel/UCglT6IwfWnRxk1IscWz3F_g");
    }

    public void HandleVolumeMusic()
    {
        mainMixer.SetFloat("MainMenuMusicSFX", slider.value);
    }

    public void SoundOnSelected()
    {
        if (!system.enabled) return;
        buttonHoverSound.Play(Camera.main.transform.position);
    }

    IEnumerator StartNewGame()
    {
        yield return new WaitForSeconds(3f);
        GetScene(startName);
    }

    IEnumerator LoadGamer()
    {
        yield return new WaitForSeconds(3f);
        GetScene(startName);
    }

    public void GetScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void Update()
    {

    }

}
