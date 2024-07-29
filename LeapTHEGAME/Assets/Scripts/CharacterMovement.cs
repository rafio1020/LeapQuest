using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // config parameters
    [SerializeField] float horizontalMove = 0f;
    [SerializeField] float runSpeed = 0f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathkid = new Vector2(0f,0f);
    bool jump = false;
    float myGravityScaleAtStart = 0f;
    bool isAlive = true;

    // reference parameters
    CharacterController2D controller;
    Animator animator;
    Collider2D myCollider2D;
    Rigidbody2D myRigidbody2D;
    CapsuleCollider2D myBodyCollider;


    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myGravityScaleAtStart = myRigidbody2D.gravityScale;
        myBodyCollider = GetComponent<CapsuleCollider2D>();
    }

    public void OnLanding()
    {
        animator.SetBool("Grounded", true);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Grounded",!jump);
        }
    }
    private void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
        Die();
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        ClimbLadder();
        
    }
    private void ClimbLadder()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody2D.gravityScale = myGravityScaleAtStart;
            animator.SetBool("Climbing", false);
            return;
        }
        float controlThrow = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody2D.velocity.x, controlThrow * climbSpeed);
        myRigidbody2D.velocity = climbVelocity;
        myRigidbody2D.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climbing", playerHasVerticalSpeed);
    }
    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            animator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathkid;
            isAlive = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
