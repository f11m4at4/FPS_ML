using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //리지드바디
    Rigidbody rb;
    //날라가는 힘
    public float power = 500;

    //폭발효과공장
    public GameObject exploFactory;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //자신의 앞방향으로 힘을 준다
        rb.AddForce(transform.forward * power);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //폭발효과공장에서 폭발효과 만든다
        GameObject explo = Instantiate(exploFactory);
        //만든 폭발효과를 나의 위치에 놓는다.
        explo.transform.position = transform.position;
        //3초뒤에 폭발효과를 삭제
        Destroy(explo, 3);

        //나(폭탄)의 위치에서 반경 2안에 들어오는 Collider검색
        Collider [] cols = Physics.OverlapSphere(transform.position, 5);
        for(int i = 0; i < cols.Length; i++)
        {
            if (cols[i].tag == "Obstacle")
            {
                Destroy(cols[i].gameObject);
            }
        }

        

        //나자신을 삭제
        Destroy(gameObject);
    }
}
