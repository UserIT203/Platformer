using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationPlayer))]
public class PlayerStats : MonoBehaviour
{
    private AnimationPlayer _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<AnimationPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyController>(out EnemyController enemy))
            _animator.Hit();
    }
}
