using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabGroup : MonoBehaviour
{
    public Text DetailText;


    private string[] VocabSet = { "language", "friendship", "nice", "culture", "environment" };
    private string[] MeanSet = { "language n ����", "friendship n ����ѹ����", "nice adj ��,����´�", "culture	n �Ѳ�����", "environment n ����Ǵ����" };
    private Dictionary<string, string> VocabDict = new Dictionary<string, string>();

    [SerializeField]
    public Text[] ButtonText = new Text[5]; 

     //Initail
    void Start()
    {
        for  (int i=0; i<5; i++)
        {
            // VocabSet[i] = "test";
            ButtonText[i].text = VocabSet[i];
            VocabDict.Add(VocabSet[i], MeanSet[i]);
        }
    }


   


    public void SetText(int x)
    {
        string key = ButtonText[x].text;
        
        DetailText.text =  VocabDict[key];
    }
}







//------------------------------------- Data Class



