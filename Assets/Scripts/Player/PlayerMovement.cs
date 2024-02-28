using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player movement
    Joystick joystick;
    Rigidbody2D rigidbody2D;
    Animator animator;
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", moveSpeed);
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(joystick.joystickVec.x != 0)
        {
            moveSpeed = 5f;
            rigidbody2D.velocity = new Vector2(joystick.joystickVec.x * moveSpeed, 0);
            ScaleFace();
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
            moveSpeed = 0;
        }
    }
    private void ScaleFace()
    {
        if(joystick.joystickVec.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
