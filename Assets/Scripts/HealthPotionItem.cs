using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        _playerHealth.UseHealthPotion();
        Destroy(gameObject);
    }
}
