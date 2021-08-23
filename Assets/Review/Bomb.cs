using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //������ٵ�
    Rigidbody rb;
    //���󰡴� ��
    public float power = 500;

    //����ȿ������
    public GameObject exploFactory;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //�ڽ��� �չ������� ���� �ش�
        rb.AddForce(transform.forward * power);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //����ȿ�����忡�� ����ȿ�� �����
        GameObject explo = Instantiate(exploFactory);
        //���� ����ȿ���� ���� ��ġ�� ���´�.
        explo.transform.position = transform.position;
        //3�ʵڿ� ����ȿ���� ����
        Destroy(explo, 3);

        //��(��ź)�� ��ġ���� �ݰ� 2�ȿ� ������ Collider�˻�
        Collider [] cols = Physics.OverlapSphere(transform.position, 5);
        for(int i = 0; i < cols.Length; i++)
        {
            if (cols[i].tag == "Obstacle")
            {
                Destroy(cols[i].gameObject);
            }
        }

        

        //���ڽ��� ����
        Destroy(gameObject);
    }
}
