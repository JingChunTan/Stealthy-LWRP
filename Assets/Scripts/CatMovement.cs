using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovement : MonoBehaviour
{
    Animator _cat_Animator;
    Rigidbody _cat_Rigidbody;
    FollowPlayer _follow_Player;
    // Start is called before the first frame update
    void Start()
    {
        _cat_Animator = GetComponent<Animator>();
        _cat_Rigidbody = GetComponent<Rigidbody>();
        _follow_Player = GetComponent<FollowPlayer>();
    }

}
