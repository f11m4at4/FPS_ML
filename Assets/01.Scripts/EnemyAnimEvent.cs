using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy 의 애니메이션에서 발생하는 이벤트를 처리하는 객체
public class EnemyAnimEvent : MonoBehaviour
{
    void OnHit()
    {
        // Player Damage 입히기
        PlayerHealth.Instance.OnDamageProcess();
    }
}
