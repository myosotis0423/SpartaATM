using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro; //다른 Input필드 타입이어서 수정

public class PopupLogin : MonoBehaviour
{
    public TMP_InputField idInput;
    public TMP_InputField pwInput;
    public Button loginButton;
    public Button signUpButton;

    public GameObject cashPanel;
    public GameObject userInfoPanel;
    public GameObject atmPanel;

    public GameObject popupBank; // 로그인 성공 시 팝업뱅크 오브젝트 

    private void Start()
    {
        loginButton.onClick.AddListener(OnClickLogin);

        cashPanel.SetActive(false);
        userInfoPanel.SetActive(false);
        atmPanel.SetActive(false); //로그인 전 내부 패널 비활성화

    }

    public void OnClickLogin()
    {
        string id = idInput.text;
        string pw = pwInput.text;

        if (id == "gnsgml711" && pw == "0000") //임시
        {
            Debug.Log("로그인 성공");
            gameObject.SetActive(false);

            cashPanel.SetActive(true);
            userInfoPanel.SetActive(true);
            atmPanel.SetActive(true); //로그인 성공 시 내부 패널 활성화

        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }
}
