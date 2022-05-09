using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataClass;

public class VocabularySetting4 : MonoBehaviour
{
    [SerializeField]
    private Text vocabText;

    private Word goalWord;
    private List<Word> allWord = new List<Word>();
    protected int[] allRouteWord = { 1, 2, 3, 15, 16, 17, 18, 22 };
    private string allVocab;

    void Start()
    {

        foreach (int num in allRouteWord)
        {
            //Debug.Log("in");
            TextAsset WordFile = (TextAsset)Resources.Load("WordText/S" + num.ToString(), typeof(TextAsset));
            var wordString = WordFile.text;
            var wordFileSet = wordString.Split('\n');
            var engWordSet = wordFileSet[0].Split('/');
            var posWordSet = wordFileSet[1].Split('/');
            var thWordSet = wordFileSet[2].Split('/');

            for (int i = 0; i < engWordSet.Length; i++)
            {
                Word tempWord = new Word(engWordSet[i], posWordSet[i], thWordSet[i]);
                allWord.Add(tempWord);
            }
        }
        Debug.Log(allWord.Count);
        foreach (Word tempWord in allWord)
        {
            string tempstring = tempWord.getVocab() + "\n";
            allVocab = allVocab + tempstring;
            //Debug.Log(tempstring);
        }

        vocabText.text = allVocab;
    }


}