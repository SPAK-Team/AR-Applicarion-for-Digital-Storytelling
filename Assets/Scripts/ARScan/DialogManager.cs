using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;



public class DialogManager : MonoBehaviour
{

	public GameObject dialogBox;
	public TextMeshProUGUI StoryText;
	public WordManager wordManager;
	public OptionManager optionManager;


	private int line = 0;
	private string[] TextSet = { };
	private string typePage;
	private string extraTypePage = "none";



	[SerializeField]
	private Player player;

	[SerializeField]
	private GameObject toMiniGame;

	[SerializeField]
	private GameObject toEnd;

	private string sumEndScene = "ARScan";

	private bool[] isPageRead = new bool[23];

	void Start()
    {
		player.LoadPlayer();
		isPageRead = player.getAllPageFlag();


	}

	public void SetDialogText(string[] storySet,string type,string etype)
    {
		TextSet = storySet;
		line = 0;
		StoryText.text = TextSet[0];
		typePage = type;
		extraTypePage = etype;


	}
	

	// Function Next Line  - When Click Button -> Change Text
	public void NextLine ()
    {
		if (line < TextSet.Length)
		{
			line = line + 1; // Next Line
			ChangeText(line);
		}
	}

	// Function Back Line  - When Click Button -> Change Text
	public void BackLine()
	{
        if (line > 0) { 
		line = line - 1; // Next Line
		ChangeText(line);
		}
        
	}

	// Function Change Text (Input => index of TextSet)
	void ChangeText(int indexLine)
	{
		if (line < TextSet.Length)
		{
			StoryText.text = TextSet[line];
		}
		else
		{
			line = line - 1;
            if (wordManager.FoundWordCount()==5)
            {

				dialogBox.SetActive(false);
				wordManager.SetButtonGroupActive(false);
				wordManager.SetBoxActive(false);

				line = 0;

				if (typePage == "choice" ) {
					optionManager.SetChoiceActive(true); 
				}
				else if (typePage == "main")
                {

                    if (isPageRead[3])
                    {
						optionManager.SetOneExtraChoiceActive("Option1", false);

					}
                    if (isPageRead[7])
                    {
						optionManager.SetOneExtraChoiceActive("Option2", false);

					}
					if (isPageRead[10])
                    {
						optionManager.SetOneExtraChoiceActive("Option3", false);

					}
					if (isPageRead[14])
                    {
						optionManager.SetOneExtraChoiceActive("Option4", false);

					}
					if (isPageRead[3] && isPageRead[7] && isPageRead[10] && isPageRead[14])
                    {
						optionManager.SetOneExtraChoiceActive("OptionExtra", true);

					}
					optionManager.SetChoiceActive(true);
				}
				else if(typePage == "minigame")

                {
					player.SetPoint(wordManager.getPlayerPoint());
					player.SavePlayer();
					toMiniGame.SetActive(true);

				}
				else if (typePage == "endding")
                {
					Image endTitleImg = toEnd.transform.Find("Title").GetComponent<Image>();
					var sprite = Resources.Load<Sprite>("Image/UI/EndBoxTitle/" + extraTypePage );
					endTitleImg.sprite = sprite;

					toEnd.SetActive(true);
					player.SetPoint(wordManager.getPlayerPoint());
					player.SavePlayer();


					


				}
				else
                {

                }

			}
			else
            {
				Debug.Log("Not Complete");
            }
			
			

		}
	}

	public void SetDialogVisible(bool visible)
    {
		dialogBox.SetActive(visible);
    }


	

	public void GoToBonusMinigameVocab()
    {
		
		SceneManager.LoadScene("BonusMinigame", LoadSceneMode.Single);

	}


}