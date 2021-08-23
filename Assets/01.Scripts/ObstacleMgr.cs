using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMgr : MonoBehaviour
{
    //나를 담을 수 있는 변수
    public static ObstacleMgr instance;

    //장애물 리스트
    public List<GameObject> obstacles;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void CheckExplo(Vector3 exploPos, float radius)
    {
        //장애물 갯수만큼 계산을한다.
        for(int i = obstacles.Count - 1; i >= 0; i--)
        {
            //exploPos, 장애물의 거리를 구한다.
            float dist = Vector3.Distance(exploPos, obstacles[i].transform.position);
            //그거리가 radius 보다 작다면 그 장애물을 파괴한다.
            if(dist < radius)
            {
                //해당 장애물 파괴
                Destroy(obstacles[i]);
                //장애물 리스트에서 삭제
                obstacles.RemoveAt(i);
            }
        }
    }
}
