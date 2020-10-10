using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speedEnemy = 3f;
    public Transform target;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        FollowPlayer();
    }

    void FollowPlayer()
    {
        float step = speedEnemy * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) >= 0.001)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, step * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(target.position * Time.deltaTime);
        }
    }
}
