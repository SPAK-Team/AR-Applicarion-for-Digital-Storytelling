using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelSetting : MonoBehaviour
{
    [SerializeField]
    public Image itemImage;

    [SerializeField]
    public GameObject gamePanel;

    [SerializeField]
    private Button itemButton;

    public string nameScene;
    public Scene thisScene;

    void Start()
    {
        itemImage.gameObject.SetActive(false);

        thisScene = SceneManager.GetActiveScene();
        nameScene = thisScene.name;
        nameScene = "Current Scene: " + nameScene;
        Debug.Log(nameScene);
    }

    public void NewImage()
    {
        itemImage.gameObject.SetActive(true);
        itemButton.gameObject.SetActive(false);
        gamePanel.SetActive(false);
    }
}
