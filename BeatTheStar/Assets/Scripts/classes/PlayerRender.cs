using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : MonoBehaviour
{
    PlayerAction playerAction;
    SpriteRenderer playerSpriteRenderer;
    private void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAction = GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
    }

    private void Flip()
    {
        bool hClick = playerAction.hStay || playerAction.hDown;

        if (hClick && playerAction.h < 0)
            playerSpriteRenderer.flipX = true;
        else if (hClick && playerAction.h >= 0)
            playerSpriteRenderer.flipX = false;
    }
}
