﻿// PlayerControl.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    private float power;
    public float POWERPLUS = 300.0f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        { // 왼쪽 버튼이 눌려있는 동안
            power += POWERPLUS * Time.deltaTime; // 힘을 비축
        }
        if (Input.GetMouseButtonUp(0))
        { // 왼쪽 버튼을 놓으면
          // 비축한 힘을 x와 y에 반영해서 오른쪽 위로 점프!
            this.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
            power = 0.0f; // 힘을 0으로
        }
        // 지면보다 아래(-5.0f)로 떨어지면
        if (this.transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("Main"); // 씬을 다시 로드
        }
    }
}