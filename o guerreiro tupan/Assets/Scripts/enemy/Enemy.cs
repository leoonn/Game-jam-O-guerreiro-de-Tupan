using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speedEnemy = 3f;
    private Transform target;
    bool attack = false;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float step = speedEnemy * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, step * Time.deltaTime);
            transform.LookAt(target);
            anim.SetFloat("speed enemy", 1);
        }
        else if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            anim.SetFloat("speed enemy", 0);
            attack = true;
        }

        if (attack)
        {
            anim.SetBool("Attack", true);

        }
        else 
        {
            anim.SetBool("Attack", false);
        }
    }
}
