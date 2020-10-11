using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{

    public int lifeplayer;

    public float speed = 5f;
    public float turnsmoothtime = 0.1f;
    public float turnsmoothvelocity = 0.1f;

     ParticleSystem shock;

     Collider spear;

    Animator anim;
    void Start()
    {
        spear = GameObject.FindGameObjectWithTag("Spear").GetComponent<Collider>();
        lifeplayer = 10;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Attack();
        Dead();
    }
    void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            anim.SetBool("Attack", true);
            spear.enabled = true;
        }
        else
        {
            anim.SetBool("Attack", false);
            spear.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword"))
        {
            OnDamagePlayer();
        }
    }
    void OnDamagePlayer()
    {
        lifeplayer -= 1;
        Debug.Log("life player: " + lifeplayer);
    }

    void Dead()
    {
        if (lifeplayer <= 0)
        {
            
            Destroy(gameObject);
            Time.timeScale = 0;
            
        }
    }


}
