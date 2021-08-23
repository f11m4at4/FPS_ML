using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적의 기본 상태(목차)를 구성하고 싶다.
public class Enemy : MonoBehaviour
{
    // 열거형
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
        print("현재상태 : " + m_state);
        // 적의 기본 상태(목차)를 구성하고 싶다.
        // 만약 적의 상태가 Idle 이라면
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


    // 일정시간이 지나면 상태를 Move 로 전환하고 싶다.
    // 필요속성 : 대기시간, 경과시간
    public float idleDelayTime = 2;
    float currentTime;
    private void Idle()
    {
        // 일정시간이 지나면 상태를 Move 로 전환하고 싶다.
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 일정시간이 지났으까
        // -> 만약 경과시간이 대기시간을 초과하였다면
        if (currentTime > idleDelayTime)
        {
            // 3. 상태를 Move 로 전환하고 싶다.
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
