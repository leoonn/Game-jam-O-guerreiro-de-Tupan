using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody rb;

    public Camera cam;

    Vector3 movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
            
    }
}
