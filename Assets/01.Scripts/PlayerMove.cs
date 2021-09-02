using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player 한테 애니메이션을 재생하도록 하고 싶다.
// 필요속성 : Animator 컴포넌트
public class PlayerMove : MonoBehaviour
{
    // 필요속성 : Animator 컴포넌트
    Animator anim;

    //속력
    public float speed = 5;
    //Character Controller
    CharacterController cc;

    //점프파워
    public float jumpPower = 5;
    //y속도
    public float yVelocity;
    //중력
    float gravity = -20;
    //점프횟수
    int jumpCount;
    //최대점프횟수
    public int maxJumpCount = 2;

    void Start()
    {  
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    bool isCrouch = false;
    void Update()
    {
        //A,D 키 입력
        float h = Input.GetAxis("Horizontal");
        //W,S 키 입력
        float v = Input.GetAxis("Vertical");

        // animation 재생
        anim.SetFloat("Speed", v * v);
        anim.SetFloat("Direction", h);
        
        // Crouch animation 재생
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            isCrouch = true;
            anim.SetBool("IsCrouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            isCrouch = false;
            anim.SetBool("IsCrouch", false);

            cc.height = 2;
            cc.center = Vector3.up;
        }

        // 만약 crouch 중이라면 
        if (isCrouch)
        {
            // 충돌체 크기를 애니메이션의 커브값을 가져와서 적용시키고 싶다.
            cc.height = anim.GetFloat("Height");
            cc.center = Vector3.up * cc.height / 2;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetLayerWeight(1, 1);
        }
        else
        {
        //    anim.SetLayerWeight(1, 0.5f);
        }


        //방향을 정하고
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;
        dir.Normalize();

        Jump(out dir.y);

        //그 방향으로 움직이자
        //P = P0 + vt
        cc.Move(dir * speed * Time.deltaTime);
    }
       

    void Jump(out float dirY)
    {
        //만약에 바닥에 닿아있다면
        if (cc.isGrounded)
        {
            //y속도를 0으로 한다.
            yVelocity = 0;
            //점프횟수를 0으로한다.
            jumpCount = 0;
        }

        //만약에 스페이스바("Jump")를 누르면
        if (Input.GetButtonDown("Jump"))
        {
            //점프횟수가 최대점프횟수 보다 작으면
            if(jumpCount < maxJumpCount)
            {
                //y속도를 jumpPower로한다.
                yVelocity = jumpPower;
                jumpCount++;
            }
        }

        //dirY 에 y속도를 넣는다
        dirY = yVelocity;
        //y속도를 중력만큼 더해준다
        yVelocity += gravity * Time.deltaTime;
    }

    
}
