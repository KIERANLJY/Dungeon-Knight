using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float _speed;
    public int _damage;
    public float _destroyDistance;
    private Rigidbody2D _rigidBody;
    private Vector3 _startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        // _speed = 15;
        // _damage = 1;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.right * _speed;
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float _distance = (transform.position - _startPos).sqrMagnitude;
        if (_distance > _destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Enemy"))
        {
            _other.GetComponent<Enemy>().TakeDamage(_damage);
        }
        else if(!_other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
