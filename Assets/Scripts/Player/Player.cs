using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    //public Animator animator;
    public HealthBase health;

    public SOPlayerSetup sOPlayerSetup;

    [ShowNonSerializedField] private float _currentSpeed;

    private Animator _currentPlayer;
    [SerializeField, BoxGroup("Bullet setup")] public Transform bulletAnchor;

    [SerializeField, BoxGroup("Jump collision setup")] public Collider2D playerCollider;
    [SerializeField, BoxGroup("Jump collision setup")] public ParticleSystem jumpVFX;
    [SerializeField, BoxGroup("Jump collision setup")] public float distanceToGround;
    [SerializeField, BoxGroup("Jump collision setup")] public float spaceToGround = .1f;

    private void Awake()
    {
        if (health != null)
        {
            health.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(sOPlayerSetup.player, transform);
        _currentPlayer.GetComponentInChildren<PlayerDestroyHelper>().player = this;
        _currentPlayer.GetComponentInChildren<GunBase>().projectileParent = bulletAnchor;

        //if(playerCollider != null)
        //{
        //    distanceToGround = playerCollider.bounds.extents.y;
        //}
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + spaceToGround);
    }

    private void OnPlayerKill()
    {
        health.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(sOPlayerSetup.triggerOnDeath);
        //destroyMe será chamado no final da animação
    }
    void Update()
    {
        IsGrounded();
        HandleJump();
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = sOPlayerSetup.speedRun;
            _currentPlayer.speed = 2;
        }
        else
        {
            _currentSpeed = sOPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidBody2D.MovePosition(myRigidBody2D.position - velocity * Time.deltaTime);
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);

            if (myRigidBody2D.transform.localScale.x != -1)
            {
                myRigidBody2D.transform.DOScaleX(-1, sOPlayerSetup.playerSwipeDuration);
            }

            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // myRigidBody2D.MovePosition(myRigidBody2D.position + velocity * Time.deltaTime);
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, true);

            if (myRigidBody2D.transform.localScale.x != 1)
            {
                myRigidBody2D.transform.DOScaleX(1, sOPlayerSetup.playerSwipeDuration);
            }

            myRigidBody2D.transform.localScale = new Vector3(1, 1, 1);
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
        }
        else
        {
            _currentPlayer.SetBool(sOPlayerSetup.boolRun, false);
        }

        if (myRigidBody2D.velocity.x > 0)
        {
            myRigidBody2D.velocity += sOPlayerSetup.friction;
        }
        else if (myRigidBody2D.velocity.x < 0)
        {
            myRigidBody2D.velocity -= sOPlayerSetup.friction;
        }
    }

    public void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            myRigidBody2D.velocity = Vector2.up * sOPlayerSetup.jumpForce;
            myRigidBody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody2D.transform);

            HandleScalejump();
            PlayJumpVFX();
        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position);
    }

    public void HandleScalejump()
    {
        myRigidBody2D.transform.DOScaleY(sOPlayerSetup.jumpScaleY, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
        myRigidBody2D.transform.DOScaleX(sOPlayerSetup.jumpScaleX, sOPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(sOPlayerSetup.ease);
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
