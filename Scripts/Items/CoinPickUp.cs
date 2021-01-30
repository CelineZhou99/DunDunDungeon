using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int value;

    private MoneyManager mm;

    private SFXManager sfxMan;

    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<MoneyManager>();
        sfxMan = FindObjectOfType<SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            sfxMan.playerPickUpCoin.Play();
            mm.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
