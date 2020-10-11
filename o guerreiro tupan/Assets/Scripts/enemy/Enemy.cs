using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public float speedEnemy = 3f;
    private Transform target;

    NavMeshAgent agent;
    
    movementPlayer playerScript;

    public Collider sword;
    public int lifeEnemy;
    void Start()
    {
        lifeEnemy = 3;
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();

        
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
         FollowPlayer();
        DeadEnemy();
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
            sword.enabled = true;
        }
        else 
        {
            anim.SetBool("Attack", false);
            sword.enabled = false;
        }

        
    }

    void OnDamageEnemy()
    {
        lifeEnemy -= 1;
        Debug.Log("life player: " + lifeEnemy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spear"))
        {

            OnDamageEnemy();
            Debug.Log("life enemy" + lifeEnemy);
          
        }
    }
    void DeadEnemy()
    {
        if (lifeEnemy <= 0)
        {
            lifeEnemy = 0;
            Destroy(gameObject);
        }
    }
}
