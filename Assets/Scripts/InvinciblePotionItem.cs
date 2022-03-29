using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePotionItem : MonoBehaviour
{
    public float _invincibleTime;
    private PlayerHealth _playerHealth;
    private Inventory _inventory;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        // _invincibleTime = 5f;
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIndex(int _i)
    {
        _index = _i;
    }

    public void Use()
    {
        _playerHealth.UseInvinciblePotion(_invincibleTime);
        _inventory._isFull[_index] = false;
        Destroy(gameObject);
    }
}
