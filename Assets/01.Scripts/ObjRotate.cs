using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    //���콺�� ȸ�� ����ġ ������ ����
    float mx;
    float my;

    //ȸ���ӷ�
    float rotSpeed = 150;

    //ȸ�����ɿ���
    public bool canRotH;
    public bool canRotV;
    void Start()
    {
        //���� ���ӿ�����Ʈ�� ������ mx, my�� ����
        mx = transform.localEulerAngles.x;
        my = transform.localEulerAngles.y;
    }

    void Update()
    {
        //���콺�� �������� �޾Ƽ�
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        //���콺�� ȸ�������� ������ �����ϰ�(����ϰ�)
        mx += v * rotSpeed * Time.deltaTime;        
        my += h * rotSpeed * Time.deltaTime;        

        //mx �ּҰ��� -60, �ִ밪�� 60���� ����
        mx = Mathf.Clamp(mx, -60, 60);
        //������ ȸ�������� ���ӿ�����Ʈ�� ������ ��������
        transform.localEulerAngles = new Vector3(-mx, my, 0);
    }
}
