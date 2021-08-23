using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �⺻ ����(����)�� �����ϰ� �ʹ�.

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour
{
    // ������
    enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damage,
        Die
    }

    EnemyState m_state = EnemyState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        // CharacterController ��������
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        print("������� : " + m_state);
        // ���� �⺻ ����(����)�� �����ϰ� �ʹ�.
        // ���� ���� ���°� Idle �̶��
        switch(m_state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damage:
                Damage();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
    }


    // �����ð��� ������ ���¸� Move �� ��ȯ�ϰ� �ʹ�.
    // �ʿ�Ӽ� : ���ð�, ����ð�
    public float idleDelayTime = 2;
    float currentTime;
    private void Idle()
    {
        // �����ð��� ������ ���¸� Move �� ��ȯ�ϰ� �ʹ�.
        // 1. �ð��� �귶���ϱ�
        currentTime += Time.deltaTime;
        // 2. �����ð��� ��������
        // -> ���� ����ð��� ���ð��� �ʰ��Ͽ��ٸ�
        if (currentTime > idleDelayTime)
        {
            // 3. ���¸� Move �� ��ȯ�ϰ� �ʹ�.
            m_state = EnemyState.Move;
            currentTime = 0;
        }
    }

    // 1. Ÿ�������� �̵��ϰ� �ʹ�.
    // �ʿ�Ӽ� : Ÿ��, �̵� �ӵ�
    // 2. Ÿ�������� ȸ���ϰ� �ʹ�.
    // �ʿ�Ӽ� : ȸ���ӵ�
    public GameObject target;
    public float speed = 5;
    CharacterController cc;
    public float rotSpeed = 5;
    private void Move()
    {
        // Ÿ�������� �̵��ϰ� �ʹ�.
        // 1. ������ �ʿ�
        // -> direction = target - me
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        dir.y = 0;
        // 2. �̵��ϰ� �ʹ�.
        // -> P = P0 + vt
        cc.SimpleMove(dir * speed);
        // Ÿ�������� ȸ���ϰ� �ʹ�.
        // transform.LookAt(target.transform);
        //transform.forward = dir;
        // -> �ε巴�� ȸ���ϰ� �ʹ�.
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
       // transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    private void Damage()
    {
        throw new NotImplementedException();
    }

    private void Attack()
    {
        throw new NotImplementedException();
    }

    

    
}