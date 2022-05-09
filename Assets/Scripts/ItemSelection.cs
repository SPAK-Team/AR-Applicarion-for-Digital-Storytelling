using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;
using TestClass;

public class ItemSelection : MonoBehaviour
{

    [SerializeField]
    public Button itemButton;
    public Sprite newItem1Image;
    public Sprite newItem2Image;
    public Sprite newItem3Image;
    public Sprite newItem4Image;
    public Sprite newItem5Image;
    public Sprite newItem6Image;

    [SerializeField]
    private Text panelText;

    [SerializeField]
    private Button collectButton;

    [SerializeField]
    public GameObject itemPanel;

    [SerializeField]
    private Text messageText;

    [SerializeField]
    private Text balanceText;
    [SerializeField]
    private Text reduceText;
    [SerializeField]
    private Text itemName;

    [SerializeField]
    public Button purchaseButton;
    [SerializeField]
    public Button fasionButton;

    [SerializeField]
    public Button collectionButton1;
    [SerializeField]
    public Button collectionButton2;
    [SerializeField]
    public Button collectionButton3;
    [SerializeField]
    public Button collectionButton4;
    [SerializeField]
    public Button collectionButton5;
    [SerializeField]
    public Button collectionButton6;
    public Sprite noneItemImage;

    [SerializeField]
    private Player player;


    [SerializeField]
    private Image warnBox;
    [SerializeField]
    private Text warnText;

    private int playerPoint = 0;
    private int Price = 0;

    private bool[] allHavingItem = new bool[6];

    private int IsButton1, IsButton2, IsButton3, IsButton4, IsButton5, IsButton6 = 0;

    void Start()
    {
        itemButton.gameObject.SetActive(false);
        balanceText.gameObject.SetActive(false);
        reduceText.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);

        // ---- Real ----
        
         player.LoadPlayer();
         allHavingItem = player.getAllItemFlag();
        // ---- End Real ----

