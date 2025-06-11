using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//인스펙터에서 보기 위해서 필요
public class UserData
{
    public string userName;
    public ulong cash;
    public ulong balance;

    public UserData() { }

    public UserData(string name, ulong cashAmount, ulong balanceAmount)
    {
        userName = name;
        cash = cashAmount;
        balance = balanceAmount;
    }
}

//public class userData;
//{
//public string userName;
//public int cash;
//public int balance;

//public UserData()
//{

//}

//public UserData(string name, int cashAmount, int balanceAmount)
//{
//    userName = name;
//    cash = cashAmount;
//    balance = balanceAmount;
//}
//}

