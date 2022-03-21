using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToFinalLevel : MonoBehaviour
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
                _cameraFollow.SetCamPosLimit(122f, 5f, 182f, 14f);
                SceneManager.LoadScene(4);
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
