using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : StateMachineBehaviour
{
    Transform _player;
    Rigidbody2D _rigidBody;
    EnemyBoss _boss;
    public float _speed = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidBody = animator.GetComponent<Rigidbody2D>();
        _boss = animator.GetComponent<EnemyBoss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_boss._health <= 11)
        {
            _speed = 3f;
        }

        _boss.LookAtPlayer();
        Vector2 _targetPos = new Vector2(_player.position.x, _rigidBody.position.y);
        _targetPos.x = Mathf.Clamp(_targetPos.x, 146.5f, 186.5f);
        Vector2 _newPos = Vector2.MoveTowards(_rigidBody.position, _targetPos, Time.fixedDeltaTime * _speed);
        _rigidBody.MovePosition(_newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
