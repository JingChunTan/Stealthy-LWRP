//Attach this code to the follower.
//Be sure to add a rigidbody to the follower and set the goal of this script in the inspector 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class FollowPlayer : MonoBehaviour {

	//public float speed = 1.1f;
	public float goalReachRadiusAccuracy = 0.5f;
    public float lookRadius = 10f;
    private int interval = 1;
    //float rotationSpeed = 0.1f;
    float _distanceToGoal;
     Animator _cat_Animator;
    NavMeshAgent _agent;

    //Drag and drop the leader from the Hierarchy
    //onto this goal in the inspector for the follower to follow.
    public Transform goal;

    private void Start()
    {
        _cat_Animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _distanceToGoal = _agent.remainingDistance;
    }

    void LateUpdate () {
        if(Time.frameCount % interval == 0)
        {
            FollowUntilReachGoal();
        }		
	}

    void FollowUntilReachGoal()
    {
        //this.transform.LookAt(goal.position);

       //Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
       
        float distanceToGoal = Vector3.Distance(goal.position, transform.position);

       // Vector3 direction = goal.position - this.transform.position;
        //smooth slerp rotation
       // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

        if(distanceToGoal <= lookRadius)
        {
            _agent.SetDestination(goal.position);

            if(distanceToGoal <= _agent.stoppingDistance)
            {
                //circling animation
                this.transform.LookAt(goal.position);
                _cat_Animator.SetBool("isWalking", false);
                _cat_Animator.SetBool("isIdle", true);
            }
            else
            {               
                _cat_Animator.SetBool("isWalking", true);
                _cat_Animator.SetBool("isIdle", false);
            }
        }

        if (_agent.remainingDistance <= goalReachRadiusAccuracy)
        {
            _agent.isStopped = true;
        }
        else
        {
            _agent.isStopped = false;
        }
        /*
        if (Vector3.Distance(transform.position, goal.position) > goalReachRadiusAccuracy)
        {
            //this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            //this.transform.Translate(0, 0, speed * Time.deltaTime);
            _agent.isStopped = true;
            _cat_Animator.SetBool("isWalking", true);
            _cat_Animator.SetBool("isIdle", false);
        }
        else
        {
            _agent.isStopped = false;
            _cat_Animator.SetBool("isWalking", false);
            _cat_Animator.SetBool("isIdle", true);
        }*/
    }
}
