using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Stats")]
    [SerializeField] private float JumpForce = 400;
    [SerializeField] private float speed = 6;

    [Space(2)]
    [Header("Component Attachments")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private BoxCollider2D ZSwordCollider;
    [SerializeField] private Animator AnimController;
    
    [SerializeField] LayerMask _groundLayer;
  

    private bool JumpPress { get; set; }
    private bool AttackPress { get; set; }
    private bool IsAttacking { get; set; }
    private int AttackFrames { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        JumpPress = false;
        AttackPress = false;
        IsAttacking = false;
        AttackFrames = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            JumpPress = true;
        }
        if (Input.GetButtonDown("Attack"))
        {
            AttackPress = true;
        }


        // Placeholder horizontal movement
        if (Input.GetKey(KeyCode.D))
        {
            AnimController.SetBool("IsRunning", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        AnimController.SetFloat("CharacterYVelocity", rb2D.velocity.y);
        AnimController.SetBool("IsGrounded", IsGrounded());

    }


    private void FixedUpdate()
    {
        if (IsAttacking)
        {
            if(AttackFrames > 0)
            {
                AttackFrames--;
            }
            else
            {
                AttackFrames = 3;
                IsAttacking = false;
                ZSwordCollider.enabled = false;
            }
        }
        if (JumpPress)
        {
            JumpPress = false;
            Jump();
        }
        if (AttackPress)
        {
            AttackPress = false;
            IsAttacking = true;
            ZSwordCollider.enabled = true;
        }
        
    }


    private void Jump()
    {
        if (!IsGrounded())
            return;

        rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Force);


    }

    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.8f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance,_groundLayer);
        if (hit.collider != null)
            return true;

        return false;
    }


}
