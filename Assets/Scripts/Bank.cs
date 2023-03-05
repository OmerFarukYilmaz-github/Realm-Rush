using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance ;
    [SerializeField] TextMeshProUGUI balanceText;
    public int CurrentBalance { get { return currentBalance; } }

    public void Awake()
    {
        UpdateDisplayBalance();
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        UpdateDisplayBalance();
        currentBalance += Mathf.Abs(amount);
    }
    public void Withdraw(int amount)
    {
        UpdateDisplayBalance();
        currentBalance -= Mathf.Abs(amount);

        if(currentBalance<0)
        {
            // LOSE THE GAME
            ReloadScene();
        }
    }

    void UpdateDisplayBalance()
    {
        balanceText.text = "GOLD = " + currentBalance;
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
