using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int _damage;
    private float _startTime;
    private float _attackTime;
    private float _interval;
    private bool _allowAttack;
    private Animator _animator;
    private PolygonCollider2D _polygonCollider;

    // Start is called before the first frame update
    void Start()
    {
        _damage = 2;
        _startTime = 0.25f;
        _attackTime = 0.04f;
        _interval = 0.4f;
        _allowAttack = true;
        _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack") && _allowAttack)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }
}
