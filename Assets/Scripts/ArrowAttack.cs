using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{
    public GameObject _arrowPrefab;
    public int _arrowQuantity;
    public GameObject[] _arrows;


    // Start is called before the first frame update
    void Start()
    {
        // _arrowQuantity = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        CheckQuantity();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Shoot") && _arrowQuantity > 0)
        {
            Instantiate(_arrowPrefab, transform.position, transform.rotation);
            _arrowQuantity --;
        }
    }

    void CheckQuantity()
    {
        if (_arrowQuantity == 4)
        {
            _arrows[0].SetActive(true);
            _arrows[1].SetActive(true);
            _arrows[2].SetActive(true);
            _arrows[3].SetActive(true);
            _arrows[4].SetActive(false);
        }
        else if (_arrowQuantity == 3)
        {
            _arrows[0].SetActive(true);
            _arrows[1].SetActive(true);
            _arrows[2].SetActive(true);
            _arrows[3].SetActive(false);
            _arrows[4].SetActive(false);
        }
        else if (_arrowQuantity == 2)
        {
            _arrows[0].SetActive(true);
            _arrows[1].SetActive(true);
            _arrows[2].SetActive(false);
            _arrows[3].SetActive(false);
            _arrows[4].SetActive(false);
        }
        else if (_arrowQuantity == 1)
        {
            _arrows[0].SetActive(true);
            _arrows[1].SetActive(false);
            _arrows[2].SetActive(false);
            _arrows[3].SetActive(false);
            _arrows[4].SetActive(false);
        }
        else if (_arrowQuantity == 0)
        {
            _arrows[0].SetActive(false);
            _arrows[1].SetActive(false);
            _arrows[2].SetActive(false);
            _arrows[3].SetActive(false);
            _arrows[4].SetActive(false);
        }
    }
}
