using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ѿ� ĳ���� ���� �پ��ְ� �ϰ� �ʹ�.
public class IKControl : MonoBehaviour
{
    // �ʿ�Ӽ� : ��, �޼�, ������
    public Transform gun;
    public Transform leftHand;
    public Transform rightHand;

    // ĳ���Ͱ� Ư�� ��ü�� �ٶ󺸵��� �غ���
    // �ʿ�Ӽ� : �ٶ� ��ü
    public Transform lookedTarget;
    private void OnAnimatorIK(int layerIndex)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetLookAtPosition(lookedTarget.position);
        anim.SetLookAtWeight(1);

        // �ѿ� ĳ���� ���� �پ��ְ� �ϰ� �ʹ�.
        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
        anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);

        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    }
}
