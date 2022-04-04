using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _runSpeed;
    public float _jumpSpeed;
    public float _doubleJumpSpeed;
    private bool _isGround;
    private bool _canDoubleJump;
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private BoxCollider2D _feetCollider;
    private bool _isLadder;
    public float _climbSpeed;
    private float _gravity;
    private bool _isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        // _runSpeed = 5;
        // _jumpSpeed = 6;
        // _doubleJumpSpeed = 5;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _feetCollider = GetComponent<BoxCollider2D>();
        // _climbSpeed = 2;
        _gravity = _rigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGround();
        SwitchStatesInJumping();
        CheckLadder();
        CheckIsClimbing();
        Climb();
    }

    // Change orientation of the play according to moving direction
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
        // Move forward
        if(Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        // Move Backward
        if(Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
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
                _rigidBody.velocity = Vector2.up * _jumpVel;
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                _animator.SetBool("DoubleJump", true);
                Vector2 _jumpVel = new Vector2(0, _doubleJumpSpeed);
                _rigidBody.velocity = Vector2.up * _jumpVel;
                _canDoubleJump = false;
            }
        }
    }

    void CheckGround()
    {
        // Check if the player is on the ground
        _isGround = _feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || _feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform"));
    }

    void SwitchStatesInJumping()
    {
        _animator.SetBool("Idle", false);
        // Reach the top
        if (_animator.GetBool("Jump")) {
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

        // Reach the top when double jump
        if (_animator.GetBool("DoubleJump")) {
            if (_rigidBody.velocity.y < 0)
            {
                _animator.SetBool("DoubleJump", false);
                _animator.SetBool("DoubleFall", true);
            }
        }
        else if (_isGround)
        {
            _animator.SetBool("DoubleFall", false);
            _animator.SetBool("Idle", true);
        }
    }

    void CheckLadder()
    {
        _isLadder = _feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }

    void CheckIsClimbing()
    {
        _isClimbing = _animator.GetBool("Climb");
    }

    void Climb()
    {
        if (_isLadder)
        {
            float _moveDir = Input.GetAxis("Vertical");
            if (_moveDir > 0.5f || _moveDir < -0.5f)
            {
                _rigidBody.gravityScale = 0f;
                Vector2 _playVel = new Vector2(_rigidBody.velocity.x, _moveDir * _climbSpeed);
                _rigidBody.velocity = _playVel;
                _animator.SetBool("Climb", true);
            }
            else
            {
                if (! _isClimbing)
                {
                    _rigidBody.gravityScale = _gravity;
                }
                else
                {
                    Vector2 _playVel = new Vector2(_rigidBody.velocity.x, 0f);
                    _rigidBody.velocity = _playVel;
                }
                
            }
        }
        else
        {
            _rigidBody.gravityScale = _gravity;
            _animator.SetBool("Climb", false);
        }
    }
}
