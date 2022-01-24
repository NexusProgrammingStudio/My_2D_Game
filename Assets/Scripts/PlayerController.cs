﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator m_Animator;
    Rigidbody2D m_RigidBody2D;
    Vector3 Pscale,Ppos;
    float Pspeed,Pjump;
    float horizontal,vertical;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_RigidBody2D = gameObject.GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");        

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical);
    }

    public void MoveCharacter(float horizontal, float vertical)
    {
        Ppos = transform.position;
        Ppos.x += horizontal * Time.deltaTime;
        transform.position = Ppos;

        if (vertical > 0)
        {
            m_RigidBody2D.AddForce(new Vector2(0f, 25), ForceMode2D.Force);
        }
    }

    public void PlayerMovementAnimation(float horizontal, float vertical)
    {
        m_Animator.SetFloat("Speed",Mathf.Abs(horizontal));
        Pscale = transform.localScale;
        Ppos = transform.localPosition;
        if(horizontal < 0)
        {
            Pscale.x = -1f * Mathf.Abs(Pscale.x);
            Ppos.x = -0.1f + Ppos.x;
        }
        else if (horizontal > 0)
        {
            Pscale.x = 1f * Mathf.Abs(Pscale.x);
            Ppos.x = 0.1f + Ppos.x;
        }
        transform.localScale = Pscale;
        transform.localPosition = Ppos;

        if(vertical > 0)
        {
            m_Animator.SetTrigger("Jump_trigger");

            m_Animator.ResetTrigger("Crouch_Trigger");

            
        }
        else if(vertical < 0)
        {
            m_Animator.SetTrigger("Crouch_Trigger");

            m_Animator.ResetTrigger("Jump_trigger");
        }
    }
}