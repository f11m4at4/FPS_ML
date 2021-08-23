using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveR : MonoBehaviour
{
    //속력
    public float speed = 5;

    //character controller
    CharacterController cc;

    //점프파워
    public float jumpPower = 5;
    //y속도
    float yVelocity;
    //중력
    float gravity = -20;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //A,D 입력을 받자
        float h = Input.GetAxis("Horizontal");
        //W,S 입력을 받자
        float v = Input.GetAxis("Vertical");

        //입력 받은 값을 이용해 방향을 정하고
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;
        dir.Normalize();

        //만약에 땅과 닿아있다면
        if(cc.isGrounded)
        {
            //y속도를 0으로 셋팅
            yVelocity = 0;
        }

        //만약에 Space바를 누르면
        if(Input.GetButtonDown("Jump"))
        {
            //y속도에 점프파워값을 셋팅
            yVelocity = jumpPower;
        }

        //dir.y에 y속도를 셋팅
        dir.y = yVelocity;
        //v속도를 중력에 의해 감소
        yVelocity += gravity * Time.deltaTime;

        //그 방향으로 움직이자 
        cc.Move(dir * speed * Time.deltaTime);
    }
}
