using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyChange : MonoBehaviour
{
    public static MoneyChange Instance { get; private set; }
    
    [HideInInspector] public int moneyInProcessGame;

    [SerializeField] private GlobalMoneyManager globalMoneyManager; 
    [SerializeField] private Text  changeMoneyText;
    

    void Awake()
    {
        Instance = this;
        moneyInProcessGame = globalMoneyManager.startMoney;
        changeMoneyText.text = globalMoneyManager.startMoney.ToString();
        StartCoroutine(routine: MoneyToSecond());
    }

    private IEnumerator MoneyToSecond()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            moneyInProcessGame += 1;
            changeMoneyText.text = moneyInProcessGame.ToString();
        }
    }

    public void GetMoney(int money)
    {
        moneyInProcessGame += money;
        changeMoneyText.text = moneyInProcessGame.ToString();
    }

    public void GiveMoney(int money)
    {
        moneyInProcessGame -= money;
        changeMoneyText.text = moneyInProcessGame.ToString();
    }
}
