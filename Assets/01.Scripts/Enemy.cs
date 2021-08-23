using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �⺻ ����(����)�� �����ϰ� �ʹ�.
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

    private void Move()
    {
        throw new NotImplementedException();
    }

    
}
