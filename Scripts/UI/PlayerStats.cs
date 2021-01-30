using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;

    public int currentExp;

    private int[] expToLevelUp = { 10, 30, 50, 100, 175, 300, 500, 1000, 1500 };

    private int[] attackLevels = { 5, 8, 13, 18, 25, 30, 36, 42, 69 };

    private int[] defenceLevels = { 1, 3, 5, 10, 12, 15, 19, 22, 30 };

    public int currAttack;

    public int currDefence;

    public PlayerHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currAttack = 0;
        currDefence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= expToLevelUp[currentLevel - 1])
        {
            LevelUp();
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
    }

    private void LevelUp()
    {
        currentLevel++;
        playerHealth.maxHealth += 10;
        playerHealth.SetMaxHealth();
        currAttack = attackLevels[currentLevel - 2];
        currDefence = defenceLevels[currentLevel - 2];
    }
}
