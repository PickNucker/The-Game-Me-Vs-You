using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;

    [SerializeField] int[] nextLevelEXPCounts;


    [SerializeField] TMPro.TextMeshProUGUI currentEXPText = null;
    [SerializeField] TMPro.TextMeshProUGUI nextLevelEXPText = null;
    [SerializeField] TMPro.TextMeshProUGUI currentLevelText = null;

    [SerializeField] Slider expBar = null;
    [Space]
    [SerializeField] CanvasGroup lvlUpMsg = null;
    [SerializeField] TMPro.TextMeshProUGUI lvlUpText;

    [SerializeField] AudioTrigger lvlUp;

    public int currentEXP;

    float timer = Mathf.Infinity;

    int gapEXPHolder;
    int currenLevel;
    int nextLevelCount;

    bool activateMessge;

    private void Awake()
    {
        instance = this;
        lvlUpMsg.alpha = 0;
    }

    private void Start()
    {
        nextLevelCount = 0;
        currenLevel = 0;
        currentEXP = 0;
    }

    private void Update()
    {
        currentEXPText.text = currentEXP.ToString() + " /";
        nextLevelEXPText.text = nextLevelEXPCounts[nextLevelCount].ToString();
        if(currenLevel != 10)
        {
             currentLevelText.text = "LVL " + currenLevel.ToString();
        }
        else
        {
            currentLevelText.text = "MAX LVL";
        }

        expBar.value = currentEXP;
        expBar.maxValue = nextLevelEXPCounts[nextLevelCount];


        if (activateMessge)
        {
            timer += Time.deltaTime;
            lvlUpMsg.alpha = Mathf.Lerp(lvlUpMsg.alpha, 1, Time.deltaTime * 8f);

        }
        if(timer >= 8f)
        {
            activateMessge = false;
            lvlUpMsg.alpha = Mathf.Lerp(lvlUpMsg.alpha, 0, Time.deltaTime * 8f);
        }

        HandleEXP();
    }

    public void Save()
    {
        // currentLevel
        ES3.Save("currentLevel", currenLevel);
        // currrentExp
        ES3.Save("currentEXP", currentEXP);
    }

    public void Load()
    {
        // currentLevel
        int newLvl = ES3.Load("currentLevel", currenLevel);
        if(newLvl != currenLevel)
            currenLevel = newLvl;

        // currrentExp
        int curEXP = ES3.Load("currentEXP", currentEXP);
        currentEXP = curEXP;
    }

    void HandleEXP()
    {
        if (currentEXP >= nextLevelEXPCounts[nextLevelCount])
        {
            LevelUp();
            nextLevelCount++;
            currentEXP = 0;
            timer = 0;
        }
    }

    private void LevelUp()
    {
        currenLevel++;
        activateMessge = true;

        lvlUp.Play(transform.position);

        bool lvlUp1 = false;
        bool lvlUp2 = false;

        if(currenLevel == 6)
        {
            lvlUpText.text = "Du hast Level " + currenLevel.ToString("0") + " erreicht \nDu hast <color=red>2</color> Skillpunkte bekommen\nZudem wurde der Cooldown vom Heal und Bleyblade um <color=red>20</color> Sekunden reduziert";

            if (!lvlUp1)
            {
                PlayerHealthBar.instance.timerToHeal -= 20f;
                PlayerHealthBar.instance.timerToBleyblade -= 20f;
                lvlUp1 = true;
            }
            SkillSystem.instance.AddSkillPoints(2);
        }
        else if(currenLevel == 10)
        {
            lvlUpText.text = "Du hast Level " + currenLevel.ToString("0") + " erreicht \nDu hast <color=red>4</color> Skillpunkte bekommen\nZudem wurde der Cooldown vom Heal und Bleyblade um weitere <color=red>20</color> Sekunden reduziert";
            if (!lvlUp2)
            {
                PlayerHealthBar.instance.timerToHeal -= 20f;
                PlayerHealthBar.instance.timerToBleyblade -= 20f;
                lvlUp2 = true;
            }
            SkillSystem.instance.AddSkillPoints(10);
        }
        else
        {
            lvlUpText.text = "Du hast Level " + currenLevel.ToString("0") + " erreicht \nDu hast <color=red>2</color> Skillpunkte bekommen";
            SkillSystem.instance.AddSkillPoints(2); 
        }
    }

    public void AddEXP(int exp)
    {
        if (currenLevel < 10)
        {
            currentEXP += exp;           
        }
        else
        {
            currentEXP = 0;
        }
    }

}
