using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerCombos : MonoBehaviour
{
    [SerializeField] VideoPlayer combo1Player = null;
    [SerializeField] VideoPlayer combo2Player = null;
    [SerializeField] VideoPlayer combo4Player = null;
    [SerializeField] VideoPlayer combo5Player = null;
    [SerializeField] VideoPlayer combo6Player = null;
    [SerializeField] VideoPlayer dodgePlayer = null;

    [SerializeField] RawImage textur1 = null;
    [SerializeField] RawImage textur2 = null;
    [SerializeField] RawImage textur4 = null;
    [SerializeField] RawImage textur5 = null;
    [SerializeField] RawImage textur6 = null;
    [SerializeField] RawImage dodge = null;

    void Start()
    {
        textur1.enabled = false;
        textur2.enabled = false;
        textur4.enabled = false;
        textur5.enabled = false;
        textur6.enabled = false;
        dodge.enabled = false;

        combo1Player.enabled = false;
        combo2Player.enabled = false;
        combo4Player.enabled = false;
        combo5Player.enabled = false;
        combo6Player.enabled = false;
        dodgePlayer.enabled = false;
    }

    public void Combo1Button()
    {
        textur1.enabled = true;
        textur2.enabled = false;
        textur4.enabled = false;
        textur5.enabled = false;
        textur6.enabled = false;
        dodge.enabled = false;

        //combo1Player.Stop();
        combo1Player.Play();
    }
    public void Combo2Button()
    {
        textur1.enabled = false;
        textur2.enabled = true;
        textur4.enabled = false;
        textur5.enabled = false;
        textur6.enabled = false;
        dodge.enabled = false;


        //combo2Player.Stop();
        combo2Player.Play();
    }
    public void Combo4Button()
    {
        textur1.enabled = false;
        textur2.enabled = false;
        textur4.enabled = true;
        textur5.enabled = false;
        textur6.enabled = false;
        dodge.enabled = false;

        //combo4Player.Stop();
        combo4Player.Play();
    }
    public void Combo5Button()
    {
        textur1.enabled = false;
        textur2.enabled = false;
        textur4.enabled = false;
        textur5.enabled = true;
        textur6.enabled = false;
        dodge.enabled = false;

        //combo5Player.Stop();
        combo5Player.Play();
    }
    public void Combo6Button()
    {
        textur1.enabled = false;
        textur2.enabled = false;
        textur4.enabled = false;
        textur5.enabled = false;
        textur6.enabled = true;
        dodge.enabled = false;

        //combo6Player.Stop();
        combo6Player.Play();
    }
    public void DodgeButton()
    {
        textur1.enabled = false;
        textur2.enabled = false;
        textur4.enabled = false;
        textur5.enabled = false;
        textur6.enabled = false;
        dodge.enabled = true;

        //dodgePlayer.Stop();
        dodgePlayer.Play();
    }

    public void EnableCombo1()
    {
        combo1Player.enabled = true;
        combo2Player.enabled = false;
        combo4Player.enabled = false;
        combo5Player.enabled = false;
        combo6Player.enabled = false;
        dodgePlayer.enabled = false;
    }

    public void EnableCombo2()
    {
        combo1Player.enabled = false;
        combo2Player.enabled = true;
        combo4Player.enabled = false;
        combo5Player.enabled = false;
        combo6Player.enabled = false;
        dodgePlayer.enabled = false;
    }

    public void EnableCombo4()
    {
        combo1Player.enabled = false;
        combo2Player.enabled = false;
        combo4Player.enabled = true;
        combo5Player.enabled = false;
        combo6Player.enabled = false;
        dodgePlayer.enabled = false;
    }

    public void EnableCombo5()
    {
        combo1Player.enabled = false;
        combo2Player.enabled = false;
        combo4Player.enabled = false;
        combo5Player.enabled = true;
        combo6Player.enabled = false;
        dodgePlayer.enabled = false;
    }

    public void EnableCombo6()
    {
        combo1Player.enabled = false;
        combo2Player.enabled = false;
        combo4Player.enabled = false;
        combo5Player.enabled = false;
        combo6Player.enabled = true;
        dodgePlayer.enabled = false;
    }

    public void EnableDodge()
    {
        combo1Player.enabled = false;
        combo2Player.enabled = false;
        combo4Player.enabled = false;
        combo5Player.enabled = false;
        combo6Player.enabled = false;
        dodgePlayer.enabled = true;
    }

    private void Update()
    {
        if(IngameUIHandler.instance.menuCount != 1)
        {
            textur1.enabled = false;
            textur2.enabled = false;
            textur4.enabled = false;
            textur5.enabled = false;
            textur6.enabled = false;
            dodge.enabled = false;

            combo1Player.enabled = false;
            combo2Player.enabled = false;
            combo4Player.enabled = false;
            combo5Player.enabled = false;
            combo6Player.enabled = false;
            dodgePlayer.enabled = false;
        }
    }
}
