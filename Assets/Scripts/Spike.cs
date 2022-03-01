using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int _damage;
    private PlayerHealth _playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        // _damage = 1;
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            _playerHealth.PlayerTakesDamage(_damage);
        }
    }
}
