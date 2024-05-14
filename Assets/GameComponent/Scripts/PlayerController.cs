using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 100.0f;
    public float runSpeed = 200.0f;

    public float currentMoveSpeed {
        get
        {
            if (IsMoving)
            {
                if (IsRunning) return runSpeed;
                else return walkSpeed;
            }
            else
            {
                return 0;
            }
        }

        private set 
        { 

        }
    }
    Vector2 moveInput;
    Rigidbody2D rb;

    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving { get 
        {
            return _isMoving;
        }

        private set {
            _isMoving = value;
            animator.SetBool("isMoving", value);
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
            animator.SetBool("isRunning", value);
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()  
    {
        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
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
