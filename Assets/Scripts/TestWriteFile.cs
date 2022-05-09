using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TestClass;


public class TestWriteFile : MonoBehaviour
{
    public int pointSet = 0;
    private int pointPlayer = 0;
    void Start()
    {
        //Read
        try
        {
            TextAsset playerFile = (TextAsset)Resources.Load("CoinHistory/testWrite", typeof(TextAsset));
            var allLine = playerFile.text;
            var oneLine = allLine.Split('\n');
            pointSet = Int32.Parse(oneLine[0]);
        }
        catch (Exception e) { Debug.LogError(e);}

        
        MyPlayer player = new MyPlayer(pointSet);
        pointPlayer = player.getPoint();

        /*
        //Write
        try
        {
            string pathFile = "Assets/Resources/CoinHistory/testWrite.txt";
            StreamWriter writer = new StreamWriter(pathFile, false);
            writer.WriteLine(pointPlayer);
            writer.Close();
        }
        catch (Exception e) { Debug.LogError(e); }

        Debug.Log(pointPlayer);
        */
       
    }
}
