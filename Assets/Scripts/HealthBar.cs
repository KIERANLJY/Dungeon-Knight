using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int _maxHealth;
    public static int _currentHealth;
    private Image _healthBar;
    public Text _healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.fillAmount = (float)_currentHealth / (float)_maxHealth;
        _healthText.text = _currentHealth.ToString() + "/" + _maxHealth.ToString();
    }
}
