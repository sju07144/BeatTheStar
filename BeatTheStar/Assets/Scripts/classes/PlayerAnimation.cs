using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IAnimatable
{
    Animator playerAnimator;
    PlayerAction playerAction;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerAction = GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        playerAnimator.SetInteger("horizontal", (int)playerAction.h);
        playerAnimator.SetBool("isJump", playerAction.isJump);
    }
}
