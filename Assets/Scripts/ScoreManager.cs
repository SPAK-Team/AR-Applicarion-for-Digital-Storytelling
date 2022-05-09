using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TestClass;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private Text pointText;

    [SerializeField]
    private Text GreetingText;

    [SerializeField]
    public Button thisbutton;

    private int playerPoint = 0;

    void Start()
    {
        TextAsset playerFile = (TextAsset)Resources.Load("CoinHistory/coin", typeof(TextAsset));
        var allLine = playerFile.text;
        var oneLine = allLine.Split('\n');
        var pointSet = Int32.Parse(oneLine[0]);

        MyPlayer player = new MyPlayer(pointSet);
        playerPoint = player.getPoint();
        pointText.text = "x " + playerPoint.ToString();

        var tempString = "Read: " + playerPoint.ToString();
        Debug.Log(tempString);

        GreetingText.gameObject.SetActive(true);
        thisbutton.gameObject.SetActive(true);
        GreetingText.text = "คุณได้รับ 2 เหรียญ";
    }
    void Update() 
    {
        TextAsset playerFile = (TextAsset)Resources.Load("CoinHistory/coin", typeof(TextAsset));
        var allLine = playerFile.text;
        var oneLine = allLine.Split('\n');
        var pointSet = Int32.Parse(oneLine[0]);

        MyPlayer player = new MyPlayer(pointSet);
        playerPoint = player.getPoint();
        pointText.text = "x " + playerPoint.ToString();
    }
    public void upScore()
    {
        playerPoint += 2;
        GreetingText.gameObject.SetActive(false);
        thisbutton.gameObject.SetActive(false);

        string pathFile = "Assets/Resources/CoinHistory/coin.txt";
        StreamWriter writer = new StreamWriter(pathFile, false);
        writer.WriteLine(playerPoint);
        writer.Close();
        pointText.text = "x " + playerPoint.ToString();

        var tempString = "Write: " + playerPoint.ToString();
        Debug.Log(tempString);
    }
}