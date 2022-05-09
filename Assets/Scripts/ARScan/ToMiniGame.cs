using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMiniGame : MonoBehaviour
{
 
    public void GotoMiniGmae()
    {
        SceneManager.LoadScene("Minigame", LoadSceneMode.Single);

    }
}
