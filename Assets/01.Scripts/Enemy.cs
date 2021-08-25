using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �⺻ ����(����)�� �����ϰ� �ʹ�.
// 1. hp �� ���� �ʹ�.
// 2. ������ ���¸� �ǰ����� ��ȯ�ϰ� �ʹ�.
// 3. hp �� 0 ���ϸ� ���ְ� �ʹ�.

// ���� �� ���¿��� �ִϸ��̼��� ����ǵ��� �ϰ�ʹ�.
// 1. Idle -> Move �ִϸ��̼��� ��ȯ�ǵ��� �ϰ� �ʹ�.
// �ʿ�Ӽ� : Animator ������Ʈ
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

    public int hp = 3;

    // �ʿ�Ӽ� : Animator ������Ʈ
    Animator anim;

    void Start()
    {
        // CharacterController ��������
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
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
            //case EnemyState.Damage:
            //    Damage();
            //    break;
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
            // Animation ���µ� Move �� ��ȯ�ϰ� �ʹ�.
            anim.SetTrigger("Move");
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
    // �ʿ�Ӽ� : ���ݹ���
    public float attackRange = 2;
    private void Move()
    {
        // Ÿ�������� �̵��ϰ� �ʹ�.
        // 1. ������ �ʿ�
        // -> direction = target - me
        Vector3 dir = target.transform.position - transform.position;
        float distance = dir.magnitude;

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

        // ���ݹ����ȿ� ���� ���¸� �������� ��ȯ�ϰ� �ʹ�.
        // 1. ���ݹ��� �ȿ� �������ϱ�
        // -> ���� ������ �Ÿ��� ���ݹ��� ���� ������
        //float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < attackRange)
        {
            // 2. ���¸� �������� ��ȯ�ϰ� �ʹ�.
            m_state = EnemyState.Attack;
            currentTime = attackDelayTime;
        }
    }

    // �����ð��� �ѹ��� �����ϰ� �ʹ�.
    // �ʿ�Ӽ� : ���ݴ��ð�
    public float attackDelayTime = 2;
    private void Attack()
    {
        // �����ð��� �ѹ��� �����ϰ� �ʹ�.
        // 1. �ð��� �귶���ϱ�
        currentTime += Time.deltaTime;
        // 2. ���ݽð��� �����ϱ�
        // -> ���� ����ð��� ���ݴ��ð��� �ʰ��Ͽ��ٸ�
        if (currentTime > attackDelayTime)
        {
            // 3. �����ϰ� �ʹ�. (print)
            anim.SetTrigger("Attack");
            currentTime = 0;
        }

        // Ÿ���� ���� ������ ����� ���¸� Move �� ��ȯ�ϰ� �ʹ�.
        // 1. Ÿ���� ���� ������ ������ϱ�
        // -> ���� Ÿ�ٰ��� �Ÿ��� ���� ������ �ʰ� �ߴٸ�
        // -> �ʿ����� : Ÿ�ٰ��� �Ÿ�
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > attackRange)
        {
            // 2. ���¸� Move �� ��ȯ�ϰ� �ʹ�.
            m_state = EnemyState.Move;
            anim.SetTrigger("Move");
        }

    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    // �����ð� ��ٷȴٰ� ���¸� Idle �� ��ȯ�ϰ� �ʹ�.
    // �ʿ�Ӽ� : damage ���ð�
    public float damageDelayTime = 2;
    private IEnumerator Damage(Vector3 shootDirection)
    {
        shootDirection.y = 0;
        transform.position += shootDirection * 2;
        m_state = EnemyState.Damage;
        // animation �� ���¸� �ǰ�����
        anim.SetTrigger("Damage");

        // ���ð� ��ŭ ��ٷȴٰ� 
        yield return new WaitForSeconds(damageDelayTime);
        // ���¸� Idle �� ��ȯ
        m_state = EnemyState.Idle;

        //currentTime += Time.deltaTime;
        //if (currentTime > damageDelayTime)
        //{
        //    // �����ð� ��ٷȴٰ� ���¸� Idle �� ��ȯ�ϰ� �ʹ�.
        //    m_state = EnemyState.Idle;
        //    currentTime = 0;
        //}
    }

    // �÷��̾�κ��� �ǰ� �޾����� ó���� �Լ�
    Vector3 knockbackPos;
    public void OnDamageProcess(Vector3 shootDirection)
    {
        // ���� �ִ� �� �ǰ�ó�� �ϰ� ���� �ʴ�.
        if(m_state == EnemyState.Die)
        {
            return;
        }
        // �ڷ�ƾ�� �����ϰ� �ʹ�.
        StopAllCoroutines();

        hp--;
        // 1. hp �� 0 ���ϸ� ���ְ� �ʹ�.
        if(hp <= 0)
        {
            // ������ �浹ü ��������
            cc.enabled = false;
            m_state = EnemyState.Die;
            anim.SetTrigger("Die");
            //Destroy(gameObject);
        }
        // 2. ������ ���¸� �ǰ����� ��ȯ�ϰ� �ʹ�.
        else
        {
            // �˹� knockback
            // �и� ����
            // P = P0 + vt

            // �ǰ�ó���� �ڷ�ƾ�� �̿��Ͽ� ó���ϰ� �ʹ�.
            StartCoroutine(Damage(shootDirection));
            
        }
    }
}
