using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ButtonGroup : MonoBehaviour
{
    
    
    public void QuitAR()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }

    public void CaptureScreen()
    {
        ScreenCapture.CaptureScreenshot("Screencapture");
    }

   
}
