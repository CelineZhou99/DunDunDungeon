using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageNumber;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumberDisplay;

    private PlayerStats playerStats;

    private int currentAttack;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentAttack = damageNumber + playerStats.currAttack; // add on the player's attack level stats to the damage

            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentAttack);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            
            var clone = Instantiate(damageNumberDisplay, hitPoint.position, hitPoint.rotation);
            clone.GetComponent<DamageNumbers>().damageNumber = currentAttack;
        }
    }
}
