using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float runSpeed;
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 5;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
    }

    // Change orientation of the play according to moving direction
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasXAxisSpeed)
        {
            // Move forward
            if(myRigidBody.velocity.x > Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            // Move Backward
            if(myRigidBody.velocity.x < -Mathf.Epsilon)
            {
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }


    void Run()
    {
        // Get the direction of player moving
        float moveDir = Input.GetAxis("Horizontal");
        // Set velocity and assign to the player
        Vector2 playVel = new Vector2(moveDir * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playVel;

        // Check if the player is running
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Run", playerHasXAxisSpeed);
    }
}
