using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveRow : MonoBehaviour
{
    private string saveName="none";
    public void SetRow(string name)
    {
        saveName = name;

        Text[] saveText = GetComponentsInChildren<Text>();
        saveText[0].text= saveName;
    }
    

    public void SelectedSave()
    {
        //  Debug.Log(saveName);
        //string conFilePath = Application.persistentDataPath + "/SavePlayer\\" + saveName + ".fun";

        SaveSystem.playerName = saveName;
        Debug.Log("System Name : " + SaveSystem.playerName);

        

        SceneManager.LoadScene("ARScan", LoadSceneMode.Single);
    }
}
