using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player HP �� �����ϰ� �ʹ�. -> UI ǥ�õ� �ϰ� �ʹ�.
// �ʿ�Ӽ� : hp, UI
public class PlayerHealth : MonoBehaviour
{
    // �ʿ�Ӽ� : hp, UI
    public int hp = 3;
    public Image damageUI;

    // ����ð�, damageui �����ֽð�
    float currentTime;
    public float damageShowTime = 0.1f;

    // �̱��� ������������ �̿��Ͽ� EnemyManager �� ����ϰ� �ʹ�.
    public static PlayerHealth Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �����ð� damageUI �� ������ٰ� ���� �ʹ�.
        // 1. �ǰ�UI �� �������� �����ϱ�
        if (damageUI.enabled)
        {
            // 2. �ð��� �귶���ϱ�.
            currentTime += Time.deltaTime;
            // 3. �����ð��� �����ϱ�
            if (currentTime > damageShowTime)
            {
                // 4. damageUI ����
                damageUI.enabled = false;
            }
        }

    }

    // �����ð� damageUI �� ������ٰ� ���� �ʹ�.
    // hp �� ���ҽ�Ű�� �ʹ�.
    public void OnDamageProcess()
    {
        // hp �� ���ҽ�Ű�� �ʹ�.
        hp--;
        // 1. damageUI �����ֱ�
        damageUI.enabled = true;
        currentTime = 0;
    }
}
