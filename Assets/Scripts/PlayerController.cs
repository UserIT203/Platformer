using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationPlayer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed; 
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMask;

    private Rigidbody2D _rigidbody;
    private AnimationPlayer _animator;

    private bool _isFlipRight = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<AnimationPlayer>();
    }

    private void Flip()
    {
        _isFlipRight = !_isFlipRight;
        Vector3 newLocalScale = transform.localScale;
        newLocalScale.x *= -1;
        transform.localScale = newLocalScale;
    }

    private void Move(float direction)
    {
        if (direction > 0 && !_isFlipRight)
            Flip();
        else if (direction < 0 && _isFlipRight)
            Flip();

        _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);

        float speedValue = Mathf.Abs(direction * _speed);

        if(CheckGround())
            _animator.StartMoveAnimation(speedValue);
    }

    private bool CheckGround()
    {
        bool isGround;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, _layerMask);
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

        if (hit)
            isGround = true;
        else
            isGround = false;

        return isGround;
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
    }

    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        Move(direction);

        _animator.Animator.SetBool("isGround", CheckGround());
        _animator.Animator.SetFloat("vSpeed", _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
            Jump();
    }
}
