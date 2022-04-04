using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordLoading : MonoBehaviour
{
    private int _health;
    private int _level = -1;
    private Vector3 _position;
    private int _num;
    public GameObject _player;
    public GameObject _camera;
    public GameObject _UI;

    public void NewGame()
    {
        SceneManager.LoadScene(2);
        Vector3 _playerPos = new Vector3(0, -3, 0);
        Vector3 _camPos = new Vector3(0, -2, 0);
        Vector3 _uiPos = new Vector3(960, 540, 0);
        Instantiate(_player, _playerPos, Quaternion.identity);
        Instantiate(_camera, _camPos, Quaternion.identity);
        Instantiate(_UI, _uiPos, Quaternion.identity);
    }

    public void LoadPlayer()
    {
        PlayerData _data = SaveSystem.LoadPlayer();
        _health = _data._health;
        _level = _data._level;
        _position.x = _data._position[0];
        _position.y = _data._position[1];
        _position.z = _data._position[2];
        _num = _data._num;
        Vector3 _offset = new Vector3(0, 1, 0);
        if (_level == -1)
        {
            NewGame();
        }
        else
        {
            SceneManager.LoadScene(_level);
            Instantiate(_player, _position, Quaternion.identity);
            Instantiate(_camera, _position + _offset, Quaternion.identity);
            Instantiate(_UI, _position, Quaternion.identity);
            PlayerHealth _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            _playerHealth._health = _health;
            ArrowAttack _arrowAttack = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ArrowAttack>();
            _arrowAttack._arrowQuantity = _num;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
