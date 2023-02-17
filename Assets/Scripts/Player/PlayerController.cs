using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Stats")]
    [SerializeField] private float JumpForce = 600;
    [SerializeField] private float Speed = 6;
    [SerializeField] private int AttackDuration = 10;
    [SerializeField] private int AttackCooldown = 30;
    [Space(2)]
    [Header("Component Attachments")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Animator AnimController;

    [Space(1)]
    [Header("Z - Sword")]
    [SerializeField] private ZSwordController zSwordController;
    
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] LayerMask ObstacleLayer;


    private bool JumpPress { get; set; }
    private bool AttackPress { get; set; }
    private bool CanAttack { get; set; }
    private bool IsDead { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        JumpPress = false;
        AttackPress = false;
        CanAttack = true;
        IsDead = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if (Input.GetButtonDown("Jump"))
            {
                JumpPress = true;
            }
            if (Input.GetButtonDown("Attack") && CanAttack)
            {
                AttackPress = true;
                CanAttack = false;

            }


            // Placeholder horizontal movement
            if (Input.GetKey(KeyCode.D))
            {
                AnimController.SetBool("IsRunning", true);
                transform.Translate(Vector2.right * Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Speed * Time.deltaTime);
            }

            AnimController.SetFloat("CharacterYVelocity", rb2D.velocity.y);
            AnimController.SetBool("IsGrounded", IsGrounded());
        }
        

    }


    private void FixedUpdate()
    {
        
        if (JumpPress)
        {
            JumpPress = false;
            Jump();
        }
        if (AttackPress)
        {
            
                AttackPress = false;
               
                Attack();
            
           
        }
        
    }


    private void Attack()
    {
        CanAttack = false;
        zSwordController.Attack(AttackDuration);
        StartCoroutine(ZSwordCooldown());

    }

    
    private IEnumerator ZSwordCooldown()
    {
        if (!CanAttack)
        {
            for(int i = 0; i < AttackCooldown; i++)
            {
                yield return new WaitForFixedUpdate();
            }
            CanAttack = true;
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

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, GroundLayer);
        if (hit.collider != null)
            return true;

        return false;
    }

    private void Death()
    {
        IsDead = true;
        rb2D.simulated = false;
        AnimController.SetTrigger("DeathTrigger");

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        if(collision.gameObject.tag == "Destructible" || collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("obstacle collision");
            Death();
        }
    }

}
