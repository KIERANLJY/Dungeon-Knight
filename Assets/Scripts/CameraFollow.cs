using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _target;
    public float _smoothing;
    // Start is called before the first frame update
    void Start()
    {
        // _smoothing = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (_target != null)
        {
            if (transform.position != _target.position)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position, _smoothing);
            }
        }    
    }
}