        //---- Test ----
        // playerPoint = 10;
        // ---- End Test ----

    }
    void Update()
    {
        /* //TextAsset playerFile = (TextAsset)Resources.Load("CoinHistory/coin_not_enough", typeof(TextAsset));
         TextAsset playerFile = (TextAsset)Resources.Load("CoinHistory/coin", typeof(TextAsset));
         var allLine = playerFile.text;
         var oneLine = allLine.Split('\n');
         var pointSet = Int32.Parse(oneLine[0]);

         MyPlayer player = new MyPlayer(pointSet);
         playerPoint = player.getPoint();*/

        /*  var tempString = IsButton1.ToString() + IsButton2.ToString() + IsButton2.ToString()+ IsButton4.ToString() + IsButton5.ToString() + IsButton6.ToString();
          Debug.Log(tempString);*/
       

        // ---- Real  -------
            player.LoadPlayer();
           playerPoint = player.getPoint();
        // ---- End Real  -------



        if (IsButton1 == 1 || allHavingItem[0]) { collectionButton1.image.sprite = newItem1Image; }
        if(IsButton2 == 1 || allHavingItem[1]) { collectionButton2.image.sprite = newItem2Image; }
        if(IsButton3 == 1 || allHavingItem[2]) { collectionButton3.image.sprite = newItem3Image; }
        if(IsButton4 == 1 || allHavingItem[3]) { collectionButton4.image.sprite = newItem4Image; }
        if(IsButton5 == 1 || allHavingItem[4]) { collectionButton5.image.sprite = newItem5Image; }
        if(IsButton6 == 1 || allHavingItem[5]) { collectionButton6.image.sprite = newItem6Image; }
    }




        public void showItem()
        {
        

            balanceText.gameObject.SetActive(true);
            reduceText.gameObject.SetActive(true);
          //  messageText.text = "รับรางวัล!";

            var buttonName = EventSystem.current.currentSelectedGameObject.name;

            if (buttonName == "B1_Button")
            {
                Price = 1;
                if (playerPoint >= Price)
                {
                    warnText.text = "มาแลก\nของรางวัลกันเถอะ!";

                    IsButton1 = 1;
                    itemPanel.SetActive(false);
                    panelText.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(false);
                    purchaseButton.gameObject.SetActive(false);
                    fasionButton.gameObject.SetActive(false);
                    itemName.gameObject.SetActive(true);
                    itemButton.gameObject.SetActive(true);

                    playerPoint = playerPoint - Price;
                    
                    reduceText.text = "แต้มที่ใช้ไป = " + Price.ToString() + "แต้ม";
                    itemButton.image.sprite = newItem1Image;
                    itemName.text = "คลิกเพื่อรับ" + "มงกุฎทอง" + "เป็นของรางวัล";
                allHavingItem[0] = true;
                

                }
                else
                {
                    itemPanel.SetActive(true);
                    panelText.gameObject.SetActive(true);
                   // collectButton.gameObject.SetActive(true);
                    purchaseButton.gameObject.SetActive(true);
                    fasionButton.gameObject.SetActive(true);
                // New Version 
                itemName.gameObject.SetActive(false);
                reduceText.gameObject.SetActive(false);
                balanceText.gameObject.SetActive(false);
                //  itemName.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                itemButton.gameObject.SetActive(false);
                reduceText.text = "แต้มที่ใช้ไป = 0 แต้ม";

                warnText.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                //End New Version
            }
        }
            if (buttonName == "B2_Button")
            {
                Price = 2;
                if (playerPoint >= Price)
                {
                warnText.text = "มาแลก\nของรางวัลกันเถอะ!";
                IsButton2 = 1;
                    itemPanel.SetActive(false);
                    panelText.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(false);
                    purchaseButton.gameObject.SetActive(false);
                    fasionButton.gameObject.SetActive(false);
                    itemName.gameObject.SetActive(true);
                    itemButton.gameObject.SetActive(true);

                    playerPoint = playerPoint - Price;
                    reduceText.text = "แต้มที่ใช้ไป = " + Price.ToString() + "แต้ม";
                    itemButton.image.sprite = newItem2Image;
                    itemName.text = "คลิกเพื่อรับ" + "มงกุฎเงิน" + "เป็นของรางวัล";
                allHavingItem[1] = true;
                }
                else
                {
                    itemPanel.SetActive(true);
                    panelText.gameObject.SetActive(true);
                 //   collectButton.gameObject.SetActive(true);
                    purchaseButton.gameObject.SetActive(true);
                    fasionButton.gameObject.SetActive(true);
                // New Version 
                itemName.gameObject.SetActive(false);
                reduceText.gameObject.SetActive(false);
                balanceText.gameObject.SetActive(false);
                //  itemName.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                itemButton.gameObject.SetActive(false);
                reduceText.text = "แต้มที่ใช้ไป = 0 แต้ม";

                warnText.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                //End New Version
            }
        }
            if (buttonName == "B3_Button")
            { 
                Price = 3;
                if (playerPoint >= Price)
                {
                warnText.text = "มาแลก\nของรางวัลกันเถอะ!";
                IsButton3 = 1;
                    itemPanel.SetActive(false);
                    panelText.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(false);
                    purchaseButton.gameObject.SetActive(false);
                    fasionButton.gameObject.SetActive(false);
                    itemName.gameObject.SetActive(true);

                    itemButton.gameObject.SetActive(true);
                    playerPoint = playerPoint - Price;
                    reduceText.text = "แต้มที่ใช้ไป = " + Price.ToString() + "แต้ม";
                    itemButton.image.sprite = newItem3Image;
                    itemName.text = "คลิกเพื่อรับ" + "หมวกผู้ชาย" + "เป็นของรางวัล";
                allHavingItem[2] = true;
                }
                else
                {
                    itemPanel.SetActive(true);
                    panelText.gameObject.SetActive(true);
                   // collectButton.gameObject.SetActive(true);
                    purchaseButton.gameObject.SetActive(true);
                    fasionButton.gameObject.SetActive(true);
                // New Version 
                itemName.gameObject.SetActive(false);
                reduceText.gameObject.SetActive(false);
                balanceText.gameObject.SetActive(false);
                //  itemName.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                itemButton.gameObject.SetActive(false);
                reduceText.text = "แต้มที่ใช้ไป = 0 แต้ม";

                warnText.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                //End New Version
            }
        }
            if (buttonName == "B4_Button")
            {    
                Price = 4;
                if (playerPoint >= Price)
                {
                warnText.text = "มาแลก\nของรางวัลกันเถอะ!";
                IsButton4 = 1;
                    itemPanel.SetActive(false);
                    panelText.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(false);
                    purchaseButton.gameObject.SetActive(false);
                    fasionButton.gameObject.SetActive(false);
                    itemName.gameObject.SetActive(true);
                    itemButton.gameObject.SetActive(true);

                    playerPoint = playerPoint - Price;
                    reduceText.text = "แต้มที่ใช้ไป = " + Price.ToString() + "แต้ม";
                    itemButton.image.sprite = newItem4Image;
                    itemName.text = "คลิกเพื่อรับ" + "หมวกผู้หญิง" + "เป็นของรางวัล";
                allHavingItem[3] = true;
                }
                else
                {
                    itemPanel.SetActive(true);
                    panelText.gameObject.SetActive(true);
                 //   collectButton.gameObject.SetActive(true);
                    purchaseButton.gameObject.SetActive(true);
                    fasionButton.gameObject.SetActive(true);
                // New Version 
                itemName.gameObject.SetActive(false);
                reduceText.gameObject.SetActive(false);
                balanceText.gameObject.SetActive(false);
                //  itemName.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                itemButton.gameObject.SetActive(false);
                reduceText.text = "แต้มที่ใช้ไป = 0 แต้ม";

                warnText.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                //End New Version
            }
        }
            if (buttonName == "B5_Button")
            {
                Price = 5;
                if (playerPoint >= Price)
                {
                warnText.text = "มาแลก\nของรางวัลกันเถอะ!";
                IsButton5 = 1;
                    itemPanel.SetActive(false);
                    panelText.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(false);
                    purchaseButton.gameObject.SetActive(false);
                    fasionButton.gameObject.SetActive(false);
                    itemName.gameObject.SetActive(true);
                    itemButton.gameObject.SetActive(true);

                    playerPoint = playerPoint - Price;
                    reduceText.text = "แต้มที่ใช้ไป = " + Price.ToString() + "แต้ม";
                    itemButton.image.sprite = newItem5Image;
                    itemName.text = "คลิกเพื่อรับ" + "รองเท้าฟ้า" + "เป็นของรางวัล";
                allHavingItem[4] = true;
                }
                else
                {
                    itemPanel.SetActive(true);
                    panelText.gameObject.SetActive(true);
                   // collectButton.gameObject.SetActive(true);
                    purchaseButton.gameObject.SetActive(true);
                    fasionButton.gameObject.SetActive(true);
                // New Version 
                itemName.gameObject.SetActive(false);
                reduceText.gameObject.SetActive(false);
                balanceText.gameObject.SetActive(false);
                //  itemName.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                itemButton.gameObject.SetActive(false);
                reduceText.text = "แต้มที่ใช้ไป = 0 แต้ม";

                warnText.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                //End New Version
            }
        }
            if (buttonName == "B6_Button")
            {
                Price = 6;
                if (playerPoint >= Price)
                {
                warnText.text = "มาแลก\nของรางวัลกันเถอะ!";
                IsButton6 = 1;
                    itemPanel.SetActive(false);
                    panelText.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(false);
                    purchaseButton.gameObject.SetActive(false);
                    fasionButton.gameObject.SetActive(false);
                    itemName.gameObject.SetActive(true);
                    itemButton.gameObject.SetActive(true);

                    playerPoint = playerPoint - Price;
                    reduceText.text = "แต้มที่ใช้ไป = " + Price.ToString() + "แต้ม";
                    itemButton.image.sprite = newItem6Image;
                    itemName.text = "คลิกเพื่อรับ" + "รองเท้าชมพู" + "เป็นของรางวัล";
                allHavingItem[5] = true;
                }
                else
                {
                    itemPanel.SetActive(true);
                    panelText.gameObject.SetActive(true);
                   // collectButton.gameObject.SetActive(true);
                    purchaseButton.gameObject.SetActive(true);
                    fasionButton.gameObject.SetActive(true);


                // New Version 
                    itemName.gameObject.SetActive(false);
                    reduceText.gameObject.SetActive(false);
                    balanceText.gameObject.SetActive(false);
                    //  itemName.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                    itemButton.gameObject.SetActive(false);
                    reduceText.text = "แต้มที่ใช้ไป = 0 แต้ม";

                warnText.text = "คุณมีแต้มไม่เพียงพอ ไม่สามารถแลกของรางวัลได้";
                //End New Version

                }
            }

            //Real
       player.SetPoint(playerPoint);
        player.SetAllItemFlag(allHavingItem);
        player.SavePlayer();
        // ---- End Real ----

        panelText.text = "แต้มสะสมของคุณ = " + playerPoint.ToString() + "แต้ม";
        balanceText.text = "แต้มสะสมคงเหลือ = " + playerPoint.ToString() + "แต้ม";
        }

}

