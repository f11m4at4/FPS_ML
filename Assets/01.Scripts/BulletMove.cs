using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //�ӷ�
    public float speed = 10;
    //Rigidbody
    Rigidbody rb;
    //�Ŀ�
    public float power = 100;
    //���߰���
    public GameObject exploFactory;
    //�ݰ�
    public float exploRange = 4;

    void Start()
    {
        //RIgidbody ������ ��������
        rb = GetComponent<Rigidbody>();
        //�Ѿ��� �չ������� ���� �ش�
        rb.AddForce(transform.forward * power);
    }

    void Update()
    {
        //��� �ڱ��ڽ��� ������ �̵��ϰ� �ʹ�.
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        //���߰��忡�� ����ȿ���� �����.
        GameObject explo = Instantiate(exploFactory);
        //������� ������ ������ġ�� ���´�.
        explo.transform.position = transform.position;
        //������� ������ 3�ʵڿ� ����
        Destroy(explo, 3);

        //�ݰ�ȿ� ���� ��ֹ� �ı� üũ
        //ObstacleMgr.instance.CheckExplo(transform.position, exploRange);

        Collider [] cols = Physics.OverlapSphere(transform.position, exploRange);
        for(int i = 0; i < cols.Length; i++)
        {
            if(cols[i].gameObject.tag == "Obstacle")
            {
                Destroy(cols[i].gameObject);
            }
        }
        

        ////���࿡ �ε������� tag�� Obstacle�̸�
        //if(other.gameObject.tag == "Obstacle")
        //{
        //    //�ε����� �ı�
        //    Destroy(other.gameObject);
        //}

        Destroy(gameObject);
    }
}
