using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speedEnemy = 3f;
    private Transform target;
    bool attack = false;
    NavMeshAgent agent;
    
    movementPlayer playerScript;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        // FollowPlayer();
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float step = speedEnemy * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) > agent.stoppingDistance)
        {
           
            agent.SetDestination(target.position);
            transform.LookAt(target);
            anim.SetFloat("speedEnemy", 1f);
            
        }
        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            anim.SetFloat("speedEnemy", 0f);

            anim.SetBool("Attack", true);
            
        }
        else 
        {
            anim.SetBool("Attack", false);
        }

        
    }

    void OnDamagePlayer()
    {
        playerScript.lifeplayer -= 1;
        Debug.Log("life player: " + playerScript.lifeplayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            
        }
    }

   
}
