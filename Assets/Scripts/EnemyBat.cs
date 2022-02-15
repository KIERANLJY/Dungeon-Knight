using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    private float _speed;
    private float _waitTime;
    private float _timeCount;
    public Transform _destination;
    public Transform _areaBottomLeft;
    public Transform _areaTopRight;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        //_health = 5;
        //_damage = 2;
        _speed = 1f;
        _waitTime = 1f;
        _timeCount = _waitTime;
        _destination.position = GetRandomPos();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, _destination.position, _speed * Time.deltaTime);
        // Check if the bat has arrived at the destination point
        if (Vector2.Distance(transform.position, _destination.position) <= 0.1f)
        {
            // The bat stays for a while
            if (_timeCount <= 0)
            {
                _destination.position = GetRandomPos();
                _timeCount = _waitTime;
            }
            else
            {
                _timeCount -= Time.deltaTime;
            }
        }
    }

    // Define moving area of a bat enemy
    Vector2 GetRandomPos()
    {
        Vector2 _pos = new Vector2(Random.Range(_areaBottomLeft.position.x, _areaTopRight.position.x), Random.Range(_areaBottomLeft.position.y, _areaTopRight.position.y));
        return _pos;
    }
}
