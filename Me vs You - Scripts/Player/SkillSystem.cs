using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;

    [SerializeField] TMPro.TextMeshProUGUI skillPoint = null;

    [SerializeField] TMPro.TextMeshProUGUI strengthText = null;
    [SerializeField] TMPro.TextMeshProUGUI vitalityText = null;
    [SerializeField] TMPro.TextMeshProUGUI armorText = null;
    

    int strength = 10;
    public int vitality = 5;
    int armor = 1;

    public int skillableSkilPoints ;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        skillPoint.text = "Skill Points: " + skillableSkilPoints.ToString();
        strengthText.text = strength.ToString();
        vitalityText.text = vitality.ToString();
        armorText.text = armor.ToString();
    }

    public void AddStrength(int point)
    {
        if (skillableSkilPoints <= 0) return;

        skillableSkilPoints--;
        strength += point;
    }

    public void AddVitality(int point)
    {
        if (skillableSkilPoints <= 0) return;
        PlayerHealthBar.instance.AddContainer();
        skillableSkilPoints--;
        vitality += point;
    }

    public void AddArmor(int point)
    {
        if (skillableSkilPoints <= 0 || armor >= 25) return;

        skillableSkilPoints--;
        armor += point;
    }

    public void AddSkillPoints(int point)
    {
        skillableSkilPoints += point;
    }

    public int GetCurrentStrength()
    {
        return strength;
    }
    public int GetCurrentVitality()
    {
        return vitality;
    }
    public int GetCurrentArmor()
    {
        return armor;
    }

    public void Save()
    {
        ES3.Save("staerke", strength);
        ES3.Save("vita", vitality);
        ES3.Save("armor", armor);
        ES3.Save("currentSkillPoints", skillableSkilPoints);
    }

    public void Load()
    {
        int newStrength = ES3.Load("staerke", strength);
        strength = newStrength;

        int newVita = ES3.Load("vita", vitality);
        vitality = newVita;

        int newArmor = ES3.Load("armor", armor);
        armor = newArmor;

        int skillPoints = ES3.Load("currentSkillPoints", skillableSkilPoints);
        skillableSkilPoints = skillPoints;
    }
}
