using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    private int _health;
    private int _damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
