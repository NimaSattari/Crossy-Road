using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public PlayerController playerController = null;
    private Animator animator = null;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        if (playerController.isDead)
        {
            animator.SetBool("Dead", true);
        }
        if (playerController.jumpStart)
        {
            animator.SetBool("JumpStart", true);
        }
        else if (playerController.isJumping)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("JumpStart", false);
        }
    }
}