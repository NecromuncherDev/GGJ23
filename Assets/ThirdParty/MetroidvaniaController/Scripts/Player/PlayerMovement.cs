using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    private PlatformDelta curPlatform;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove == 0)
        {
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            curPlatform = null;
            jump = true;
        }

        if (curPlatform != null)
        {
            transform.position += curPlatform.delta;
        }
    }

    public void OnFall()
    {
        animator.SetBool("IsJumping", true);
    }

    public void OnGround()
    {
        var platform = controller.lastGround.GetComponent<PlatformDelta>();
        if (platform != null)
            curPlatform = platform;
        else
            curPlatform = null;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
        jump = false;
        dash = false;
    }
}
