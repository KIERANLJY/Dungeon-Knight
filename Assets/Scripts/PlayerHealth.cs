using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int _health;
    private Animator _animator;
    private PolygonCollider2D _polygonCollider;
    public float _damageCD;
    private SpriteRenderer _playerSprite;
    private Color _originalColor;
    
    // Start is called before the first frame update
    void Start()
    {
        // _health = 20;
        // _damageCD = 1f;
        _animator = GetComponent<Animator>();
        HealthBar._maxHealth = _health;
        HealthBar._currentHealth = _health;
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _playerSprite= GetComponent<SpriteRenderer>();
        _originalColor = _playerSprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTakesDamage(int _damage)
    {
        _animator.SetTrigger("TakeDamage");
        _health -= _damage;
        if (_health < 0)
        {
            _health = 0;
        }
        HealthBar._currentHealth = _health;
        if (_health == 0)
        {
            _animator.SetTrigger("Die");
            Destroy(gameObject, 0.6f);
        }
        _polygonCollider.enabled = false;
        StartCoroutine(WaitForDamageCD());
    }

    IEnumerator WaitForDamageCD()
    {
        // Wait and enable taking damage
        yield return new WaitForSeconds(_damageCD);
        _polygonCollider.enabled = true;
    }

    public void UseHealthPotion()
    {
        _health += 2;
        if (_health > HealthBar._maxHealth)
        {
            _health = HealthBar._maxHealth;
        }
        HealthBar._currentHealth = _health;
    }

    public void UseInvinciblePotion(float _invincibleTime)
    {
        _polygonCollider.enabled = false;
        _playerSprite.color = Color.grey;
        StartCoroutine(PotionTimeOut(_invincibleTime));
    }
    IEnumerator PotionTimeOut(float _invincibleTime)
    {
        yield return new WaitForSeconds(_invincibleTime);
        _polygonCollider.enabled = true;
        _playerSprite.color = _originalColor; 
    }
}
