using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    
    public Dialogue dialogue;

    private bool playerInRange;

    private DialogueManager dManager;

    private void Start()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                TriggerDialogue();
            }
        }
    }

    public void TriggerDialogue()
    {
        if (!dManager.dialogueActive)
        {
            dManager.ShowDialogue(); // show the dialogue box
            dManager.StartDialogue(dialogue); // start the dialogue
        }

        if (transform.parent.GetComponent<KnightMovement>() != null)
        {
            transform.parent.GetComponent<KnightMovement>().canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInRange = false;
        }
    }
}
