using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _runSpeed;
    private float _jumpSpeed;
    private bool _isGround;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private BoxCollider2D _feetCollider;

    // Start is called before the first frame update
    void Start()
    {
        _runSpeed = 5;
        _jumpSpeed = 6;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _feetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGround();
        SwitchStatesInJumping();
    }

    // Change orientation of the play according to moving direction
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasXAxisSpeed)
        {
            // Move forward
            if(_rigidBody.velocity.x > Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            // Move Backward
            if(_rigidBody.velocity.x < -Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }


    void Run()
    {
        // Get the direction of player moving
        float _moveDir = Input.GetAxis("Horizontal");
        // Set velocity and assign to the player
        if (_isGround)
        {
            Vector2 _playVel = new Vector2(_moveDir * _runSpeed, _rigidBody.velocity.y);
            _rigidBody.velocity = _playVel;
        }
        else
        {
            Vector2 _playVel = new Vector2(_moveDir * (_runSpeed - 2), _rigidBody.velocity.y);
            _rigidBody.velocity = _playVel;
        }

        // Check if the player is running
        bool _playerHasXAxisSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("Run", _playerHasXAxisSpeed);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Jump if the player is on the ground
            if (_isGround)
            {
                _animator.SetBool("Jump", true);
                // Get velocity of jumping on Y axis
                Vector2 _jumpVel = new Vector2(0, _jumpSpeed);
                _rigidBody.velocity = _jumpVel;
            }
        }
    }

    void CheckGround()
    {
        _isGround = _feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void SwitchStatesInJumping()
    {
        _animator.SetBool("Idle", false);
        if (_animator.GetBool("Jump"))
        {
            // Reach the top
            if (_rigidBody.velocity.y < 0)
            {
                _animator.SetBool("Jump", false);
                _animator.SetBool("Fall", true);
            }
        }
        else if (_isGround)
        {
            _animator.SetBool("Fall", false);
            _animator.SetBool("Idle", true);
        }
    }
}
