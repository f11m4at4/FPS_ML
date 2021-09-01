using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Player HP 를 관리하고 싶다. -> UI 표시도 하고 싶다.
// 필요속성 : hp, UI
public class PlayerHealth : MonoBehaviour
{
    // 필요속성 : hp, UI
    public int hp = 3;
    public Image damageUI;

    // 경과시간, damageui 보여주시간
    float currentTime;
    public float damageShowTime = 0.1f;

    // 싱글톤 디자인패턴을 이용하여 EnemyManager 를 사용하고 싶다.
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
        // 일정시간 damageUI 를 보여줬다가 끄고 싶다.
        // 1. 피격UI 가 보여지고 있으니까
        if (damageUI.enabled)
        {
            // 2. 시간이 흘렀으니까.
            currentTime += Time.deltaTime;
            // 3. 일정시간이 됐으니까
            if (currentTime > damageShowTime)
            {
                // 4. damageUI 끄기
                damageUI.enabled = false;
            }
        }

    }

    // 일정시간 damageUI 를 보여줬다가 끄고 싶다.
    // hp 를 감소시키고 싶다.
    public void OnDamageProcess()
    {
        // hp 를 감소시키고 싶다.
        hp--;
        // 1. damageUI 보여주기
        damageUI.enabled = true;
        currentTime = 0;
    }
}
