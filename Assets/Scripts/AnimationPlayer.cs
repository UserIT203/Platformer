using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    private Animator _animator;

    public Animator Animator => _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartMoveAnimation(float speedValue) => _animator.SetFloat("Speed", speedValue);

    public void Hit() => _animator.SetTrigger("Hit");
}
