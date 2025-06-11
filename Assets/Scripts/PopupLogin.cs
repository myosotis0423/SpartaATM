using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; //�ٸ� Input�ʵ� Ÿ���̾ ����

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField idInput;
    public TMP_InputField pwInput;
    public Button loginButton;
    public Button signUpButton;

    public GameObject cashPanel;
    public GameObject userInfoPanel;
    public GameObject atmPanel;

    public GameObject popupBank; // �α��� ���� �� �˾���ũ ������Ʈ 

    private void Start()
    {
        loginButton.onClick.AddListener(OnClickLogin);

        cashPanel.SetActive(false);
        userInfoPanel.SetActive(false);
        atmPanel.SetActive(false); //�α��� �� ���� �г� ��Ȱ��ȭ

    }

    public void OnClickLogin()
    {
        string id = idInput.text;
        string pw = pwInput.text;

        if (id == "gnsgml711" && pw == "0000") //�ӽ�
        {
            Debug.Log("�α��� ����");
            gameObject.SetActive(false);

            cashPanel.SetActive(true);
            userInfoPanel.SetActive(true);
            atmPanel.SetActive(true); //�α��� ���� �� ���� �г� Ȱ��ȭ

        }
        else
        {
            Debug.Log("�α��� ����");
        }
    }
}
