using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    [SerializeField] bool loadPos;
    [SerializeField] bool autoSave = true;
    [SerializeField] CanvasGroup text;


    bool starte;
    public float timer = 0;

    private void Awake()
    {
        instance = this;
        text.alpha = 0;
    }

    private void Start()
    {
        LoadGame();

        if(loadPos)
            LoadPos();
    }

    void Update()
    {
        if(autoSave)
            timer += Time.deltaTime;

        if(timer >= 180f)
        {
            SaveGame();
            SavePos();
            starte = true;
            timer = 0;
        }

        if (starte)
        {
            text.alpha = Mathf.Lerp(text.alpha, 1, Time.deltaTime * 3f);
            if (timer >= 3f) starte = false;
        }
        else
        {
            text.alpha = Mathf.Lerp(text.alpha, 0, Time.deltaTime * 3f);
        }
    }

    public void SaveGame()
    {
        ES3AutoSaveMgr.Current.Save();

        LevelSystem.instance.Save();
        SkillSystem.instance.Save();
        PlayerHealthBar.instance.Save();
    }

    public void LoadGame()
    {
        ES3AutoSaveMgr.Current.Load();
        LevelSystem.instance.Load();
        SkillSystem.instance.Load();
        PlayerHealthBar.instance.Load();
    }

    public void SavePos()
    {
        Player.instance.SavePos();
    }

    public void LoadPos()
    {
        Player.instance.LoadPos();
    }
}
