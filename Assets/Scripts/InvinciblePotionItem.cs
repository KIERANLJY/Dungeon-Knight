using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePotionItem : MonoBehaviour
{
    public float _invincibleTime;
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // _invincibleTime = 5f;
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        _playerHealth.UseInvinciblePotion(_invincibleTime);
        Destroy(gameObject);
    }
}
