using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TestClass;

public class TestPlayerSetting : MonoBehaviour
{
    private List<MyPlayer> playerList= new List<MyPlayer>();
    private string thisname;
    private int playerPoint = 0;

    void Start()
    {
        TextAsset playerFile = (TextAsset)Resources.Load("CoinHistory/coin", typeof(TextAsset));
        var allLine = playerFile.text;
        var oneLine = allLine.Split(' ');
        var nameSet = oneLine[0];
        var pointSet = Int32.Parse(oneLine[1]);


        MyPlayer player = new MyPlayer(nameSet, pointSet);
        playerList.Add(player);

        thisname = player.getName();
        playerPoint = player.getPoint();


        string tempName = thisname + playerPoint.ToString();
        Debug.Log(tempName);
    }
}
