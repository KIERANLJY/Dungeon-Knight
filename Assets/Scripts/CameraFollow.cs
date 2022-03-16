using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _target;
    public float _smoothing;
    public Vector2 _minCamPos;
    public Vector2 _maxCamPos;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        // _smoothing = 0.1f;
        _offset = new Vector3(0, 1, 0);
    }

    void LateUpdate()
    {
        if (_target != null)
        {
            if (transform.position != _target.position)
            {
                Vector2 _targetPos = _target.position + _offset;
                _targetPos.x = Mathf.Clamp(_targetPos.x, _minCamPos.x, _maxCamPos.x);
                _targetPos.y = Mathf.Clamp(_targetPos.y, _minCamPos.y, _maxCamPos.y);
                transform.position = Vector2.Lerp(transform.position, _targetPos, _smoothing);
            }
        }    
    }

    public void SetCamPosLimit(float _minPosX, float _minPosY, float _maxPosX, float _maxPosY)
    {
        _minCamPos.x = _minPosX;
        _minCamPos.y = _minPosY;
        _maxCamPos.x = _maxPosX;
        _maxCamPos.y = _maxPosY;
    }
}
