using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 발사버튼을 눌러서 Enemy 를 맞추면
// Enemy 한테 야 너 맞았어. 라고 알려주고 싶다.
public class PlayerFire : MonoBehaviour
{
    public delegate void DEliminate();
    public DEliminate onEli;

    //총알공장
    public GameObject bulletFactory;
    //총구
    public Transform firePos;   
    //파편효과
    public GameObject fragmentEft;

    void Start()
    {

    }

    void Update()
    {
        //만약에 Fire1 버튼을 누르면
        if(Input.GetButtonDown("Fire1"))
        {
            //총알공장에서 총알을 만든다.
            GameObject bullet = Instantiate(bulletFactory);
            //만들어진 총알의 앞방향을 총구에 앞방향으로 셋팅
            bullet.transform.forward = firePos.forward;
            //만들어진 총알을 총구에 놓는다.
            bullet.transform.position = firePos.position;
        }

        //만약에 Fire2 버튼을 누르면 (마우스오른쪽, 왼쪽alt)
        if(Input.GetButtonDown("Fire2"))
        {
            //카메라위치, 카메라앞방향에서 발사되는 Ray를 만든다.
            Ray ray = new Ray(
                Camera.main.transform.position,
                Camera.main.transform.forward);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //맞은위치의 정보
            RaycastHit hitInfo;
            //Ray에 충돌 하고 싶은 Layer
            int layerObs = 1 << LayerMask.NameToLayer("Obstacle");
            int layerWall = 1 << LayerMask.NameToLayer("Wall");
            int layer = 1 << LayerMask.NameToLayer("Player");

            //Ray를 발사시켜서 어딘가에 부딪혔다면
            if(Physics.Raycast(ray, out hitInfo, 100, ~layer))
            {
                //효과를 맞은위치에 놓는다
                fragmentEft.transform.position = hitInfo.point;

                //효과의 앞방향을 부딪힌 면의 수직벡터(Noraml벡터)로 한다
                fragmentEft.transform.forward = hitInfo.normal;

                //만든 효과에서 ParticleSystem 컴포넌트 가져오자
                ParticleSystem ps = fragmentEft.GetComponent<ParticleSystem>();
                //가져온 컴포넌트의 기능중 Play실행
                ps.Play();

                // 맞은 녀석이 Enemy 라면
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy)
                {
                    // Enemy 한테 야 너 맞았어. 라고 알려주고 싶다.
                    enemy.OnDamageProcess(ray.direction); 
                }
            }

            //AudioSource 컴포넌트 가져오자
            AudioSource audio = fragmentEft.GetComponent<AudioSource>();
            //가져온 컴포넌트의 기능중 Play실행
            audio.Play();
        }

        // 만약 Clear 버튼을 누르면
        if (Input.GetButtonDown("Clear"))
        {
            // 씬에 있는 모든 Enemy 제거하기
            Eliminate();
        }
    }

    // 씬에 있는 모든 Enemy 제거하기
    private void Eliminate()
    {
        onEli();
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ////for(int i=0;i<enemies.Length;i++)
        ////{
        ////    Destroy(enemies[i]);
        ////}
        //foreach(GameObject enemy in enemies)
        //{
        //    Destroy(enemy);
        //}
    }
}
