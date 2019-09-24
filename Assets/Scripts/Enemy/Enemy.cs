using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public GameObject target;
    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.LookAt(target.transform.position);
    }
}
