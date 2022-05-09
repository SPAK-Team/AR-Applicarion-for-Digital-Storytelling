using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSetting : MonoBehaviour
{
    [SerializeField]
    public Button itemButton;

    [SerializeField]
    private Text balanceText;

    [SerializeField]
    private Text reduceText;

    [SerializeField]
    private Text itemName;

    [SerializeField]
    public GameObject dialogPanel;

    [SerializeField]
    public Image poImage;
    public Sprite newPoImage;
    public Sprite originalPoImage;

    [SerializeField]
    public Image MboxImage;
    public Sprite newBoxImage;
    public Sprite originalMboxImage;

    [SerializeField]
    public Text boxGreetingText;

    [SerializeField]
    public GameObject privilegePanel;

    [SerializeField]
    private Text panelText;

    [SerializeField]
    private Button collectButton;

    [SerializeField]
    public GameObject itemPanel;

    [SerializeField]
    public Button purchaseButton;

    [SerializeField]
    public Button fasionButton;

    [SerializeField]
    public GameObject fasionPanel;

    public void closeItem()
    {
        itemButton.gameObject.SetActive(false);
        balanceText.gameObject.SetActive(false);
        reduceText.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);
        dialogPanel.SetActive(true);

      /*  poImage.sprite = newPoImage;
        poImage.rectTransform.anchoredPosition = new Vector2(410, -150);
        poImage.rectTransform.sizeDelta = new Vector2(360,450);*/

       /* MboxImage.sprite = newBoxImage;
        MboxImage.rectTransform.anchoredPosition = new Vector2(450, 120);
        MboxImage.rectTransform.sizeDelta = new Vector2(280, 260);*/

      /*  boxGreetingText.text = "อ่านเนื้อเรื่องนิทานต่อแล้วเอาเหรียญมาเเลกของรางวัลได้นะ";
        boxGreetingText.rectTransform.anchoredPosition = new Vector2(0,20);*/
    }
    public void closeDialog()
    {
        dialogPanel.SetActive(false);
        privilegePanel.SetActive(true);
        itemPanel.SetActive(true);
        fasionPanel.SetActive(false);
        panelText.gameObject.SetActive(true);
      //  collectButton.gameObject.SetActive(true);

       /* poImage.sprite = originalPoImage;
        poImage.gameObject.SetActive(true);
        poImage.rectTransform.anchoredPosition = new Vector2(-801,-231);
        poImage.rectTransform.sizeDelta = new Vector2(250,330);*/


       /* MboxImage.sprite = originalMboxImage;
        MboxImage.gameObject.SetActive(true);
        MboxImage.rectTransform.anchoredPosition = new Vector2(-629,-39);
        MboxImage.rectTransform.sizeDelta = new Vector2(259,222);*/

     /*   boxGreetingText.gameObject.SetActive(true);
        boxGreetingText.text = "มาเเลกของรางวัลกันนะ";
        boxGreetingText.rectTransform.anchoredPosition = new Vector2(20, 0);*/

        purchaseButton.gameObject.SetActive(true);
        fasionButton.gameObject.SetActive(true);

    }
}
