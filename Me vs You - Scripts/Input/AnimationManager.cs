using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator anim;
    PlayerMovement movement;
    CharacterController controller;

    void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        controller = GetComponent<CharacterController>();
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting, bool useRootMotion = false)
    {
        anim.SetBool("isInteracting", isInteracting);
        anim.SetBool("isUsingRootMotion", useRootMotion);
        anim.CrossFade(targetAnimation, 0.2f);
    }
}
