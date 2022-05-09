using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadPrivilegeScene : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public void SceneLoader()
    {
        Debug.Log("Scene Loaded");
        SceneManager.LoadScene("Privilege_update", LoadSceneMode.Single);
        
    }
    public void LoadAR()
    {
        SceneManager.LoadScene("Main_update", LoadSceneMode.Single);
    }

    public void LoadSumVocab1()
    {
        SceneManager.LoadScene("SumVocaburaly1_update", LoadSceneMode.Single);
    }
    public void LoadSumVocab2()
    {
        SceneManager.LoadScene("SumVocaburaly2_update", LoadSceneMode.Single);
    }
    public void LoadSumVocab3()
    {
        SceneManager.LoadScene("SumVocaburaly3_update", LoadSceneMode.Single);
    }
    public void LoadSumVocab4()
    {
        SceneManager.LoadScene("SumVocaburaly4_update", LoadSceneMode.Single);
    }
    public void LoadSumVocab5()
    {
        SceneManager.LoadScene("SumVocaburaly5_update", LoadSceneMode.Single);
    }


   public void QuitApp()
    {
        // Save & Reset Before Quit !!!!
        player.ResetRoute();
        player.SavePlayer();
        Application.Quit();
    }


    public void Reload()
    {
        // Save & Reset Before Quit !!!!

        player.ResetRoute();
        player.SavePlayer();
        SceneManager.LoadScene("ARScan", LoadSceneMode.Single);
    }


}
