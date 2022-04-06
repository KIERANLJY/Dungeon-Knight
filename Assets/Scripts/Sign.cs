using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    private DialogBox _dialogBox;
    private bool _playerOnSign;

    // Start is called before the first frame update
    void Start()
    {
        _dialogBox = GameObject.FindGameObjectWithTag("InGameCanvas").GetComponent<DialogBox>();
        _playerOnSign = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dialogBox != null)
        {
            if (_playerOnSign)
            {
                _dialogBox.ShowDialogBox();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D _other) {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _playerOnSign = true;
        }
    }

    void OnTriggerExit2D(Collider2D _other) {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _playerOnSign = false;
            _dialogBox.HideDialogBox();
        }
    }
}
