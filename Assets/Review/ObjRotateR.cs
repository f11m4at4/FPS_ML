using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotateR : MonoBehaviour
{
    //회전속력
    public float rotSpeed = 200;
    //각도 누적 값
    float mx;
    float my;
    //회전 가능 여부
    public bool canRotH;
    public bool canRotV;
    
    void Start()
    {
        //처음 각도를 mx, my에 셋팅
        mx = transform.localEulerAngles.x;
        my = transform.localEulerAngles.y;
    }

    void Update()
    {
        //마우스의 움직임의 값을 받는다.
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        //마우스의 움직임에 따라 각도를 누적시킨다.
        if(canRotH) my += h * rotSpeed * Time.deltaTime;
        if(canRotV) mx += v * rotSpeed * Time.deltaTime;

        //-60 < mx < 60
        mx = Mathf.Clamp(mx, -60, 60);
        
        //누적된 각도를 나의 게임오브젝트 각도에 셋팅한다
        transform.localEulerAngles = new Vector3(-mx, my, 0);
    }
}
