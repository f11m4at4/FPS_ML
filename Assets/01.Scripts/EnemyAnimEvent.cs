using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy �� �ִϸ��̼ǿ��� �߻��ϴ� �̺�Ʈ�� ó���ϴ� ��ü
public class EnemyAnimEvent : MonoBehaviour
{
    void OnHit()
    {
        // Player Damage ������
        PlayerHealth.Instance.OnDamageProcess();
    }
}
