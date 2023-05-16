using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    public Vector2 velocity;
    public float speed;
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody2D.MovePosition(myRigidBody2D.position - velocity * Time.deltaTime);
            myRigidBody2D.velocity = new Vector2(-speed, myRigidBody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // myRigidBody2D.MovePosition(myRigidBody2D.position + velocity * Time.deltaTime);
            myRigidBody2D.velocity = new Vector2(speed, myRigidBody2D.velocity.y);
        }
    }
}
