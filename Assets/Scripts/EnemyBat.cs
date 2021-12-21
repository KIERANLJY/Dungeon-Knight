using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        _health = 5;
        _damage = 1;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }
}
