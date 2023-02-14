using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSwordAnimation : MonoBehaviour
{
    [SerializeField] private Animator ZSwordAnimator;

    private void Awake()
    {
        ZSwordAnimator.enabled = false;
    }

    private void EndAttackAnimation()
    {
        ZSwordAnimator.enabled = false;
    }
}
