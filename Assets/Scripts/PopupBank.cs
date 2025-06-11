using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public TextMeshProUGUI cashText; // 현금 
    public TextMeshProUGUI balanceText; // 잔액
    public TMP_InputField inputField; //직접입력
    public GameObject errorPanel; // 잔액부족 팝업
    public TextMeshProUGUI errorText; // 에러 메시지

    private UserData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameManager.Instance.userData;
        RefreshUI();
    }

    public void Deposit(int amount) // 금액 버튼으로 입금
    {
        if (data.cash >= (ulong)amount)
        {
            data.cash -= (ulong)amount;
            data.balance += (ulong)amount;
            RefreshUI();
        }
        else
        {
            ShowError("현금이 부족합니다.");
        }
    }
    public void DepositInputField() // 직접 입력창으로 입금
    {
        if (ulong.TryParse(inputField.text, out ulong amount) && amount > 0) 
        {
            if (data.cash >= amount)
            {
                data.cash -= amount;
                data.balance += amount;
                RefreshUI();
            }
            else
            {
                ShowError("잔액이 부족합니다.");
            }
        }
        else
        {
            ShowError("올바른 숫자를 입력하세요.");
        }
    }
    public void Withdraw(int amount) // 금액 버튼으로 출금
    {
        if (data.balance >= (ulong)amount)
        {
            data.balance -= (ulong)amount;
            data.cash += (ulong)amount;
            RefreshUI();
        }
        else
        {
            ShowError("잔액이 부족합니다.");
        }
    }
    public void WithdrawInputField() // 직접 입력창으로 출금
    { 
        if (ulong.TryParse(inputField.text, out ulong amount) && amount > 0)
        {
            if (data.balance >= amount)
            {
                data.balance -= amount;
                data.cash += amount;
                RefreshUI();
            }
            else
            {
                ShowError("잔액이 부족합니다.");
            }
        }
        else
        {
            ShowError("올바른 숫자를 입력하세요.");
        }
    }

    private void ShowError(string message)
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(true);
            errorText.text = message;

            //Debug.Log(message);
        }
    }

    public void CloseErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(false);
        }
    }

    private void RefreshUI()
    {
        cashText.text = data.cash.ToString("N0");
        balanceText.text = data.balance.ToString("N0");
        GameManager.Instance.SaveUserData(); // 자동 저장
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
