using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    public bool playerInRange;

    public SpriteRenderer leftDoor;
    public SpriteRenderer rightDoor;

    public Sprite leftDoorOpen;
    public Sprite rightDoorOpen;

    public bool doorUnlocked;

    public string sceneName;

    private PlayerController player;

    public string exitPoint;

    // Start is called before the first frame update
    void Start()
    {
        doorUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !doorUnlocked)
            {
                doorUnlocked = true;
                leftDoor.sprite = leftDoorOpen;
                rightDoor.sprite = rightDoorOpen;
            } else if (Input.GetKeyDown(KeyCode.Space) && doorUnlocked)
            {
                SceneManager.LoadScene(sceneName);
                player.startPoint = exitPoint;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerInRange = true;
            player = collision.gameObject.GetComponent<PlayerController>();
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
