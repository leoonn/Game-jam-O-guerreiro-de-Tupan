using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speedEnemy = 3f;
    private Transform target;
    bool attack = false;

    movementPlayer playerScript;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>();
        
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
            anim.SetFloat("speedEnemy", 1f);
            anim.SetBool("Attack", false);
        }
         if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            anim.SetFloat("speedEnemy", 0f);
            OnDamagePlayer();
            attack = true;
        }

        if (attack == true)
        {
            anim.SetBool("Attack", true);

        }
        else 
        {
            anim.SetBool("Attack", false);
        }
    }

    void OnDamagePlayer()
    {
        playerScript.lifeplayer = -1;
    }
}
