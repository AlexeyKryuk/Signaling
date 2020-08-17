using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxJumpSpeed;
    private float _currentJumpSpeed = 0;
    private Vector2 _input;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool jump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            _currentJumpSpeed = _maxJumpSpeed;
            if (Input.GetAxis("Horizontal") > 0)
                _animator.SetBool("JumpRight", true);
            else
                _animator.SetBool("JumpLeft", true);
        }
        else
            _currentJumpSpeed = _rb.velocity.y;

        _input = new Vector2(Input.GetAxis("Horizontal") * _speed, _currentJumpSpeed);
        _animator.SetFloat("Speed", _input.x / 5);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _input;
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            jump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            _animator.SetBool("JumpRight", false);
            _animator.SetBool("JumpLeft", false);
        }
    }
}
