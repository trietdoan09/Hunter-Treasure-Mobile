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

    public bool isGround;
    public bool clickJump;
    [SerializeField] private float countJump;
    public int playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        countJump = 0;
        clickJump = false;
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
        if (isGround && clickJump || !isGround && clickJump && countJump == 1)
        {
            animator.SetBool("isJump", clickJump);
            rigidbody2D.AddForce(new Vector2(0, 7000));
            clickJump = false;
        }
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
            playerDirection = -1;
            transform.localScale = new Vector3(playerDirection, 1, 1);
        }
        else
        {
            playerDirection = 1;
            transform.localScale = new Vector3(playerDirection, 1, 1);
        }
    }
    public void Jump()
    {
        if(isGround)
        {
            clickJump = true;
            countJump++;
        }
        else if(!isGround && countJump < 1)
        {
            clickJump = true;
            countJump++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("isJump", false);
            isGround = true; 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            countJump = 0;
        }
    }
}
