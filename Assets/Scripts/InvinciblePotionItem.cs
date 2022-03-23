using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblePotionItem : MonoBehaviour
{
    private PolygonCollider2D _playerCollider;
    private SpriteRenderer _playerSprite;
    public float _invincibleTime;
    private Color _originalColor;

    // Start is called before the first frame update
    void Start()
    {
        _playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PolygonCollider2D>();
        _playerSprite= GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        // _invincibleTime = 5f;
        _originalColor = _playerSprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        _playerCollider.enabled = false;
        _playerSprite.color = Color.grey;
        StartCoroutine(PotionTimeOut());
    }
    IEnumerator PotionTimeOut()
    {
        yield return new WaitForSeconds(_invincibleTime);
        _playerCollider.enabled = true;
        _playerSprite.color = _originalColor;
        Destroy(gameObject);
    }
}
