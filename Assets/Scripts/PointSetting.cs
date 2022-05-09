using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TestClass;

public class PointSetting : MonoBehaviour
{
    [SerializeField]
    private Text panelText;

    [SerializeField]
    private Text pointText;

    private int playerPoint = 0;


    [SerializeField]
    private Player player;


    void Awake()
    {
        // Real Program
          player.LoadPlayer();

        // Test Only
         /* player = new Player("pri", 23);
         player.SetPoint(10);
         playerPoint = player.getPoint();*/

        playerPoint = 10;
        //End test


    }

    void Update()
    {
        playerPoint = player.getPoint();

        panelText.text = "แต้มสะสมของคุณ =  " + playerPoint.ToString() + " แต้ม";
        pointText.text = "x " + playerPoint.ToString();
    }
}

