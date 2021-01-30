using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text coinAmount;
    public int currentGold;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentGold = PlayerPrefs.GetInt("CurrentMoney");
        } else
        {
            currentGold = 0;
            PlayerPrefs.SetInt("CurrentMoney", 0);
        }
        coinAmount.text = "x " + currentGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        currentGold += amount;
        PlayerPrefs.SetInt("CurrentMoney", currentGold);
        coinAmount.text = "x " + currentGold;
    }

    public void ResetMoney()
    {
        PlayerPrefs.SetInt("CurrentMoney", 0);
    }
}
