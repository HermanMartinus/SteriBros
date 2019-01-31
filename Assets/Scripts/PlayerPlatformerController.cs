using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public static PlayerPlatformerController Instance;

    public bool hasMoved = false;

    public bool player1 = true;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {

        Vector2 move = Vector2.zero;

        if (player1)
        {
            move.x = Controller.Instance.Player1X;
        }
        else
        {
            move.x = Controller.Instance.Player2X;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        { 
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(Mathf.Abs(move.x) > 0.01f)
        {
            spriteRenderer.flipX = move.x < 0;
            if (!hasMoved)
            {
                hasMoved = true;
            }
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}