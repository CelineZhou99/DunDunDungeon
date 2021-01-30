using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageNumber;
    public GameObject damageNumberDisplay;

    private PlayerStats playerStats;

    private int currentAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            currentAttack = damageNumber - playerStats.currDefence; // take away defence from damage

            if (currentAttack < 0)
            {
                currentAttack = 1;
            }

            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentAttack);
            
            var clone = Instantiate(damageNumberDisplay, collision.transform.position, collision.transform.rotation);
            clone.GetComponent<DamageNumbers>().damageNumber = currentAttack;
        }
    }
}
