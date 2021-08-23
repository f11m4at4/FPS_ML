using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveR : MonoBehaviour
{
    //�ӷ�
    public float speed = 5;

    //character controller
    CharacterController cc;

    //�����Ŀ�
    public float jumpPower = 5;
    //y�ӵ�
    float yVelocity;
    //�߷�
    float gravity = -20;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //A,D �Է��� ����
        float h = Input.GetAxis("Horizontal");
        //W,S �Է��� ����
        float v = Input.GetAxis("Vertical");

        //�Է� ���� ���� �̿��� ������ ���ϰ�
        Vector3 dirH = transform.right * h;
        Vector3 dirV = transform.forward * v;
        Vector3 dir = dirH + dirV;
        dir.Normalize();

        //���࿡ ���� ����ִٸ�
        if(cc.isGrounded)
        {
            //y�ӵ��� 0���� ����
            yVelocity = 0;
        }

        //���࿡ Space�ٸ� ������
        if(Input.GetButtonDown("Jump"))
        {
            //y�ӵ��� �����Ŀ����� ����
            yVelocity = jumpPower;
        }

        //dir.y�� y�ӵ��� ����
        dir.y = yVelocity;
        //v�ӵ��� �߷¿� ���� ����
        yVelocity += gravity * Time.deltaTime;

        //�� �������� �������� 
        cc.Move(dir * speed * Time.deltaTime);
    }
}
