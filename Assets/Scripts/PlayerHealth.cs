using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int _health;
    private float _invincibleTime;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // _health = 20;
        _invincibleTime = 0.5f;
        _animator = GetComponent<Animator>();
        HealthBar._maxHealth = _health;
        HealthBar._currentHealth = _health;
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
        StartCoroutine(Invincible());
        if (_health == 0)
        {
            _animator.SetTrigger("Die");
            Destroy(gameObject, 0.6f);
        }
    }

    IEnumerator Invincible()
    {
        // Wait and enable taking damage
        yield return new WaitForSeconds(_invincibleTime);
    }

    public void UseHealthPotion()
    {
        _health += 3;
        if (_health > HealthBar._maxHealth)
        {
            _health = HealthBar._maxHealth;
        }
        HealthBar._currentHealth = _health;
    }
}
