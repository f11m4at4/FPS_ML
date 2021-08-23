using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMgr : MonoBehaviour
{
    //���� ���� �� �ִ� ����
    public static ObstacleMgr instance;

    //��ֹ� ����Ʈ
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
        //��ֹ� ������ŭ ������Ѵ�.
        for(int i = obstacles.Count - 1; i >= 0; i--)
        {
            //exploPos, ��ֹ��� �Ÿ��� ���Ѵ�.
            float dist = Vector3.Distance(exploPos, obstacles[i].transform.position);
            //�װŸ��� radius ���� �۴ٸ� �� ��ֹ��� �ı��Ѵ�.
            if(dist < radius)
            {
                //�ش� ��ֹ� �ı�
                Destroy(obstacles[i]);
                //��ֹ� ����Ʈ���� ����
                obstacles.RemoveAt(i);
            }
        }
    }
}
