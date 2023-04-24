using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    [SerializeField] Combo[] combo;

    //Queue<Combo> combos = new Queue<Combo>();
    
    PlayerMovement movement;
    AnimationManager manager;
    new AudioManager audio;
    Animator anim;

    Combo currentCombo;

    //float timer = Mathf.Infinity;

    bool isInteracting;
    bool isUsingRootMotion;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        manager = GetComponent<AnimationManager>();
        audio = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
       // combo.currentIndex = 0;
       // currentCombo = combo;
    }

    void Update()
    {

        ApplyRootMotion();


        //timer += Time.deltaTime;

       // if(timer > .5f)
       //     Combo();

    }

    private void ApplyRootMotion()
    {
        if (isUsingRootMotion)
            anim.applyRootMotion = true;
        else
            anim.applyRootMotion = false;
    }

    void LateUpdate()
    {
        isInteracting = anim.GetBool("isInteracting");
        isUsingRootMotion = anim.GetBool("isUsingRootMotion");
    }

    private void Combo()
    {

       // for (int i = 0; i < currentCombo.animationCount; i++)
       // {
       //     if (currentCombo.currentIndex == i && currentCombo.keycodeIndex[i].GetButtonDown())
       //     {
       //         currentCombo.currentIndex++;
       //         //timer = 0;
       //         manager.PlayTargetAnimation(currentCombo.animationName[i], true, true);
       //         audio.Play("Swing");
       //         i++;
       //     }
       // }
    }

    void StopCombo()
    {
        //currentC-ombo.currentIndex = 0;
        //currentCombo.currentComboIndex = 0;
    }
}
