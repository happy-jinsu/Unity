﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public int JumpPower;
    public bool IsJumping;
    int HP;
    public float time;
    bool touch;

    // 처음 한번만 실행 되는 함수
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        IsJumping = false;
        HP = 3;
        touch = false;
        time = 0;
    }
    // 매 frame마다 실행 되는 함수
    void Update()
    {
        Jump();

        if (touch == true)
        {
            time += Time.deltaTime;


            if (Input.GetKey(KeyCode.LeftArrow))  //왼쪽
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))  //오른쪽
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
            }

            if (time > 3f)
            {
                touch = false;
            }
        }

        else   // 원래
        {
            if (Input.GetKey(KeyCode.LeftArrow))  //왼쪽
            {
                this.transform.Translate(-0.1f, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))  //오른쪽
            {
                this.transform.Translate(0.1f, 0.0f, 0.0f);
            }
        }

    }

    void Jump()
    {
   
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!IsJumping)     //땅에 닿았을 때만 다시 점프 가능
            {
                IsJumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }

            else
            {
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)       // 땅에 닿지 않으면 점프 불가
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            HP--;                                              // 체력이 0이되면 End씬 로드
            if(HP == 0)
            {
                SceneManager.LoadScene("End");
            }
        }



        if (collision.gameObject.CompareTag("ObstaclesMoveChange"))
        {
            HP--;                                              // 체력이 0이되면 End씬 로드
            if (HP == 0)
            {
                SceneManager.LoadScene("End");
            }

            touch = true;
            time = 0;
           
        }

    }
}