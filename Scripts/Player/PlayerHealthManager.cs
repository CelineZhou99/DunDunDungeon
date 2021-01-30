using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;

    private SFXManager sfxMan;

    public GameObject gameover;

    private MusicController mc;

    private MoneyManager mm;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerSprite = GetComponent<SpriteRenderer>();

        sfxMan = FindObjectOfType<SFXManager>();

        mc = FindObjectOfType<MusicController>();

        mm = FindObjectOfType<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }

        if (flashActive)
        {
            if (flashCounter > flashLength * .66f) // if counter is above .66 of a second, then we should be currently invisible
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            } else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f); // 255 = 1, so if you want 155, it is 155/255
            } else if (flashCounter > 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            } else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f); 
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageNumber)
    {
        if (currentHealth - damageNumber < 0)
        {
            currentHealth = 0;
        } else
        {
            currentHealth -= damageNumber;
        }
       
        flashActive = true;
        flashCounter = flashLength;

        sfxMan.playerHurt.Play();
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void Death()
    {
        gameObject.SetActive(false);
        gameover.SetActive(true);
        mm.ResetMoney();
    }
}
