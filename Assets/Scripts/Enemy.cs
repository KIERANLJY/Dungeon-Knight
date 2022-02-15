using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int _health;
    public int _damage;
    public float _flashTime;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    // Start is called before the first frame update
    public void Start()
    {
        _flashTime = 0.2f;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    // Update is called once per frame
    public void Update()
    {
        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        FlashColor();
    }

    void FlashColor()
    {
        _spriteRenderer.color = Color.red;
        Invoke("ResetColor", _flashTime);
    }

    void ResetColor()
    {
        _spriteRenderer.color = _originalColor;
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (_other.GetComponent<PlayerHealth>() != null)
            {
                //if (!_other.GetComponent<PlayerHealth>().getInvincible())
                //{
                    _other.GetComponent<PlayerHealth>().PlayerTakesDamage(_damage);
                //}
            }
        }
    }
}
