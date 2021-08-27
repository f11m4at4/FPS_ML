using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 상속
// 일정 시간에 한번씩 적을 만들고 싶다.
// 필요속성 : 생성시간, 경과시간, 적 공장

// 오브젝트풀을 이용하여 적을 미리 많이 생성해 놓고 싶다.
// 필요속성 : 오브젝트풀, 풀크기
public class EnemyManager : MonoBehaviour
{
    // 필요속성 : 생성시간, 경과시간, 적 공장
    public float createTime = 2;
    float currentTime = 0;
    public GameObject enemyFactory;

    // 필요속성 : 오브젝트풀, 풀크기
    public int enemyPoolSize = 20;
    //public GameObject[] enemyPool;
    //[System.NonSerialized]
    [HideInInspector]
    public List<GameObject> enemyPool = new List<GameObject>();

    [SerializeField]
    private int age = 10;
    // Start is called before the first frame update
    void Start()
    {
        // 배열의 크기를 정해준다.
        //enemyPool = new GameObject[enemyPoolSize];
        // 오브젝트풀을 이용하여 적을 미리 많이 생성해 놓고 싶다.
        // for(초기값선언;조건식;증감식)

        for(int i=0; i < enemyPoolSize; i++)
        {
            // to do
            // 적 공장에서 적을 만들고 싶다.
            GameObject enemy = Instantiate(enemyFactory);
            // 만들어진 적을 풀에 넣고 싶다.
            enemyPool.Add(enemy);
            // 비활성화 시켜주자
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 일정 시간에 한번씩 적을 만들고 싶다.
        // 1. 시간이 흘렀으니까.
        currentTime += Time.deltaTime;
        // 2. 생성시간이 됐으니까.
        if (currentTime > createTime)
        {
            // 3. 적을 만들고 싶다.
            // -> 오브젝트 풀에 있는 녀석중에 비활성화 되어 있는 녀석을 활성화 시키자
            // 만약 풀에 적이 있다면
            if (enemyPool.Count > 0)
            {
                GameObject enemy = enemyPool[0];
                //활성화 시키자
                enemy.SetActive(true);
                // 4. 배치.
                enemy.transform.position = transform.position;
                currentTime = 0;
                enemyPool.RemoveAt(0);
            }
        }

    }
}
