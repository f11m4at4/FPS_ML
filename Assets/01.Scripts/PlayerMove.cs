using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player ���� �ִϸ��̼��� ����ϵ��� �ϰ� �ʹ�.
// �ʿ�Ӽ� : Animator ������Ʈ
public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ� : Animator ������Ʈ
    Animator anim;

    //�ӷ�
    public float speed = 5;
    //Character Controller
    CharacterController cc;

    //�����Ŀ�
    public float jumpPower = 5;
    //y�ӵ�
    public float yVelocity;
    //�߷�
    float gravity = -20;
    //����Ƚ��
    int jumpCount;
    //�ִ�����Ƚ��
    public int maxJumpCount = 2;

    void Start()
    {  
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    bool isCrouch = false;
    void Update()
    {
        //A,D Ű �Է�
        float h = Input.GetAxis("Horizontal");
        //W,S Ű �Է�
        float v = Input.GetAxis("Vertical");

        // animation ���
        anim.SetFloat("Speed", v * v);
        anim.SetFloat("Direction", h);
        
        // Crouch animation ���
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

        // ���� crouch ���̶�� 
        if (isCrouch)
        {
            // �浹ü ũ�⸦ �ִϸ��̼��� Ŀ�갪�� �����ͼ� �����Ű�� �ʹ�.
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


        //������ ���ϰ�
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;
        dir.Normalize();

        Jump(out dir.y);

        //�� �������� ��������
        //P = P0 + vt
        cc.Move(dir * speed * Time.deltaTime);
    }
       

    void Jump(out float dirY)
    {
        //���࿡ �ٴڿ� ����ִٸ�
        if (cc.isGrounded)
        {
            //y�ӵ��� 0���� �Ѵ�.
            yVelocity = 0;
            //����Ƚ���� 0�����Ѵ�.
            jumpCount = 0;
        }

        //���࿡ �����̽���("Jump")�� ������
        if (Input.GetButtonDown("Jump"))
        {
            //����Ƚ���� �ִ�����Ƚ�� ���� ������
            if(jumpCount < maxJumpCount)
            {
                //y�ӵ��� jumpPower���Ѵ�.
                yVelocity = jumpPower;
                jumpCount++;
            }
        }

        //dirY �� y�ӵ��� �ִ´�
        dirY = yVelocity;
        //y�ӵ��� �߷¸�ŭ �����ش�
        yVelocity += gravity * Time.deltaTime;
    }

    
}
