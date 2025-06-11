using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject popupLogin;
    public GameObject popupBank;

    public static GameManager Instance; //싱글톤

    public UserData userData;  // 인스펙터 창에서 할당가능

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
            userData = new UserData("조훈희", 100000, 50000);
            SaveUserData();  //  기본값 생성 후 저장
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


        //    LoadUserData(); // 게임 시작 시 불러오기

        //    if (userData == null) // 없으면 초기값 생성
        //        userData = new UserData("조훈희", 100000, 50000);
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