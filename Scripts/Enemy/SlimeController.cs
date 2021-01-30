using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator anim;

    private bool moving;

    private float timeBetweenMove;
    private float timeBetweenMoveCounter;

    private float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenMove = Random.Range(1f, 2f);
        timeBetweenMoveCounter = timeBetweenMove;

        timeToMove = Random.Range(1f, 2f);
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection.normalized;
            anim.SetFloat("MoveX", moveDirection.x);
            anim.SetFloat("MoveY", moveDirection.y);

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        } else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f).normalized;
            }
        }
    }
}
