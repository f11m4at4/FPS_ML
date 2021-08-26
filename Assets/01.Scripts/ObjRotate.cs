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
-
    // ����ũ��
    public float amp = 1;
    public float freq = 2;
    float tempY;
    void Start()
    {
        tempY = transform.localPosition.y;
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
        if(canRotV)
            mx += v * rotSpeed * Time.deltaTime;
        if (canRotH) 
            my += h * rotSpeed * Time.deltaTime;        

        //mx �ּҰ��� -60, �ִ밪�� 60���� ����
        mx = Mathf.Clamp(mx, -60, 60);
        //������ ȸ�������� ���ӿ�����Ʈ�� ������ ��������
        transform.localEulerAngles = new Vector3(-mx, my, 0);

        // ���� ī�޶��� 
        if (gameObject.tag == "MainCamera")
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                transform.localPosition = new Vector3(0, tempY + amp * Mathf.Sin(freq * Time.time), 0);
            }
        }
    }
}
