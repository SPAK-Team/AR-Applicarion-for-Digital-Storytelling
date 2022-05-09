using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using DataClass;
public class WordManager : MonoBehaviour
{

    public Text[] wordTextButtonGroup;
    public Text detailText;
    public GameObject detailBox;

    private Dictionary<string, Word> allVocab = new Dictionary<string, Word>{};

    [SerializeField]
    private Player player;

    [SerializeField]
    private Text pointText;

    [SerializeField]
    private AudioSource wordAudio;

    [SerializeField]
    private SoundManager soundManager;

    private bool[] firstClick = new bool[5];

    private int pointPlayer = 0;


    //Test Only
    /*  void Awake(){
          CreateWordSet("S1");
      }*/


    void Start()
    {
        player.LoadPlayer();
        pointPlayer = player.getPoint();


    }
    public void SetWordButton(Dictionary<string, Word> vocabSet)
    {
        allVocab = vocabSet;
            for (int i=0;i<5;i++){
           // Debug.Log(allVocab.ElementAt(i).Value.getEngWord());

                
                wordTextButtonGroup[i].text = allVocab.ElementAt(i).Value.getEngWord();
                firstClick[i] = true;
            var animator = wordTextButtonGroup[i].transform.parent.gameObject.GetComponentInChildren<Animator>();
            animator.Play("ImgBlink", 0, 0.25f);

        }
            detailBox.SetActive(true);
        wordTextButtonGroup[0].transform.parent.gameObject.transform.parent.gameObject.SetActive(true);



    }

    public void SetDetailText(int x)
    {
        //string key = wordTextButtonGroup[x].text;

        if (firstClick[x] == true)
        {
            var animator = wordTextButtonGroup[x].transform.parent.gameObject.GetComponentInChildren<Animator>();
            animator.Play("ImgBlinkEnd", 0, 0.25f);
            pointPlayer = pointPlayer + 1;
            soundManager.PlayCoinSound();
            firstClick[x] = false;

        }
        else
        {
            soundManager.PlayButtonSound();

        }
        detailText.text = allVocab.ElementAt(x).Value.getVocab();
        player.SetPoint(pointPlayer);
        SetBoxActive(true);

        //Set Sound
        AudioClip wordClip = (AudioClip)Resources.Load("Audio/Vocab/"+ allVocab.ElementAt(x).Value.getEngWord().Trim());
        wordAudio.clip = wordClip;


    }


    public void FoundWord(int x){
        
        

        wordTextButtonGroup[x].transform.parent.gameObject.SetActive(true);

    }


    public void SetButtonGroupActive(bool x)
    {


        foreach(Text wordText in wordTextButtonGroup){
           wordText.transform.parent.gameObject.SetActive(x);

        }

    }


    public void SetBoxActive(bool show)
    {
        var animator = detailBox.GetComponentInChildren<Animator>();

        if (show)
        {
            animator.Play("slide", 0, 0.25f);

        }
        else
        {
            animator.Play("slideB", 0, 0.25f);

        }
    }


    public int FoundWordCount()
    {
        int count = 0;
        foreach (Text wordText in wordTextButtonGroup)
        {
            if (wordText.transform.parent.gameObject.activeSelf==true)
            {
                count = count + 1;

            }

        }
        return count;
    }

    void Update()
    {
        pointText.text = pointPlayer.ToString();

    }

    public int getPlayerPoint()
    {
        return pointPlayer;
    }


    

}