using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject portal;

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;
    private bool portalActive = false;
    [SerializeField]     private Vector3 offset;

    //bool dashAxis = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove == 0)
        {
            animator.SetBool("Walking", false);
        } else
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!portalActive)
            {
                InstantiatePortal();
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
                InstantiatePortal();
           

        }

        /*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

    }

    private void InstantiatePortal()
    {
        var instance = Instantiate(portal, transform.position + (transform.localScale.x * offset), Quaternion.identity); 
        Debug.Log(instance.transform.position );
        portalActive = true;
    }

    public void OnFall()
    {
        animator.SetBool("IsJumping", true);
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
