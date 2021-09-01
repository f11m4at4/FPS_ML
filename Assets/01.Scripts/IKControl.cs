using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 총에 캐릭터 손이 붙어있게 하고 싶다.
public class IKControl : MonoBehaviour
{
    // 필요속성 : 총, 왼손, 오른손
    public Transform gun;
    public Transform leftHand;
    public Transform rightHand;

    // 캐릭터가 특정 물체를 바라보도록 해보자
    // 필요속성 : 바라볼 물체
    public Transform lookedTarget;
    private void OnAnimatorIK(int layerIndex)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetLookAtPosition(lookedTarget.position);
        anim.SetLookAtWeight(1);

        // 총에 캐릭터 손이 붙어있게 하고 싶다.
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
