using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ClickableWord : MonoBehaviour 
{
    public TextMeshProUGUI text;
    public WordManager wordManager;

    public string IndexString;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // -1 or 0 -> found =0 notfound=-1
            var wordIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
           

            if (wordIndex != -1)
            {
                IndexString = text.textInfo.linkInfo[wordIndex].GetLinkID();

                  //Debug.Log("Clicked on " + IndexString);

                 wordManager.FoundWord(int.Parse(IndexString));


            }
        }
    }
}