using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TestClass;

public class VocabularyScore : MonoBehaviour
{
    [SerializeField]
    private Text pointText;

    [SerializeField]
    private Text GreetingText;
    
    [SerializeField]
    private Button coinbutton;

    [SerializeField]
    private Player player;

    private int IsPressed = 0;
    private int playerPoint = 0;

    void Awake()
    {
        //----------Test----------------------------
        /*
        player = new Player("Test", 23);
        player.SetPoint(10);
        playerPoint = player.getPoint();
        */
        //----------End Test----------------------------

        player.LoadPlayer();
        playerPoint = player.getPoint();


        coinbutton.gameObject.SetActive(false);
        GreetingText.gameObject.SetActive(false);
    }
    public void upScore()
    {

        if ( IsPressed == 0 )
        {
            playerPoint = playerPoint+ 1;
            IsPressed = 1;
            coinbutton.gameObject.SetActive(true);
            GreetingText.gameObject.SetActive(true);
            GreetingText.text = "คุณได้รับแต้ม 1 แต้ม";
        }
        else if (IsPressed == 1)
        {
            coinbutton.gameObject.SetActive(false);
            GreetingText.gameObject.SetActive(true);
            GreetingText.text = "คุณได้รับแต้ม 1 แต้มแล้ว";
        }

        Debug.Log("Point : "+playerPoint );


        player.SetPoint(playerPoint);
        player.SavePlayer();

    }
    public void disShow()
    {
        coinbutton.gameObject.SetActive(false);
        GreetingText.gameObject.SetActive(false);
    }


    void Update()
    {

        pointText.text = "x " + playerPoint;

    }
}
