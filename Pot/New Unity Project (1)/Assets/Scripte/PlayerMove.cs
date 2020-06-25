﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float Rspeed = 150; //회전속도 
    public float JumpPower = 10;
    Rigidbody rigid;
    Animator anim;
    //회전각도를 직접 제어
    float angleX;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Attack();
        Jump();
    }

    private void Jump()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }

    }

    private void Attack()
    {
      if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Attack");
        }
       
    }

    private void Rotate()
    {
        float h = Input.GetAxis("Mouse X");
        angleX += h * Rspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, angleX, 0);
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        transform.Translate(dir* speed * Time.deltaTime);
        
        if(h==0&&v==0)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", true);
        }
    }
}
