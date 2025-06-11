using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject popupLogin;
    public GameObject popupBank;

    public static GameManager Instance; //�̱���

    public UserData userData;  // �ν����� â���� �Ҵ簡��

    private string savePath;

    private void Start()
    {
        popupLogin.SetActive(true);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("Save Path: " + Application.persistentDataPath);

        savePath = Path.Combine(Application.persistentDataPath, "userdata.json");

        if (!LoadUserData())
        {
            Debug.Log("Save file not found, creating new.");
            userData = new UserData("������", 100000, 50000);
            SaveUserData();  //  �⺻�� ���� �� ����
        }
        else
        {
            Debug.Log("UserData loaded: " + userData.userName + ", " + userData.cash + ", " + userData.balance);
        }
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);

        //    savePath = Path.Combine(Application.persistentDataPath, "userdata.json");


        //    LoadUserData(); // ���� ���� �� �ҷ�����

        //    if (userData == null) // ������ �ʱⰪ ����
        //        userData = new UserData("������", 100000, 50000);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
    }
    public bool LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            return true;
        }
        return false;
    }
    public void ChangeCash(ulong amount)
    {
        userData.cash += amount;
        SaveUserData();
    }

    public void ChangeBalance(ulong amount)
    {
        userData.balance += amount;
        SaveUserData();
    }

}