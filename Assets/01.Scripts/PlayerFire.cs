using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� �߻��ư�� ������ Enemy �� ���߸�
// Enemy ���� �� �� �¾Ҿ�. ��� �˷��ְ� �ʹ�.
public class PlayerFire : MonoBehaviour
{
    public delegate void DEliminate();
    public DEliminate onEli;

    //�Ѿ˰���
    public GameObject bulletFactory;
    //�ѱ�
    public Transform firePos;   
    //����ȿ��
    public GameObject fragmentEft;

    void Start()
    {

    }

    void Update()
    {
        //���࿡ Fire1 ��ư�� ������
        if(Input.GetButtonDown("Fire1"))
        {
            //�Ѿ˰��忡�� �Ѿ��� �����.
            GameObject bullet = Instantiate(bulletFactory);
            //������� �Ѿ��� �չ����� �ѱ��� �չ������� ����
            bullet.transform.forward = firePos.forward;
            //������� �Ѿ��� �ѱ��� ���´�.
            bullet.transform.position = firePos.position;
        }

        //���࿡ Fire2 ��ư�� ������ (���콺������, ����alt)
        if(Input.GetButtonDown("Fire2"))
        {
            //ī�޶���ġ, ī�޶�չ��⿡�� �߻�Ǵ� Ray�� �����.
            Ray ray = new Ray(
                Camera.main.transform.position,
                Camera.main.transform.forward);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //������ġ�� ����
            RaycastHit hitInfo;
            //Ray�� �浹 �ϰ� ���� Layer
            int layerObs = 1 << LayerMask.NameToLayer("Obstacle");
            int layerWall = 1 << LayerMask.NameToLayer("Wall");
            int layer = 1 << LayerMask.NameToLayer("Player");

            //Ray�� �߻���Ѽ� ��򰡿� �ε����ٸ�
            if(Physics.Raycast(ray, out hitInfo, 100, ~layer))
            {
                //ȿ���� ������ġ�� ���´�
                fragmentEft.transform.position = hitInfo.point;

                //ȿ���� �չ����� �ε��� ���� ��������(Noraml����)�� �Ѵ�
                fragmentEft.transform.forward = hitInfo.normal;

                //���� ȿ������ ParticleSystem ������Ʈ ��������
                ParticleSystem ps = fragmentEft.GetComponent<ParticleSystem>();
                //������ ������Ʈ�� ����� Play����
                ps.Play();

                // ���� �༮�� Enemy ���
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy)
                {
                    // Enemy ���� �� �� �¾Ҿ�. ��� �˷��ְ� �ʹ�.
                    enemy.OnDamageProcess(ray.direction); 
                }
            }

            //AudioSource ������Ʈ ��������
            AudioSource audio = fragmentEft.GetComponent<AudioSource>();
            //������ ������Ʈ�� ����� Play����
            audio.Play();
        }

        // ���� Clear ��ư�� ������
        if (Input.GetButtonDown("Clear"))
        {
            // ���� �ִ� ��� Enemy �����ϱ�
            Eliminate();
        }
    }

    // ���� �ִ� ��� Enemy �����ϱ�
    private void Eliminate()
    {
        onEli();
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ////for(int i=0;i<enemies.Length;i++)
        ////{
        ////    Destroy(enemies[i]);
        ////}
        //foreach(GameObject enemy in enemies)
        //{
        //    Destroy(enemy);
        //}
    }
}
