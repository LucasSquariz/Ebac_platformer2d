using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class Player : MonoBehaviour
{    
    public Rigidbody2D myRigidBody2D;
    public Animator animator;
    public HealthBase health;

    public SOPlayerSetup sOPlayerSetup;

    [ShowNonSerializedField] private float _currentSpeed;
    

    private void Awake()
    {
        if(health != null)
        {
            health.OnKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        health.OnKill -= OnPlayerKill;
        animator.SetTrigger(sOPlayerSetup.triggerOnDeath);
    }
    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = sOPlayerSetup.speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
            animator.speed = 1;
        }        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody2D.MovePosition(myRigidBody2D.position - velocity * Time.deltaTime);
            animator.SetBool(sOPlayerSetup.boolRun, true);
            
            if(myRigidBody2D.transform.localScale.x != -1)
            {
                myRigidBody2D.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }

            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // myRigidBody2D.MovePosition(myRigidBody2D.position + velocity * Time.deltaTime);
            animator.SetBool(sOPlayerSetup.boolRun, true);

            if (myRigidBody2D.transform.localScale.x != 1)
            {
                myRigidBody2D.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }

            myRigidBody2D.transform.localScale = new Vector3(1, 1, 1);
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
        }
        else
        {
            animator.SetBool(sOPlayerSetup.boolRun, false);
        }

        if(myRigidBody2D.velocity.x > 0)
        {
            myRigidBody2D.velocity += sOPlayerSetup.friction;
        } else if (myRigidBody2D.velocity.x < 0)
        {
            myRigidBody2D.velocity -= sOPlayerSetup.friction;
        }
    }

    public void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = Vector2.up * sOPlayerSetup.jumpForce;
            myRigidBody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody2D.transform);

            HandleScalejump();
        }
    }

    public void HandleScalejump()
    {
        myRigidBody2D.transform.DOScaleY(sOPlayerSetup.jumpScaleY, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
        myRigidBody2D.transform.DOScaleX(sOPlayerSetup.jumpScaleX, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
