using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHit : MonoBehaviour
{
    float timerToGetDamage = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timerToGetDamage += Time.deltaTime;

            DoDamage(1f);
        }
    }

    void DoDamage(float attackDamage)
    {
        if (timerToGetDamage > .3f)
        {
            if (!Player.instance.currentlyDodging)
            {
                timerToGetDamage = 0;

                float damage;

                if (SkillSystem.instance.GetCurrentArmor() == 1)
                {
                    damage = 0;
                }
                else
                {

                    damage = SkillSystem.instance.GetCurrentArmor() / 25f;
                }

                float calculatedDamage = attackDamage - damage;
                //Debug.Log(calculatedDamage);
                if (calculatedDamage > 0)
                {
                    PlayerHealthBar.instance.RemoveHearts(calculatedDamage);
                }
                else
                {
                    PlayerHealthBar.instance.RemoveHearts(0.35f);
                }
            }
        }


    }
}
