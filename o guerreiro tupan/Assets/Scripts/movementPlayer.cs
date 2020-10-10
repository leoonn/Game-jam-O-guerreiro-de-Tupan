using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    public float speed = 5f;

    public Camera cam;
    public float turnSmooth = 2f;
    public float smoothroottime = 5f;

    void Start()
    {
        speed = 5f;
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

        Vector3 direction = new Vector3(speed * horizontal * Time.deltaTime, 0, speed * vertical);

        if (direction.magnitude > 0)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmooth, smoothroottime);
        }
    }
}
