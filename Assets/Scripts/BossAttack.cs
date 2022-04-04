using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAttack : MonoBehaviour
{
    private int _attackDamage;
    private float _startTime;
    private float _attackTime;
    private float _interval;
    private bool _allowAttack;
    private Animator _animator;
    private PolygonCollider2D _polygonCollider;
    private Transform _player;
    private Rigidbody2D _rigidBody;
    private float _attackRange;
    private EnemyBoss _boss;
    private CapsuleCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _attackDamage = 1;
        _startTime = 0.4f;
        _attackTime = 0.04f;
        _interval = 2f;
        _allowAttack = true;
        _animator = this.GetComponentInParent<Animator>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidBody = this.GetComponentInParent<Rigidbody2D>();
        _attackRange = 3f;
        _boss = GetComponentInParent<EnemyBoss>();
        _collider = GetComponentInParent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
             Attack();
            Enraged();
            Death();
        }  
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

    public void Enraged()
    {
        if (_boss._health <= 13)
        {
            _interval = 1f;
        }

    }

    public void Death()
    {
        if (_boss._health <= 3)
        {
            _animator.SetTrigger("Die");
            _collider.enabled = false;
            _allowAttack = false;
            Invoke("LoadEnding", 2);
        }
    }

    void LoadEnding()
    {
        SceneManager.LoadScene(5);
    }
}
