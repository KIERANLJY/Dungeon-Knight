using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    private bool _interactive;

    // Start is called before the first frame update
    void Start()
    {
        _interactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_interactive)
        {
            if (Input.GetButtonDown("Interact"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _interactive = true;
        }
    }

    void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _interactive = false;
        }
    }
}
