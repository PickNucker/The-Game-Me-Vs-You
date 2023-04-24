using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameUIHandler : MonoBehaviour
{
    public static IngameUIHandler instance;

    [SerializeField] CanvasGroup deadScreen;
    

    [SerializeField] Tutorial tutorial;

    [SerializeField] EventSystem eventSystem;

    [SerializeField] CinemachineFreeLook cam;
    [SerializeField] Slider vertical;
    [SerializeField] Slider horizontal;

    [SerializeField] GameObject startFirstPage = null;
    [SerializeField] GameObject startSecondPage = null;
    [SerializeField] GameObject startThirdPage = null;
    [Space]
    [SerializeField] PlayerData playerData;
    [Space]
    [SerializeField] TMPro.TextMeshProUGUI xPressed;
    [SerializeField] TMPro.TextMeshProUGUI kreisPressed;
    [SerializeField] TMPro.TextMeshProUGUI viereckPressed;
    [SerializeField] TMPro.TextMeshProUGUI dreieckPressed;

    [Space]
    [SerializeField] GameObject gameObjects = null;
    [SerializeField] CanvasGroup canvas = null;
    [SerializeField] Image stamina = null;
    [SerializeField] float timerUntilNoSprint = 3f;
    
    [Space]
    public UnityEvent deadScreenEvent;
    public UnityEvent activateSecondL1;
    public UnityEvent deActivateSecondL1;
    public UnityEvent activatePauseMenu;
    public UnityEvent deActivatePauseMenu;

    // Inventory
    [Space]
    public UnityEvent getFirstPage;
    public UnityEvent getSecondPage;
    public UnityEvent getThirdPage;

    [Space]
    [SerializeField] AudioTrigger buttonHover;
    [SerializeField] AudioTrigger buttonClicked;

    Player player;

    float timer;

    bool gotActivatedMenu;
    bool gotActivatedAbilityMenu;
    bool gotActivatedSettingsMenu;

    [HideInInspector]
    public int menuCount;

    private void Awake()
    {
        Screen.fullScreen = true;
        instance = this;

        player = FindObjectOfType<Player>();

    }

    void Start()
    {
        menuCount = 2;
        vertical.value = 1f;
        horizontal.value = 200f;
        timer = 1;
        canvas.alpha = 0;
        deadScreen.alpha = 0;
    }

    void Update()
    {
        if(PlayerHealthBar.instance.currentHearts <= 0)
        {
            bool activee = false;
            deadScreen.alpha = Mathf.Lerp(deadScreen.alpha, 1, Time.deltaTime * 2f);

            if (!activee)
            {
                deadScreenEvent.Invoke();
                activee = true;
            }
        }


        if (tutorial != null)
        {
            if (tutorial.isInteracting)
            {
                return;
            }
        }

        if (EnablePauseMenu())
        {
       
            if(menuCount == 2)
            {
                if (player.Input.R1Dropdown)
                {      
                    player.Input.DisableR1();
                    player.Input.DisableL1();
                    menuCount = 3;
                    getThirdPage.Invoke();
                }
       
                if (player.Input.GetSecondL1Dropdown)
                {
                    player.Input.DisableR1();
                    player.Input.DisableL1();
                    menuCount = 1;
                    getFirstPage.Invoke();
                }
            }
            
            if (menuCount == 1 && player.Input.R1Dropdown)
            {       
                player.Input.DisableR1();
                player.Input.DisableL1();
                menuCount = 2;
                getSecondPage.Invoke();
            }
       
            if (menuCount == 3 && player.Input.GetSecondL1Dropdown)
            {
       
                player.Input.DisableR1();
                player.Input.DisableL1();
                getSecondPage.Invoke();
                menuCount = 2;
            }



            if (!gotActivatedMenu && menuCount == 2)
            {
                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(startSecondPage);
                gotActivatedMenu = true;

                gotActivatedAbilityMenu = false;
                gotActivatedSettingsMenu = false;
            }

            if (!gotActivatedAbilityMenu && menuCount == 1)
            {
                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(startFirstPage);
                gotActivatedAbilityMenu = true;

                gotActivatedSettingsMenu = false;
                gotActivatedMenu = false;
            }

            if (!gotActivatedSettingsMenu && menuCount == 3)
            {
                eventSystem.SetSelectedGameObject(null);
                eventSystem.SetSelectedGameObject(startThirdPage);
                gotActivatedSettingsMenu = true;

                gotActivatedMenu = false;
                gotActivatedAbilityMenu = false;
            }

        }

        if (player.Input.GetSecondL1Dropdown && !player.currentlyAttacking)
            activateSecondL1.Invoke();
        
        if(!player.Input.GetSecondL1Dropdown)
            deActivateSecondL1.Invoke();

        if (EnablePauseMenu()) return;



        if (player.isGrounded)
        {
            HandleSprint();

            if (timer <= 0.95f)
            {
                canvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(canvas.GetComponent<CanvasGroup>().alpha, 1f, Time.deltaTime * 5f);
            }
            else
            {
                canvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(canvas.GetComponent<CanvasGroup>().alpha, 0f, Time.deltaTime * 5f);
            }
        }
    }


    public void ChangeText(string xPress, string kreisPress, string viereckPress, string dreieckPress)
    {
        xPressed.text = xPress;
        kreisPressed.text = kreisPress;
        viereckPressed.text = viereckPress;
        dreieckPressed.text = dreieckPress;
    }


    public bool EnablePauseMenu()
    {


        if (player.Input.PauseEnabled)
        {
            Time.timeScale = 0f;
            activatePauseMenu.Invoke();
            return true;

        }
        else
        {
            menuCount = 2;
            gotActivatedMenu = false;
            //GetSecondPage();
            DisablePauseMenu();
            getSecondPage.Invoke();


            deActivatePauseMenu.Invoke();

            return false;
        }
    }

    public void DisablePauseMenu()
    {
        Time.timeScale = 1f;
    }

    public void HandleSprint()
    {
        stamina.fillAmount = timer;

        gameObjects.transform.LookAt(Camera.main.transform);

       

        if (timer < 1 && !player.Input.Sprint)
        {
            timer +=  Time.deltaTime / timerUntilNoSprint;
        }
        else if (timer <= 1 && player.isGrounded && player.Controller.velocity.magnitude != 0)
        {
            if(player.Input.Sprint)
                timer -= Time.deltaTime / timerUntilNoSprint;
        }

        if(timer <= 0)
        {
            player.Input.DisableSprint();
        }

        if (timer >= 1) timer = 1;
    }

    public void HandleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void HandleSensVertical()
    {
        cam.m_YAxis.m_MaxSpeed = vertical.value;
    }

    public void HandleSensHorizontal()
    {
        cam.m_XAxis.m_MaxSpeed = horizontal.value;
    }

    public void GetNextButton(GameObject button)
    {
        eventSystem.SetSelectedGameObject(button);
    }

    public void PlayButtonClickedSound()
    {
        buttonClicked.Play(Camera.main.transform.position);
    }

    public void PlayHoverButtonSound()
    {
        buttonHover.Play(Camera.main.transform.position);
    }

    public void QuitGame()
    {
        buttonClicked.Play(Camera.main.transform.position);
        Application.Quit();
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
