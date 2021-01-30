using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerAttack;
    public AudioSource playerPickUpCoin;

    private static bool sfxExists;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        /*if (!sfxExists)
        {
            sfxExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }*/
        if (GameObject.FindGameObjectsWithTag("SFX").Length != 1)
        {
            Destroy(gameObject);
        }
    }
}
