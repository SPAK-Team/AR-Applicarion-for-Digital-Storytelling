using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TestClass;

public class OpenPanel : MonoBehaviour
{
    [SerializeField]
    public GameObject itemPanel;

    [SerializeField]
    public GameObject fasionPanel;

    void Start()
    {
        itemPanel.SetActive(true);
        fasionPanel.SetActive(false);
    }

    public void OpenItemPanel()
    {
        itemPanel.SetActive(true);
        fasionPanel.SetActive(false);
    }
    public void OpenFasionPanel()
    {
        itemPanel.SetActive(false);
        fasionPanel.SetActive(true);
    }

}
