using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireR : MonoBehaviour
{
    //폭탄공장
    public GameObject bombFactory;
    //발사위치
    public Transform firePos;
    void Start()
    {
        
    }

    void Update()
    {
        //Fire1 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            //폭탄공장에서 폭탄을 만들자
            GameObject bomb = Instantiate(bombFactory);
            //만든 폭탄의 앞방향을 발사위치의 앞방향으로 하자
            bomb.transform.forward = firePos.forward;
            //만든 폭탄의 위치를 발사위치로 하자
            bomb.transform.position = firePos.position;
        }
    }
}
