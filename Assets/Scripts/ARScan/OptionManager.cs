using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using DataClass;
using System.Linq;


public class OptionManager : MonoBehaviour
{
	public GameObject optionBox;
	//Edit -> 5 optopns
	public GameObject oneOptionSet;
	public GameObject twoOptionSet;
	public GameObject extraOptionSet;

	public GameObject resultBox;


	public Text NextPage;
	public Text ResultTitle;




	private Dictionary<string, Choice> optionSet = new Dictionary<string, Choice> { };


	



	public void SetOptionChoice(Dictionary<string, Choice> choiceSet)
	{
		// Load Story Data to DataSet

			optionSet.Clear();
			optionSet = choiceSet;

		//Debug.Log("Choice Size: " + optionSet.Count);

		if (optionSet.Count == 1) {
			oneOptionSet.transform.Find("Option1").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(0).Key;
			oneOptionSet.SetActive(true);
		}

		else if(optionSet.Count == 2)
        {
			twoOptionSet.transform.Find("Option1").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(0).Key;
			twoOptionSet.transform.Find("Option2").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(1).Key;
			twoOptionSet.SetActive(true);


		}
		else
        {
			extraOptionSet.transform.Find("Option1").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(0).Key;
			extraOptionSet.transform.Find("Option2").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(1).Key;
			extraOptionSet.transform.Find("Option3").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(2).Key;
			extraOptionSet.transform.Find("Option4").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(3).Key;
			extraOptionSet.transform.Find("OptionExtra").gameObject.GetComponentInChildren<Text>().text = optionSet.ElementAt(4).Key;


			extraOptionSet.SetActive(true);

		}

	



	}

	public void SetChoiceActive(bool x)
    {
		optionBox.SetActive(x);

	}


	public void SetOneExtraChoiceActive(string name,bool x)
	{
		extraOptionSet.transform.Find(name).gameObject.SetActive(x);
	}

	public void GoToNextPage(Text ButtonText)
    {

		
		string key = ButtonText.text;
		//Debug.Log(key);
		string nextPage =optionSet[key].getNextPage();
		optionBox.SetActive(false);
		oneOptionSet.SetActive(false);
		twoOptionSet.SetActive(false);
		extraOptionSet.SetActive(false);


		ResultTitle.text = key;
		NextPage.text = nextPage;

		resultBox.SetActive(true);



	}

	public void SetResultActive(bool x)
    {
		resultBox.SetActive(x);
    }





	public bool GetOptionActive()
	{
		return optionBox.activeSelf;
	}

	public bool GetResultActive()
	{
		return resultBox.activeSelf;
	}

	




}
