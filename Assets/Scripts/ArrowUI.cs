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
        ArrowAttack _arrowAttack = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArrowAttack>();
        _arrowText.text = "* " + _arrowAttack._arrowQuantity.ToString();
    }
}
