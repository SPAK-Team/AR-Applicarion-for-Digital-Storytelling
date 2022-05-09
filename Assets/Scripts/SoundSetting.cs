using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public AudioSource myMusic;
    private int IsPressed = 0;

    [SerializeField]
    public Button speakerButton;
    public Sprite newBGimage;
    public Sprite originalBGimage;

    void Start()
    {
        myMusic.Stop();
    }

    public void SetSoundGame()
    {
        Debug.Log(IsPressed);
        if (IsPressed == 0)
        {
            speakerButton.image.sprite = originalBGimage;
            myMusic.Play();
            IsPressed = 1;
        }
        else if (IsPressed == 1)
        {
            speakerButton.image.sprite = newBGimage;
            myMusic.Stop();
            IsPressed = 0;
        }
    }
}
