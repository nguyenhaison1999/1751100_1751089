using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed= 5f;
    public float movement= 0f;
    private Rigidbody2D rigidBody;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;
    private SpriteRenderer playerSpriteRenderer;

    public Vector3 respawnPoint;

    public LevelManager gameLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        respawnPoint = transform.position;

        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f )
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            playerSpriteRenderer.flipX = false;
        }
        else if ( movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed",Math.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Math.Abs(rigidBody.velocity.x) < 0.01 && isTouchingGround)
            {
                playerAnimation.Play("PlayerShoot");
            }
            else if (Math.Abs(rigidBody.velocity.x) > 0.01 && isTouchingGround)
            {
                playerAnimation.Play("Naruto");
            }
            else if (!isTouchingGround)
            {
                playerAnimation.Play("JumpShoot");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FallDetector"))
        {
            //player falls into the void
            gameLevelManager.Respawn();
        }
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
        }
        if (other.CompareTag("MovingPlank"))
        {
            this.transform.parent = other.transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("MovingPlank"))
        {
            this.transform.parent = null;
        }
    }
}
