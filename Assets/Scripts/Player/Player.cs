using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    public Vector2 friction = new Vector2(-.1f,0);
    public float speed;
    public float speedRun;
    public float jumpForce = 25;

    private float _currentSpeed;    
    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody2D.MovePosition(myRigidBody2D.position - velocity * Time.deltaTime);
            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // myRigidBody2D.MovePosition(myRigidBody2D.position + velocity * Time.deltaTime);
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
        }

        if(myRigidBody2D.velocity.x > 0)
        {
            myRigidBody2D.velocity += friction;
        } else if (myRigidBody2D.velocity.x < 0)
        {
            myRigidBody2D.velocity -= friction;
        }
    }

    public void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = Vector2.up * jumpForce;
        }
    }
}
