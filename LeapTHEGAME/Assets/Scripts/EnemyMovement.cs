using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody2D;
    [SerializeField] float moveSpeed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight())
        {
            myRigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody2D.velocity = new Vector2(-moveSpeed, 0f);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody2D.velocity.x)), 1f);
    }
    private bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
}