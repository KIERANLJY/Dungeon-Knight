using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUI : MonoBehaviour
{
    public Text _arrowText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            ArrowAttack _arrowAttack = _player.GetComponentInChildren<ArrowAttack>();
            _arrowText.text = "* " + _arrowAttack._arrowQuantity.ToString();
        }
    }
}
