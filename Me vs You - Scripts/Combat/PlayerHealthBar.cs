using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar instance;

    [SerializeField] GameObject heartContainerPrefab = null;
    [SerializeField] List<GameObject> heartContainers;

    [SerializeField] CanvasGroup canvasGroup1 = null;
    [SerializeField] CanvasGroup canvasGroup2 = null;
    [SerializeField] CanvasGroup canvasGroup3 = null;
    [SerializeField] CanvasGroup canvasGroup4 = null;
    [SerializeField] TMPro.TextMeshProUGUI forth = null;
    [SerializeField] TMPro.TextMeshProUGUI third = null;
    [SerializeField] TMPro.TextMeshProUGUI second = null;
    [SerializeField] TMPro.TextMeshProUGUI first = null;

    public bool abilityUnlocked;
    public bool PlayerIsDead { get; private set; }
    public bool ReadyToHeal { get; private set; }
    public bool ReadyToBleyblade { get; private set; }

    PlayerHeartContainer currentContainer;

    [HideInInspector]
    public float currentHearts = 5;
    int totalHearts;

    public float timerToHeal = 60f;
    public float timerToBleyblade = 90f;
    public float timerToAbility2 = 75f;
    public float timerToAbility3 = 75f;

    float timer;
    float timer2;
    float timer3;
    float timer4;

    private void Awake()
    {
        instance = this;
        heartContainers = new List<GameObject>();
    }

    private void Start()
    {
        SetupHearts(5);
        Load();
        canvasGroup4.alpha = 0;
        canvasGroup3.alpha = 0;
        canvasGroup2.alpha = 0;
        canvasGroup1.alpha = 0;
        timer = 0;
        timer2 = 0;
        timer3 = 0;
        timer4 = 0;
    }

    public void Save()
    {
        ES3.Save("abilityUnlocked", abilityUnlocked);
        ES3.Save("currentHearts", currentHearts);
        ES3.Save("unlock", InteractionChest.instance.disableLock);
    }

    public void Load()
    {
        bool unlocked = ES3.Load("abilityUnlocked", abilityUnlocked);
        abilityUnlocked = unlocked;
        //
        //bool unlok = ES3.Load("unlock", InteractionChest.instance.disableLock);
        //InteractionChest.instance.disableLock = unlok;

        float curHearts = ES3.Load("currentHearts", currentHearts);
        SetupHearts((int)curHearts);
    }

    public void SetupHearts(int heartsIn)
    {
        heartContainers.Clear();
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        totalHearts = heartsIn;
        currentHearts = (float)totalHearts;

        for (int i = 0; i < totalHearts; i++)
        {
            GameObject newHeart = Instantiate(heartContainerPrefab, transform);
            heartContainers.Add(newHeart);

            if(currentContainer != null)
            {
                currentContainer.next = newHeart.GetComponent<PlayerHeartContainer>();
            }
            currentContainer = newHeart.GetComponent<PlayerHeartContainer>();
        }

        currentContainer = heartContainers[0].GetComponent<PlayerHeartContainer>();
    }

    public void SetCurrentHealth(float health)
    {
        currentHearts = health;
        currentContainer.SetHeart(currentHearts);
    }

    public void AddHearts (float addHealth)
    {
        currentHearts += addHealth;
        if(currentHearts > totalHearts)
        {
            currentHearts = (float)totalHearts;
        }

        currentContainer.SetHeart(currentHearts);
    }

    public void RemoveHearts(float removeHealth)
    {
        currentHearts -= removeHealth;
        if (currentHearts < 0)
        {
            currentHearts = 0f;
        }

        currentContainer.SetHeart(currentHearts);
    }

    public void AddContainer()
    {
        GameObject newHeart = Instantiate(heartContainerPrefab, transform);
        currentContainer = heartContainers[heartContainers.Count - 1].GetComponent<PlayerHeartContainer>();
        heartContainers.Add(newHeart);

        if(currentContainer != null)
        {
            currentContainer.next = newHeart.GetComponent<PlayerHeartContainer>();
        }

        currentContainer = heartContainers[0].GetComponent<PlayerHeartContainer>();

        totalHearts++;
        currentHearts = (float)totalHearts;
        SetCurrentHealth(currentHearts);
    }

    private void Update()
    {
        if (currentHearts <= 0) PlayerIsDead = true;
        else PlayerIsDead = false;

        if (abilityUnlocked)
        {
            if(FindObjectOfType<InteractionChest>() != null)
            {
                InteractionChest.instance.disableLock = true;
            }
        }

        HealAbility();
        BleybladeAbility();
    }

    private void HealAbility()
    {
        timer -= Time.deltaTime;

        forth.text = timer.ToString("0");

        if (timer <= 1)
        {
            canvasGroup4.alpha = Mathf.Lerp(canvasGroup4.alpha, 0, Time.deltaTime * 5f);
        }
        else
        {
            canvasGroup4.alpha = Mathf.Lerp(canvasGroup4.alpha, 1, Time.deltaTime * 5f);
        }

        if (timer <= 0)
        {
            ReadyToHeal = true;
        }
        else
        {
            ReadyToHeal = false;
        }
    }

    private void BleybladeAbility()
    {
        if (abilityUnlocked)
        {
            timer2 -= Time.deltaTime;

            third.text = timer2.ToString("0");

            if (timer2 <= 1)
            {
                canvasGroup3.alpha = Mathf.Lerp(canvasGroup3.alpha, 0, Time.deltaTime * 5f);
            }
            else
            {
                canvasGroup3.alpha = Mathf.Lerp(canvasGroup3.alpha, 1, Time.deltaTime * 5f);
            }

            if (timer2 <= 0)
            {
                ReadyToBleyblade = true;
            }
            else
            {
                ReadyToBleyblade = false;
            }
        }
    }

    private void Ability2()
    {
        timer3 -= Time.deltaTime;

        second.text = timer3.ToString("0");

        if (timer3 <= 1)
        {
            canvasGroup2.alpha = Mathf.Lerp(canvasGroup2.alpha, 0, Time.deltaTime * 5f);
        }
        else
        {
            canvasGroup2.alpha = Mathf.Lerp(canvasGroup2.alpha, 1, Time.deltaTime * 5f);
        }

        if (timer3 <= 0)
        {
            //ReadyToBleyblade = true;
        }
        else
        {
            //ReadyToBleyblade = false;
        }
    }

    private void Ability3()
    {
        timer4 -= Time.deltaTime;

        first.text = timer4.ToString("0");

        if (timer4 <= 1)
        {
            canvasGroup1.alpha = Mathf.Lerp(canvasGroup1.alpha, 0, Time.deltaTime * 5f);
        }
        else
        {
            canvasGroup1.alpha = Mathf.Lerp(canvasGroup1.alpha, 1, Time.deltaTime * 5f);
        }

        if (timer4 <= 0)
        {
            //ReadyToBleyblade = true;
        }
        else
        {
            //ReadyToBleyblade = false;
        }
    }

    public void ResetTimer() => timer = timerToHeal;

    public void ResetTimer2() => timer2 = timerToBleyblade;

    public void ResetTimer3()
    {
        timer3 = timerToAbility2;
    }
    public void ResetTimer4()
    {
        timer4 = timerToAbility3;
    }

}
