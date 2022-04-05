using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : MonoBehaviour
{
    private ArrowAttack _arrowAttack;

    // Start is called before the first frame update
    void Start()
    {
        _arrowAttack = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArrowAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (_arrowAttack._arrowQuantity < 5)
            {
                _arrowAttack._arrowQuantity ++;
                Destroy(gameObject);
            }
        }
    }
}
