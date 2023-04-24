using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionChest : MonoBehaviour
{
    public static InteractionChest instance;

    [Header("Reward")]
    [SerializeField] GameObject disable = null;
    [SerializeField] bool herzContainter;
    [SerializeField] bool bleyblade;
    [SerializeField] int skillPunkte;
    [SerializeField] int exp;

    [Space]
    [SerializeField] AudioTrigger openChest;
    [SerializeField] AudioTrigger rewardSound;

    [Space]
    [SerializeField] TMPro.TextMeshProUGUI textRaum = null;
    [SerializeField] CanvasGroup message;
    [SerializeField] CanvasGroup buttonShowUp;
    [SerializeField] float messageDuration = 8f;
    [SerializeField] float detectRange = 2f;

    Player player;
    Animator anim;

    public float timer = 0;
    float timerForButton = 0;

    bool open;
    bool chestOpened;
    bool canPressX;

    [HideInInspector]
    public bool disableLock;
    public bool activateMessge;

    bool activateButton;
    bool deactiveButton;

    float maxDur;

    private void OnEnable()
    {
        DetectPlayerInRange();
    }

    void Awake()
    {
        instance = this;
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        timer = 0;
        maxDur = messageDuration;
    }

    void Update()
    {

        if (canPressX && InputSystem.instance.DreieckPressed && !open || canPressX && Input.GetButton("Jump") && !open)
        {
            //activateMessge = false;
            messageDuration = maxDur;
            timerForButton = 0;
            //timer = 0;
            chestOpened = true;
            open = true;
        }

        OpenChest();
        GetMessageOutOfTheBox();

        if (activateButton)
        {
            if (!deactiveButton && !open)
            {
                timerForButton = 0;

                buttonShowUp.alpha = Mathf.Lerp(buttonShowUp.alpha, 1, Time.deltaTime * 10f);
            }

            if (deactiveButton || open)
            {
                timerForButton += Time.deltaTime;
                buttonShowUp.alpha = Mathf.Lerp(buttonShowUp.alpha, 0, Time.deltaTime * 10f);

                if (timerForButton >= 4f)
                {
                    activateButton = false;
                    buttonShowUp.alpha = 0;
                }
            }
        }

        DetectPlayerInRange();


    }

    private void GetMessageOutOfTheBox()
    {
        if (activateMessge)
        {
            timer += Time.deltaTime;
            message.alpha = Mathf.Lerp(message.alpha, 1, Time.deltaTime * 5f);
        }
        if (timer >= messageDuration)
        {
            activateMessge = false;
            message.alpha = Mathf.Lerp(message.alpha, 0, Time.deltaTime * 5f);
        }
    }

    private void DetectPlayerInRange()
    {
        //buttonShowUp.alpha = Mathf.Clamp(buttonShowUp.alpha, 0, 1);
    }

    void OpenChest()
    {
        if (chestOpened)
        {
            timer = 0;
            canPressX = false;
            GetReward();
            openChest.Play(transform.position);
            rewardSound.Play(player.transform.position);
            anim.SetTrigger("open");
            chestOpened = false;
        }
    }

    public void Save()
    {

    }

    public void Load()
    {

    }

    void GetReward()
    {
        textRaum.text = "";

        textRaum.text += "Reward: \n";

        if (bleyblade)
        {
            textRaum.text += "Du hast den Skill: Beyblade freigeschaltet \r\n\n";
            PlayerHealthBar.instance.abilityUnlocked = true;
            if(disable != null || disableLock)
            {
                disable.SetActive(false);
            }
        }
        
        if (herzContainter)
        {
            textRaum.text += "Du hast ein zusaetzliches Herz bekommen \r\n";
            PlayerHealthBar.instance.AddContainer();
        }


        if (skillPunkte > 0)
        {
            textRaum.text += "Du hast " + skillPunkte + " Skillpunkte erhalten \r\n";
            SkillSystem.instance.AddSkillPoints(skillPunkte);
        }
        if (exp > 0)
        {
            textRaum.text += "Du hast " + exp + " Experience erhalten \r\n";
            LevelSystem.instance.AddEXP(exp);
        }

        activateMessge = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activateButton = true;
            deactiveButton = false;
            canPressX = true;
            //player.canInteractWithSomething = true;
            buttonShowUp.alpha = Mathf.Lerp(buttonShowUp.alpha, 1, Time.deltaTime * 5f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deactiveButton = true;
            buttonShowUp.alpha = Mathf.Lerp(buttonShowUp.alpha, 0, Time.deltaTime * 5f);
            //player.canInteractWithSomething = false;
            canPressX = false;
        }
    }
}
