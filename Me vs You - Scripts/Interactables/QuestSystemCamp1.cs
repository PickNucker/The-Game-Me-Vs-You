using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestSystemCamp1 : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI textRaum = null;
    [SerializeField] CanvasGroup message;

    [Space]
    [SerializeField] UnityEvent spawnRewardChest;

    [SerializeField] List<Entity> enemies = new List<Entity>();

    [SerializeField] AudioTrigger activateSound;
    [SerializeField] AudioTrigger finishSound;

    [SerializeField] bool camp1, camp2, camp3, großesCamp, island;

    int ratCountDead,
        lizardCountDead,
        chestCountDead,
        specterCountDead,
        knightCountDead,
        crabCountDead,
        demonCountDead,
        werewolfCountDead,
        beholderCountDead;

    float timer = 0;

    bool activateMessge;
    bool deActivateMessge;
    bool campDone;

    bool playedFinish;
   
    void Update()
    {
        GetAllEnemiesInList();

        if (activateMessge)
        {
            UpdateGui();

            if (!deActivateMessge && !campDone)
            {
                timer = 0;

                message.alpha = Mathf.Lerp(message.alpha, 1, Time.deltaTime * 2f);
            }

            if (deActivateMessge || campDone)
            {
                timer += Time.deltaTime;
                message.alpha = Mathf.Lerp(message.alpha, 0, Time.deltaTime * 10f);

                if (timer >= 4f)
                {
                    activateMessge = false;
                    message.alpha = 0;
                }
            }
        }
    }

    private void GetAllEnemiesInList()
    {
        foreach (Entity enemy in enemies)
        {
            if (enemy.health.health <= 0)
            {
                #region CountDeads
                if (enemy.name.Contains("E1"))
                {
                    ratCountDead++;
                }
                if (enemy.name.Contains("E2"))
                {
                    lizardCountDead++;
                }
                if (enemy.name.Contains("E3"))
                {
                    chestCountDead++;
                }
                if (enemy.name.Contains("E4"))
                {
                    specterCountDead++;
                }
                if (enemy.name.Contains("E5"))
                {
                    knightCountDead++;
                }
                if (enemy.name.Contains("E6"))
                {
                    crabCountDead++;
                }
                if (enemy.name.Contains("E7"))
                {
                    demonCountDead++;
                }
                if (enemy.name.Contains("E8"))
                {
                    werewolfCountDead++;
                }
                if (enemy.name.Contains("E9"))
                {
                    beholderCountDead++;
                }
                #endregion
                enemies.Remove(enemy);
            }
        }

        if (enemies.Count <= 0)
        {
            campDone = true;
            spawnRewardChest.Invoke();

            message.alpha = 0;

            if (!playedFinish)
            {
                finishSound.Play(Player.instance.transform.position);
                playedFinish = true;
            }

            Destroy(this.gameObject, 10f);
        }
    }

    void UpdateGui()
    {
        if (camp1)
        {
            textRaum.text = "";
            textRaum.text = "Quest:" +
            "\n" + ratCountDead + "  /  " + 2 + " RatAssasin" +
            "\n" + lizardCountDead + "  /  " + 1 + " LizardWarrior" +
            "\n" + chestCountDead + "  /  " + 1 + " ChestMonster" +
            //"\n" + specterCountDead + "  /  " + 1 + " Specter" +
            "\n" + knightCountDead + "  /  " + 1 + " BlackKnight" +
            //"\n" + crabCountDead + "  /  " + 0 + " CrabMonster" +
            "\n" + demonCountDead + "  /  " + 1 + " FlyingDemon" +
            //"\n" + werewolfCountDead + "  /  " + 0 + " Werewolf" +
           // "\n" + beholderCountDead + "  /  " + 0 + " Beholder" +
            "\n" + "Rewards: \t" + "?  ?  ?";
        }
        if (camp2)
        {
            textRaum.text = "";
            textRaum.text = "Quest:" +
            "\n" + ratCountDead + "  /  " + 5 + " RatAssasin" +
            //"\n" + lizardCountDead + "  /  " + 0 + " LizardWarrior" +
            //"\n" + chestCountDead + "  /  " + 2 + " ChestMonster" +
            //"\n" + specterCountDead + "  /  " + 1 + " Specter" +
            "\n" + knightCountDead + "  /  " + 2 + " BlackKnight" +
            //"\n" + crabCountDead + "  /  " + 4 + " CrabMonster" +
            "\n" + demonCountDead + "  /  " + 2 + " FlyingDemon" +
            //"\n" + werewolfCountDead + "  /  " + 0 + " Werewolf" +
            //"\n" + beholderCountDead + "  /  " + 0 + " Beholder" +
            "\n" + "Rewards: \t" + "?  ?  ?";
        }
        if (camp3)
        {
            textRaum.text = "";
            textRaum.text = "Quest:" +
            "\n" + ratCountDead + "  /  " + 2 + " RatAssasin" +
            "\n" + lizardCountDead + "  /  " + 5 + " LizardWarrior" +
            "\n" + chestCountDead + "  /  " + 3 + " ChestMonster" +
            //"\n" + specterCountDead + "  /  " + 1 + " Specter" +
            //"\n" + knightCountDead + "  /  " + 0 + " BlackKnight" +
            //"\n" + crabCountDead + "  /  " + 0 + " CrabMonster" +
            "\n" + demonCountDead + "  /  " + 1 + " FlyingDemon" +
            "\n" + werewolfCountDead + "  /  " + 2 + " Werewolf" +
            //"\n" + beholderCountDead + "  /  " + 0 + " Beholder" +
            "\n" + "Rewards: \t" + "?  ?  ?";
        }
        if (großesCamp)
        {
            textRaum.text = "";
            textRaum.text = "Quest:" +
            "\n" + ratCountDead + "  /  " + 4 + " RatAssasin" +
            "\n" + lizardCountDead + "  /  " + 5 + " LizardWarrior" +
            "\n" + chestCountDead + "  /  " + 5 + " ChestMonster" +
            "\n" + specterCountDead + "  /  " + 2 + " Specter" +
            "\n" + knightCountDead + "  /  " + 2 + " BlackKnight" +
            //"\n" + crabCountDead + "  /  " + 0 + " CrabMonster" +
            "\n" + demonCountDead + "  /  " + 2 + " FlyingDemon" +
            "\n" + werewolfCountDead + "  /  " + 4 + " Werewolf" +
            //"\n" + beholderCountDead + "  /  " + 0 + " Beholder" +
            "\n" + "Rewards: \t" + "?  ?  ?";
        }
        if (island)
        {
            textRaum.text = "";
            textRaum.text = "Quest:" +
            //"\n" + ratCountDead + "  /  " + 4 + " RatAssasin" +
            //"\n" + lizardCountDead + "  /  " + 5 + " LizardWarrior" +
            //"\n" + chestCountDead + "  /  " + 5 + " ChestMonster" +
            "\n" + specterCountDead + "  /  " + 6 + " Specter" +
            //"\n" + knightCountDead + "  /  " + 2 + " BlackKnight" +
            "\n" + crabCountDead + "  /  " + 13 + " CrabMonster" +
            //"\n" + demonCountDead + "  /  " + 2 + " FlyingDemon" +
            "\n" + werewolfCountDead + "  /  " + 4 + " Werewolf" +
            //"\n" + beholderCountDead + "  /  " + 0 + " Beholder" +
            "\n" + "Rewards: \t" + "?  ?  ?";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!campDone)
                activateSound.Play(Player.instance.transform.position);
            deActivateMessge = false;
            activateMessge = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            deActivateMessge = true;
        }
    }
}
