using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float _speed;
    public float _waitingTime;
    public Transform[] _movePos;
    private int i;
    private Transform _playerDef;

    // Start is called before the first frame update
    void Start()
    {
        //_speed = 2f;
        //_waitingTime = 1f;
        i = 1;
        _playerDef = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _movePos[i].position, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _movePos[i].position) < 0.1f)
        {
            if (_waitingTime < 0f)
            {
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                _waitingTime = 1f;
            }
            else
            {
                _waitingTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            _other.gameObject.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && _other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            _other.gameObject.transform.parent = _playerDef;
        }
    }
}
