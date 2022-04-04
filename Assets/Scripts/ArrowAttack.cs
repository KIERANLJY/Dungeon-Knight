using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{
    public GameObject _arrowPrefab;
    public int _arrowQuantity;

    // Start is called before the first frame update
    void Start()
    {
        // _arrowQuantity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Shoot") && _arrowQuantity > 0)
        {
            Instantiate(_arrowPrefab, transform.position, transform.rotation);
            _arrowQuantity --;
        }
    }
}
