using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public GameObject target;
    private NavMeshAgent navMesh;
    private Animator animator;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        FollowTarget();
        Animation();
    }

    void FollowTarget()
    {
        navMesh.SetDestination(target.gameObject.transform.position);
    }

    void Animation()
    {
        animator.SetBool("Running", true);
    }
}
