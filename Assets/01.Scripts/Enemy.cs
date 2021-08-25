using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적의 기본 상태(목차)를 구성하고 싶다.
// 1. hp 를 갖고 싶다.
// 2. 맞으면 상태를 피격으로 전환하고 싶다.
// 3. hp 가 0 이하면 없애고 싶다.

// 적이 각 상태에서 애니메이션이 재생되도록 하고싶다.
// 1. Idle -> Move 애니메이션이 전환되도록 하고 싶다.
// 필요속성 : Animator 컴포넌트
[RequireComponent(typeof(CharacterController))]
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

    public int hp = 3;

    // 필요속성 : Animator 컴포넌트
    Animator anim;

    void Start()
    {
        // CharacterController 가져오기
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
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
            // Animation 상태도 Move 로 전환하고 싶다.
            anim.SetTrigger("Move");
            currentTime = 0;
        }
    }

    // 1. 타겟쪽으로 이동하고 싶다.
    // 필요속성 : 타겟, 이동 속도
    // 2. 타겟쪽으로 회전하고 싶다.
    // 필요속성 : 회전속도
    public GameObject target;
    public float speed = 5;
    CharacterController cc;
    public float rotSpeed = 5;
    // 필요속성 : 공격범위
    public float attackRange = 2;
    private void Move()
    {
        // 타겟쪽으로 이동하고 싶다.
        // 1. 방향이 필요
        // -> direction = target - me
        Vector3 dir = target.transform.position - transform.position;
        float distance = dir.magnitude;

        dir.Normalize();
        dir.y = 0;
        // 2. 이동하고 싶다.
        // -> P = P0 + vt
        cc.SimpleMove(dir * speed);
        // 타겟쪽으로 회전하고 싶다.
        // transform.LookAt(target.transform);
        //transform.forward = dir;
        // -> 부드럽게 회전하고 싶다.
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
        // transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);

        // 공격범위안에 들어가면 상태를 공격으로 전환하고 싶다.
        // 1. 공격범위 안에 들어왔으니까
        // -> 만약 상대와의 거리가 공격범위 보다 작으면
        //float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < attackRange)
        {
            // 2. 상태를 공격으로 전환하고 싶다.
            m_state = EnemyState.Attack;
        }
    }

    // 일정시간에 한번씩 공격하고 싶다.
    // 필요속성 : 공격대기시간
    public float attackDelayTime = 2;
    private void Attack()
    {
        // 일정시간에 한번씩 공격하고 싶다.
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 공격시간이 됐으니까
        // -> 만약 경과시간이 공격대기시간을 초과하였다면
        if (currentTime > attackDelayTime)
        {
            // 3. 공격하고 싶다. (print)
            print("Attack");
            currentTime = 0;
        }

        // 타겟이 공격 범위를 벗어나면 상태를 Move 로 전환하고 싶다.
        // 1. 타겟이 공격 범위를 벗어났으니까
        // -> 만약 타겟과의 거리가 공격 범위를 초과 했다면
        // -> 필요정보 : 타겟과의 거리
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > attackRange)
        {
            // 2. 상태를 Move 로 전환하고 싶다.
            m_state = EnemyState.Move;
        }

    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    // 일정시간 기다렸다가 상태를 Idle 로 전환하고 싶다.
    // 필요속성 : damage 대기시간
    public float damageDelayTime = 2;
    private void Damage()
    {
        currentTime += Time.deltaTime;
        if (currentTime > damageDelayTime)
        {
            // 일정시간 기다렸다가 상태를 Idle 로 전환하고 싶다.
            m_state = EnemyState.Idle;
            currentTime = 0;
        }
    }
    
    // 플레이어로부터 피격 받았을때 처리할 함수
    public void OnDamageProcess(Vector3 shootDirection)
    {
        hp--;
        // 1. hp 가 0 이하면 없애고 싶다.
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        // 2. 맞으면 상태를 피격으로 전환하고 싶다.
        else
        {
            // 넉백 knockback
            // 밀릴 방향
            // P = P0 + vt
            shootDirection.y = 0;
            transform.position += shootDirection * 2;
            m_state = EnemyState.Damage;
        }
    }
}
