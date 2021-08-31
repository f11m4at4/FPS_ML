using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player �� ����ٴϰ� �ʹ�.
// �ʿ�Ӽ� : ����ٴ� Ÿ��, �ӵ�
// Shift Ű�� ������ ZoomPos �� �̵��ϰ� �ϰ� �ʹ�.
public class FollowCam : MonoBehaviour
{
    // �ʿ�Ӽ� : ����ٴ� Ÿ��, �ӵ�
    public Transform camPos;
    public float speed = 5;

    public Transform zoomPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Shift Ű�� ������ ZoomPos �� �̵��ϰ� �ϰ� �ʹ�.
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = Vector3.Lerp(transform.position, zoomPos.position, speed * Time.deltaTime);
            // ����
            transform.forward = Vector3.Lerp(transform.forward, zoomPos.forward, speed * Time.deltaTime);
            return;
        }
        
        // Player �� ����ٴϰ� �ʹ�.
        // �̵� ����
        transform.position = Vector3.Lerp(transform.position, camPos.position, speed * Time.deltaTime);
        // ����
        transform.forward = Vector3.Lerp(transform.forward, camPos.forward, speed * Time.deltaTime);
    }
}
