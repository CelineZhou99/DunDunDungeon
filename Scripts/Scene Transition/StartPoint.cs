using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController player;
    private CameraController camera;

    public Vector2 startDirection;

    public string pointName;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.startPoint == pointName)
        {
            player.transform.position = transform.position;
            player.lastMove = startDirection; // sets the direction the player is facing when entering new scene

            camera = FindObjectOfType<CameraController>();
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        }
    }


}
