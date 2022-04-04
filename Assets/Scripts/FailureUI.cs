using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureUI : MonoBehaviour
{
    private GameObject _player;
    private GameObject _camera;
    public GameObject _failureUI;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _camera = GameObject.FindGameObjectWithTag("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            _failureUI.SetActive(true);
        }
    }

    public void BackToRecord()
    {
        SceneManager.LoadScene(1);
        Destroy(this.gameObject);
        Destroy(_camera);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
        Destroy(_camera);
    }
}
