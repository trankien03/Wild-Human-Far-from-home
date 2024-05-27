using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (Rigidbody2D), typeof (TouchingDrirection))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 200.0f;
    public float runSpeed = 400.0f;
    public float jumpImpluse = 250.0f;
    public float airWalkSpeed = 150.0f;


    

    public float currentMoveSpeed {
        get
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDrirection.IsOnWall)
                {
                    if (touchingDrirection.IsGrounded)
                    {
                        if (IsRunning) return runSpeed;
                        else return walkSpeed;
                    }
                    else
                    {
                        return airWalkSpeed;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else return 0;
        }

        set 
        { 

        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }



    Vector2 moveInput;
    TouchingDrirection touchingDrirection;
    Rigidbody2D rb;

    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get 
        {
            return _isMoving;
        }

        private set {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    [SerializeField]
    private bool _IsRunning = false;

    public bool IsRunning { 
        get {
            return _IsRunning;
        }
        private set
        {
            _IsRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight { get {
            return _isFacingRight;
        }
        private set { 
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        } 
    }

   

    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDrirection = GetComponent<TouchingDrirection>();
    }


    private void FixedUpdate()  
    {
        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving  = moveInput != Vector2.zero;
        setFacingDirection(moveInput);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Check if alive
        if (context.started && touchingDrirection.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpluse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started && touchingDrirection.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.attack);
        }
    }   

    private void setFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x >0 && !IsFacingRight) 
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }
    
}
