using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator anim;

    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool isAttacking;
    private float attackTime = 0.5f;
    private float attackTimeCounter = 0.5f;

    public bool canMove;

    private SFXManager sfxMan;

    public string startPoint;

    private void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();

        DontDestroyOnLoad(transform.gameObject);
        /*if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }*/
        if (GameObject.FindGameObjectsWithTag("Player").Length != 1)
        {
            Destroy(gameObject);
        }
        canMove = true;
        lastMove = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (!isAttacking)
        {
            /*if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) // moving horizontally
            {
                // delta time is a tiny value - the amount of time between when the last update happened
                // moveSpeed and deltaTime is used so that over the course of 1 second, whether it is 20 frames per sec or 60, you move the same distance
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, rb.velocity.y);
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) // moving vertically
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) // stopping horizontally
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f) // stopping vertically
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }*/

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (moveInput != Vector2.zero)
            {
                rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                lastMove = moveInput;
            } else
            {
                rb.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.J)) // attacking
            {
                attackTimeCounter = attackTime;
                isAttacking = true;
                rb.velocity = Vector2.zero;
                anim.SetBool("IsAttacking", true);
                sfxMan.playerAttack.Play();
            }

            /*if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            } else
            {
                currentMoveSpeed = moveSpeed;
            }*/
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            isAttacking = false;
            anim.SetBool("IsAttacking", false);
        }
        anim.SetFloat("MoveX", moveInput.x);
        anim.SetFloat("MoveY", moveInput.y);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
