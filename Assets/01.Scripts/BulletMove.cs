using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //속력
    public float speed = 10;
    //Rigidbody
    Rigidbody rb;
    //파워
    public float power = 100;
    //폭발공장
    public GameObject exploFactory;
    //반경
    public float exploRange = 4;

    void Start()
    {
        //RIgidbody 컴포넌 가져오자
        rb = GetComponent<Rigidbody>();
        //총알의 앞방향으로 힘을 준다
        rb.AddForce(transform.forward * power);
    }

    void Update()
    {
        //계속 자기자신의 앞으로 이동하고 싶다.
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        //폭발공장에서 폭발효과를 만든다.
        GameObject explo = Instantiate(exploFactory);
        //만들어진 폭발을 나의위치에 놓는다.
        explo.transform.position = transform.position;
        //만들어진 폭발을 3초뒤에 삭제
        Destroy(explo, 3);

        //반경안에 들어온 장애물 파괴 체크
        //ObstacleMgr.instance.CheckExplo(transform.position, exploRange);

        Collider [] cols = Physics.OverlapSphere(transform.position, exploRange);
        for(int i = 0; i < cols.Length; i++)
        {
            if(cols[i].gameObject.tag == "Obstacle")
            {
                Destroy(cols[i].gameObject);
            }
        }
        

        ////만약에 부딪힌놈의 tag가 Obstacle이면
        //if(other.gameObject.tag == "Obstacle")
        //{
        //    //부딪힌놈 파괴
        //    Destroy(other.gameObject);
        //}

        Destroy(gameObject);
    }
}
