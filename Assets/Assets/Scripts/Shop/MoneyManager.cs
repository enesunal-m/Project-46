using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{

    [HideInInspector] public static int totalMoney = 0;
    [SerializeField]TMP_Text myMoney;
    public static MoneyManager Instance;
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        
        myMoney.text = totalMoney.ToString();
    }

    public void getMoney(int amount)
    {
        totalMoney += amount;
    }
    public void loseMoney(int amount)
    {
        totalMoney -= amount;
    }



}
