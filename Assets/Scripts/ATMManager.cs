using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class ATMManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI balanceText;

    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject depositButton;
    public GameObject withdrawButton;

    // Start is called before the first frame update
    void Start()
    {
        UserData data = GameManager.Instance.userData;
        nameText.text = data.userName;
        cashText.text = data.cash.ToString("N0");
        balanceText.text = $"잔액 {data.balance.ToString("N0")}";

        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);

    }
    public void OpenDepositPanel()
    {
        depositPanel.SetActive(true);
        withdrawPanel.SetActive(false);
        depositButton.SetActive(false);
        withdrawButton.SetActive(false);
    }
    public void OpenWithdrawPanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(true);
        depositButton.SetActive(false);
        withdrawButton.SetActive(false);
    }
    public void BackButtons()
    {
        // 디포짓 / 위드드로우 패널 비활성화
        if (depositPanel != null) depositPanel.SetActive(false);
        if (withdrawPanel != null) withdrawPanel.SetActive(false);

        // ATM 버튼들 다시 활성화
        if (depositButton != null) depositButton.SetActive(true);
        if (withdrawButton != null) withdrawButton.SetActive(true);
    }

    //void Update()
    //{
    //    UserData data = GameManager.Instance.userData;
    //    cashText.text = data.cash.ToString("N0");
    //    balanceText.text = data.balance.ToString("N0");
    //}
}
