using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireR : MonoBehaviour
{
    //��ź����
    public GameObject bombFactory;
    //�߻���ġ
    public Transform firePos;
    void Start()
    {
        
    }

    void Update()
    {
        //Fire1 ��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            //��ź���忡�� ��ź�� ������
            GameObject bomb = Instantiate(bombFactory);
            //���� ��ź�� �չ����� �߻���ġ�� �չ������� ����
            bomb.transform.forward = firePos.forward;
            //���� ��ź�� ��ġ�� �߻���ġ�� ����
            bomb.transform.position = firePos.position;
        }
    }
}
