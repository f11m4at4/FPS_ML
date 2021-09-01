using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform lookedTarget;
    private void OnAnimatorIK(int layerIndex)
    {
        print("layerIndex : " + layerIndex);
        GetComponent<Animator>().SetLookAtPosition(lookedTarget.position);
        GetComponent<Animator>().SetLookAtWeight(1);
    }
}
