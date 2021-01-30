using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private PlayerStats playerStats;

    public int expToGive;

    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.AddExperience(expToGive);
            DropCoin();
        }
    }

    public void HurtEnemy(int damageNumber)
    {
        currentHealth -= damageNumber;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }

    private void DropCoin()
    {
        if (Random.Range(0f, 1f) <= 0.66f)
        {
            Instantiate(coin, transform.position, transform.rotation);
        }
    }
}
