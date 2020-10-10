using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    public Transform cam;


    public float speed = 5f;
    public float turnsmoothtime = 0.1f;
    public float turnsmoothvelocity = 0.1f;
    public CharacterController controller;

    public bool isground;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
    

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation (movement);
        }


        transform.Translate(movement * speed * Time.deltaTime, Space.World);

    }

    void MoveTEst()
    {
        
    }
}
