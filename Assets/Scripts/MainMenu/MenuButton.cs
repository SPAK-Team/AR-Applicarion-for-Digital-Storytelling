using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using System.Linq;


public class MenuButton : MonoBehaviour
{
    private bool isHaveSave = false;
    private string[] allSaveFiles;

    void Awake()
    {
        string filePath = Application.persistentDataPath + "/SavePlayer";
          Debug.Log(filePath);


        if (Directory.Exists(filePath))
        {
            string[] files = System.IO.Directory.GetFiles(filePath);
            allSaveFiles = files;
            //Debug.Log(files.Length);
            if (allSaveFiles.Length > 0)
            {
                // Have Save
                isHaveSave = true;

                

            }
            else
            {
                // Not Have Save
                isHaveSave = false;
            }



        }

        else
        {
            // Create Directory if folder does not exist.
            DirectoryInfo di = Directory.CreateDirectory(filePath);
            string[] files = System.IO.Directory.GetFiles(filePath);
            allSaveFiles = files;
            isHaveSave = false;


        }
        SetMenuBunttonActive();







    }


    public void SetMenuBunttonActive()
    {
        if (isHaveSave)
        {
            transform.Find("SavedSetButton").gameObject.SetActive(true);
            transform.Find("NewOnlyButton").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("SavedSetButton").gameObject.SetActive(false);
            transform.Find("NewOnlyButton").gameObject.SetActive(true);
        }
    }




    public void NewAction()
    {
        transform.Find("SavedSetButton").gameObject.SetActive(false);
        transform.Find("NewOnlyButton").gameObject.SetActive(false);
        transform.Find("NewGameSet").gameObject.SetActive(true);


    }

    public void NewARScan(Text pName)
    {
        string playerName = pName.text;
        if (playerName == null || playerName=="")
        {

            ErrorMessage("This name is null! Please fill a name.");


        }
        else
        {
           
              string newFilePath = Application.persistentDataPath + "/SavePlayer\\"+playerName+".fun";
           // Debug.Log("New File : " + newFilePath);

            if (allSaveFiles.Contains(newFilePath))
              {
                //Debug.Log("Name already Exist!");
                ErrorMessage("This name already exist! Please Rename.");
              }
              else
              {
                  SaveSystem.playerName = playerName;
                  Debug.Log("System Name : " + SaveSystem.playerName);

                //Hardcode -> Number of pages
                  Player nPlayer = new Player(playerName,23);
                  nPlayer.SavePlayer();


                  SceneManager.LoadScene("ARScan", LoadSceneMode.Single);
              }


        }
    }
    public void BackMainMenu()
    {
        transform.Find("NewGameSet").gameObject.SetActive(false);
        SetMenuBunttonActive();
    }



    public void ContinueAction()
    {
         SceneManager.LoadScene("ContinueMenu", LoadSceneMode.Single);

    }

    public void PlayHowTo()
    {
        SceneManager.LoadScene("Instruction", LoadSceneMode.Single);

    }

    public void ErrorMessage(string error)
    {
        Debug.Log("Input : " + error);
        GameObject messageBox = transform.Find("MessageBox").gameObject;
        Text[] errorText = messageBox.GetComponentsInChildren<Text>();
        errorText[0].text = error;
        messageBox.SetActive(true);

    }

    public void CloseErrorMessage()
    {
        transform.Find("MessageBox").gameObject.SetActive(false);
    }
}
