using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isMoving;
    public float moveTime;
    public float waitTime;

    private float moveCounter;
    private float waitCounter;

    private string moveDirection;

    public string lastFaceDirection;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;

    public bool canMove;

    private DialogueManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        dMan = FindObjectOfType<DialogueManager>();
        moveCounter = moveTime;
        waitCounter = waitTime;

        ChooseDirection();

        if (walkZone != null)
        {
            hasWalkZone = true;
            minWalkPoint = walkZone.bounds.min; // bottom left corner
            maxWalkPoint = walkZone.bounds.max; // bottom right corner
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dMan.dialogueActive)
        {
            canMove = true;
            if (moveCounter > 0)
            {
                anim.SetBool("IsMoving", true);
            }
        }
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("IsMoving", false);
            return;
        }
        if (isMoving)
        {
            moveCounter -= Time.deltaTime;
            
            switch (moveDirection)
            {
                case "left":
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x) // if going out of bounds (left)
                    {
                        isMoving = false;
                        anim.SetBool("IsMoving", false);
                        waitCounter = waitTime;
                    }
                    lastFaceDirection = "left";
                    sr.flipX = true;
                    break;
                case "right":
                    rb.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x) // if going out of bounds (right)
                    {
                        isMoving = false;
                        anim.SetBool("IsMoving", false);
                        waitCounter = waitTime;
                    }
                    lastFaceDirection = "right";
                    sr.flipX = false;
                    break;
            }
            if (moveCounter < 0)
            {
                isMoving = false;
                anim.SetBool("IsMoving", false);
                waitCounter = waitTime;
            }
        } else
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    private void ChooseDirection()
    {
        if (lastFaceDirection == "left")
        {
            moveDirection = "right";
        } else
        {
            moveDirection = "left";
        }
        isMoving = true;
        anim.SetBool("IsMoving", true);
        moveCounter = moveTime;
    }
}
