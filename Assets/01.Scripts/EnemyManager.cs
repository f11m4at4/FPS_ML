using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속
// 일정 시간에 한번씩 적을 만들고 싶다.
// 필요속성 : 생성시간, 경과시간, 적 공장
public class EnemyManager : MonoBehaviour
{
    // 필요속성 : 생성시간, 경과시간, 적 공장
    public float createTime = 2;
    float currentTime = 0;
    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 일정 시간에 한번씩 적을 만들고 싶다.
        // 1. 시간이 흘렀으니까.
        // 2. 생성시간이 됐으니까.
        // 3. 적을 만들고 싶다.
    }
}
