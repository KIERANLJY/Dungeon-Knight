using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private int _attackDamage;
    private float _startTime;
    private float _attackTime;
    private float _interval;
    private bool _allowAttack;
    private Animator _animator;
    private PolygonCollider2D _polygonCollider;
    Transform _player;
    Rigidbody2D _rigidBody;
    private float _attackRange;

    // Start is called before the first frame update
    void Start()
    {
        _attackDamage = 1;
        _startTime = 0.58f;
        _attackTime = 0.04f;
        _interval = 2f;
        _allowAttack = true;
        _animator = this.GetComponentInParent<Animator>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidBody = this.GetComponentInParent<Rigidbody2D>();
        _attackRange = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Vector2.Distance(_player.position, _rigidBody.position) <= _attackRange && _allowAttack)
        {
            _allowAttack = false;
            _animator.SetTrigger("Attack");
            StartCoroutine(StartAttack());
            StartCoroutine(AllowAttack());
        }
    }

    IEnumerator StartAttack()
    {
        // Wait and enable polygon collider
        yield return new WaitForSeconds(_startTime);
        _polygonCollider.enabled = true;
        StartCoroutine(DisableHitBox());
    }

    IEnumerator DisableHitBox()
    {
        // Wait and disable polygon collider
        yield return new WaitForSeconds(_attackTime);
        _polygonCollider.enabled = false;
    }

    IEnumerator AllowAttack()
    {
        // Set interval between attacks
        yield return new WaitForSeconds(_interval);
        _allowAttack = true;
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            _other.GetComponent<PlayerHealth>().PlayerTakesDamage(_attackDamage);
        }
    }
}
