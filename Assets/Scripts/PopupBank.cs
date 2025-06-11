using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    public TextMeshProUGUI cashText; // ���� 
    public TextMeshProUGUI balanceText; // �ܾ�
    public TMP_InputField inputField; //�����Է�
    public GameObject errorPanel; // �ܾ׺��� �˾�
    public TextMeshProUGUI errorText; // ���� �޽���

    private UserData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameManager.Instance.userData;
        RefreshUI();
    }

    public void Deposit(int amount) // �ݾ� ��ư���� �Ա�
    {
        if (data.cash >= (ulong)amount)
        {
            data.cash -= (ulong)amount;
            data.balance += (ulong)amount;
            RefreshUI();
        }
        else
        {
            ShowError("������ �����մϴ�.");
        }
    }
    public void DepositInputField() // ���� �Է�â���� �Ա�
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
                ShowError("�ܾ��� �����մϴ�.");
            }
        }
        else
        {
            ShowError("�ùٸ� ���ڸ� �Է��ϼ���.");
        }
    }
    public void Withdraw(int amount) // �ݾ� ��ư���� ���
    {
        if (data.balance >= (ulong)amount)
        {
            data.balance -= (ulong)amount;
            data.cash += (ulong)amount;
            RefreshUI();
        }
        else
        {
            ShowError("�ܾ��� �����մϴ�.");
        }
    }
    public void WithdrawInputField() // ���� �Է�â���� ���
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
                ShowError("�ܾ��� �����մϴ�.");
            }
        }
        else
        {
            ShowError("�ùٸ� ���ڸ� �Է��ϼ���.");
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
        GameManager.Instance.SaveUserData(); // �ڵ� ����
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
