using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    private bool _interactive;
    private CameraFollow _cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        _interactive = false;
        _cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_interactive)
        {
            if (Input.GetButtonDown("Interact"))
            {
                SceneManager.LoadScene(3);
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
