using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    private Transform player;
    public bool isFlipped;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isFlipped = false;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void LookAtPlayer()
    {
        if (player != null)
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;
            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
    }
}
