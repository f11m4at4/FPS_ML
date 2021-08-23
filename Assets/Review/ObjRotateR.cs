using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotateR : MonoBehaviour
{
    //ȸ���ӷ�
    public float rotSpeed = 200;
    //���� ���� ��
    float mx;
    float my;
    //ȸ�� ���� ����
    public bool canRotH;
    public bool canRotV;
    
    void Start()
    {
        //ó�� ������ mx, my�� ����
        mx = transform.localEulerAngles.x;
        my = transform.localEulerAngles.y;
    }

    void Update()
    {
        //���콺�� �������� ���� �޴´�.
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        //���콺�� �����ӿ� ���� ������ ������Ų��.
        if(canRotH) my += h * rotSpeed * Time.deltaTime;
        if(canRotV) mx += v * rotSpeed * Time.deltaTime;

        //-60 < mx < 60
        mx = Mathf.Clamp(mx, -60, 60);
        
        //������ ������ ���� ���ӿ�����Ʈ ������ �����Ѵ�
        transform.localEulerAngles = new Vector3(-mx, my, 0);
    }
}
