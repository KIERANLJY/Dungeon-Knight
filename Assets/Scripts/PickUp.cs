using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory _inventory;
    public GameObject _itemButton;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            for (int i = 0; i < _inventory._slots.Length; i++)
            {
                if (!_inventory._isFull[i])
                {
                    _inventory._isFull[i] = true;
                    Instantiate(_itemButton, _inventory._slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
