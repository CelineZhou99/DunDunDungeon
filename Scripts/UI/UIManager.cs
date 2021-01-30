using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;
    public Text LvText;

    private static bool UIExist;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        /*if (!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }*/
        if (GameObject.FindGameObjectsWithTag("UI").Length != 1)
        {
            Destroy(gameObject);
        }

        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;
        HPText.text = playerHealth.currentHealth.ToString() + "/" + playerHealth.maxHealth.ToString();
        LvText.text = "Lv: " + playerStats.currentLevel.ToString();
    }
}
