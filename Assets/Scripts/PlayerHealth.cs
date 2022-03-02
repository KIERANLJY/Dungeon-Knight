using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator _animator;
    private PolygonCollider2D _polygonCollider;
    public float _damageCD;
    
    // Start is called before the first frame update
    void Start()
    {
        // _health = 20;
        // _damageCD = 1f;
        _animator = GetComponent<Animator>();
        HealthBar._maxHealth = StaticValues._maxHealth;
        HealthBar._currentHealth = StaticValues._health;
        _polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTakesDamage(int _damage)
    {
        _animator.SetTrigger("TakeDamage");
        StaticValues._health -= _damage;
        if (StaticValues._health < 0)
        {
            StaticValues._health = 0;
        }
        HealthBar._currentHealth = StaticValues._health;
        if (StaticValues._health == 0)
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
        StaticValues._health += 2;
        if (StaticValues._health > HealthBar._maxHealth)
        {
            StaticValues._health = HealthBar._maxHealth;
        }
        HealthBar._currentHealth = StaticValues._health;
    }
}
