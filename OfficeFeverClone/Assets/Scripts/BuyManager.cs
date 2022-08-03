using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyManager : MonoBehaviour
{
    public Text moneyText;

    public int moneyCount;
    private void OnEnable()
    {
        TriggerManager.OnMoneyCollected += IncreaseMoney;
    }
    private void OnDisable()
    {
        TriggerManager.OnMoneyCollected -= IncreaseMoney;

    }
    void IncreaseMoney()
    {
        moneyCount += 50; 
    }
    private void Update()
    {
        moneyText.text = moneyCount.ToString() + "$";
    }
}
