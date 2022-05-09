using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    public AudioSource myMusic;

    void Start()
    {
        myMusic.Stop();
    }
    public void SetMusic()
    {
        myMusic.Play();
    }
}
