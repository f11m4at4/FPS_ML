using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���
// ���� �ð��� �ѹ��� ���� ����� �ʹ�.
// �ʿ�Ӽ� : �����ð�, ����ð�, �� ����

// ������ƮǮ�� �̿��Ͽ� ���� �̸� ���� ������ ���� �ʹ�.
// �ʿ�Ӽ� : ������ƮǮ, Ǯũ��
public class EnemyManager : MonoBehaviour
{
    // �ʿ�Ӽ� : �����ð�, ����ð�, �� ����
    public float createTime = 2;
    float currentTime = 0;
    public GameObject enemyFactory;

    // �ʿ�Ӽ� : ������ƮǮ, Ǯũ��
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
        // �迭�� ũ�⸦ �����ش�.
        //enemyPool = new GameObject[enemyPoolSize];
        // ������ƮǮ�� �̿��Ͽ� ���� �̸� ���� ������ ���� �ʹ�.
        // for(�ʱⰪ����;���ǽ�;������)

        for(int i=0; i < enemyPoolSize; i++)
        {
            // to do
            // �� ���忡�� ���� ����� �ʹ�.
            GameObject enemy = Instantiate(enemyFactory);
            // ������� ���� Ǯ�� �ְ� �ʹ�.
            enemyPool.Add(enemy);
            // ��Ȱ��ȭ ��������
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ð��� �ѹ��� ���� ����� �ʹ�.
        // 1. �ð��� �귶���ϱ�.
        currentTime += Time.deltaTime;
        // 2. �����ð��� �����ϱ�.
        if (currentTime > createTime)
        {
            // 3. ���� ����� �ʹ�.
            // -> ������Ʈ Ǯ�� �ִ� �༮�߿� ��Ȱ��ȭ �Ǿ� �ִ� �༮�� Ȱ��ȭ ��Ű��
            // ���� Ǯ�� ���� �ִٸ�
            if (enemyPool.Count > 0)
            {
                GameObject enemy = enemyPool[0];
                //Ȱ��ȭ ��Ű��
                enemy.SetActive(true);
                // 4. ��ġ.
                enemy.transform.position = transform.position;
                currentTime = 0;
                enemyPool.RemoveAt(0);
            }
        }

    }
}
