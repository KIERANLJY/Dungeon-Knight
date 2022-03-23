using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnake : Enemy
{
    public float _speed;
    public float _waitingTime;
    public Transform[] _movePos;
    private int i;
    private float _currentTime;
    private bool _movingForward;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        // _speed = 3f;
        // _waitingTime = 0.5f;
        i = 1;
        _currentTime = _waitingTime;
        _movingForward = true;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, _movePos[i].position, _speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, _movePos[i].position) < 0.1f)
        {
            if (_currentTime < 0f)
            {
                if (_movingForward)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    _movingForward = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    _movingForward = true;
                }
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                _currentTime = _waitingTime;
            }
            else
            {
                _currentTime -= Time.deltaTime;
            }
        }
    }
}
