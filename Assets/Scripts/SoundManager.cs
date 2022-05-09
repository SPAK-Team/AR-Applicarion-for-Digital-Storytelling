using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;


    // Sound Set
    [SerializeField]
    private GameObject soundSet;


    // Start is called before the first frame update
    void Start()
    {

        if (!PlayerPrefs.HasKey("muted"))
        {
             PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();

        }


        UpdateIcon();
        AudioListener.pause = muted;
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        if (muted==false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
            
        }
        else
        {

            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }


    //---------------- PlayerPrebs ------------------
    void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1:0);
    }
    //----------------End  PlayerPrebs ------------------


    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            
        }
        else
        {
            muted = false;
            AudioListener.pause = false;

        }

        Save();
        UpdateIcon();
    }




    //Play coin sound
    public void PlayCoinSound()
    {
        AudioSource[] soundSource = soundSet.GetComponentsInChildren<AudioSource>();
        soundSource[0].Play();
    }


    public void PlayWordSound()
    {
        AudioSource[] soundSource = soundSet.GetComponentsInChildren<AudioSource>();
        soundSource[1].Play();

    }

    public void PlayButtonSound()
    {
        AudioSource[] soundSource = soundSet.GetComponentsInChildren<AudioSource>();
        soundSource[2].Play();

    }
}
