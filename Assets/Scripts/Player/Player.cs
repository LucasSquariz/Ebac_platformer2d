using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class Player : MonoBehaviour
{
    [SerializeField, BoxGroup("Speed setup")] public Rigidbody2D myRigidBody2D;
    [SerializeField, BoxGroup("Speed setup")] public Vector2 friction = new Vector2(-.1f,0);
    [SerializeField, BoxGroup("Speed setup")] public float speed;
    [SerializeField, BoxGroup("Speed setup")] public float speedRun;
    [SerializeField, BoxGroup("Speed setup")] public float jumpForce = 25;
    
    [SerializeField, BoxGroup("Animation setup")] public float jumpScaleY = 1.5f;
    [SerializeField, BoxGroup("Animation setup")] public float jumpScaleX = .7f;
    [SerializeField, BoxGroup("Animation setup")] public float animationDuration = .3f;
    [SerializeField, BoxGroup("Animation setup")] public Ease ease = Ease.OutBack;
    [ShowNonSerializedField] private float _currentSpeed;
    public string boolRun = "Run";
    public Animator animator;
    public float playerSwipeDuration = .1f;


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
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody2D.MovePosition(myRigidBody2D.position - velocity * Time.deltaTime);
            animator.SetBool(boolRun, true);
            
            if(myRigidBody2D.transform.localScale.x != -1)
            {
                myRigidBody2D.transform.DOScaleX(-1, playerSwipeDuration);
            }

            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // myRigidBody2D.MovePosition(myRigidBody2D.position + velocity * Time.deltaTime);
            animator.SetBool(boolRun, true);

            if (myRigidBody2D.transform.localScale.x != 1)
            {
                myRigidBody2D.transform.DOScaleX(1, playerSwipeDuration);
            }

            myRigidBody2D.transform.localScale = new Vector3(1, 1, 1);
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
        }
        else
        {
            animator.SetBool(boolRun, false);
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
            myRigidBody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody2D.transform);

            HandleScalejump();
        }
    }

    public void HandleScalejump()
    {
        myRigidBody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
