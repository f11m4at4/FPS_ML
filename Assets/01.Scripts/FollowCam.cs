using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player 를 따라다니고 싶다.
// 필요속성 : 따라다닐 타겟, 속도
// Shift 키를 누르면 ZoomPos 로 이동하게 하고 싶다.
public class FollowCam : MonoBehaviour
{
    // 필요속성 : 따라다닐 타겟, 속도
    public Transform camPos;
    public float speed = 5;

    public Transform zoomPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Shift 키를 누르면 ZoomPos 로 이동하게 하고 싶다.
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = Vector3.Lerp(transform.position, zoomPos.position, speed * Time.deltaTime);
            // 방향
            transform.forward = Vector3.Lerp(transform.forward, zoomPos.forward, speed * Time.deltaTime);
            return;
        }
        
        // Player 를 따라다니고 싶다.
        // 이동 보간
        transform.position = Vector3.Lerp(transform.position, camPos.position, speed * Time.deltaTime);
        // 방향
        transform.forward = Vector3.Lerp(transform.forward, camPos.forward, speed * Time.deltaTime);
    }
}
