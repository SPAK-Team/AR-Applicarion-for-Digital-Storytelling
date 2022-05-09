using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{

    [SerializeField]
    private GameObject nextSet;

    [SerializeField]
    private GameObject exitSet;

    public void ShowNextBox()
    {
        exitSet.SetActive(false);
        nextSet.SetActive(true);
    }

    public void ShowExitBox()
    {
        exitSet.SetActive(true);
        nextSet.SetActive(false);
    }

    public void HideNextBox()
    {
        nextSet.SetActive(false);
    }

    public void HideExitBox()
    {
        exitSet.SetActive(false);
    }

    
}
