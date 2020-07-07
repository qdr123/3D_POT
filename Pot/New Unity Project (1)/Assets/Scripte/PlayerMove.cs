using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float Rspeed = 150; //회전속도 
    public float JumpPower = 4;
    public float hp = 100; //체력
    public float iniHp = 100; //최대체력
    bool jump = false;
    
    Rigidbody rigid;
    Animator anim;
    //회전각도를 직접 제어
    float angleX;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jump)
            {
                anim.SetTrigger("Jump");
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
                jump = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 5;
            Debug.Log(hp);
            if(hp<=0)
            {
               // anim.SetBool("Die", true);
            }
        }
    }

    private void Attack()
    {
      if(Input.GetKeyDown(KeyCode.Mouse0))
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
