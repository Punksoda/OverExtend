using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
   

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 direction)
    {
       bool isMoving = direction.sqrMagnitude > 0.01; // �̵� ���θ� �Ǵ�
        animator.SetBool(IsMoving, isMoving); // �ִϸ����Ϳ� ����
    }
}
