using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("MainCamera").Length != 1)
        {
            Debug.Log("Found more than one main camera");
            Destroy(gameObject);
        }
    }
}
