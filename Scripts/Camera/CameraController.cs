using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    public float moveSpeed;
    private Vector3 targetPos;

    private static bool cameraExists;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera camera;
    private float halfHeight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        /*if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }*/
        if (GameObject.FindGameObjectsWithTag("MainCamera").Length != 1)
        {
            Destroy(gameObject);
        }

        followTarget = FindObjectOfType<PlayerController>().gameObject;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        camera = GetComponent<Camera>();
        halfHeight = camera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget == null)
        {
            followTarget = FindObjectOfType<PlayerController>().gameObject;
        }
        // followTarget.transform is the player's coordinates
        // transform.position is the current object - the camera's coordinates
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        // Time.deltaTime makes the movement consistent with different frames per second
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (boundBox == null)
        {
            boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    public void SetBounds(BoxCollider2D newBound)
    {
        boundBox = newBound;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }
}
