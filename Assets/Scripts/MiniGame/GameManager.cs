using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataClass;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Image goalObject;

    [SerializeField]
    private Image[] allChoiceObject;

    [SerializeField]
    private Text pointText;

    [SerializeField]
    private TextMeshProUGUI titleText;

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private Text choiceTitleText;
    [SerializeField]
    private Text nextPageText;


    //Result UI
    [SerializeField]
    private Image resultBoard;
    [SerializeField]
    private Image emojiImg;
    [SerializeField]
    private Text testText;

    private string type = "none";

    private Word goalWord;
    private Word[] choiceWord = new Word[4];

    private List<Word> allWord = new List<Word>();

    private int playerPoint = 0;

    //Use real - in word not int
    private List<string> usedWord = new List<string>();

    //HardCode -> Change to file
    // wealth , love , art , food
    private string[] allTitleGame = {
        "ªèÇÂâ»àÅÕèÂ§ÍÑ¹µÃÒÂ·Õè¨Ðà¡Ô´¢Öé¹ ´éÇÂ¡ÒÃÅÒ¡<b><u>ÁÒÃì¤</u></b>·Õèâ»ºÍ¡Å§º¹<b><u>á¼¹·Õè</u></b>",
        "ªèÇÂâ»ËÅºÊÔè§¡Õ´¢ÇÒ§ ´éÇÂ¡ÒÃÅÒ¡<b><u>ÊÔè§·ÕèàÃ×Í¡ÓÅÑ§à¨Í</u></b>µÒÁ·Õèâ»ºÍ¡à¾×èÍä»ÂÑ§<b><u>à¡ÒÐ·Õè¤¹ÃÑ¡ÍÂÙè</u></b>",
        "ªèÇÂâ»ÊÃéÒ§ÊÃÃ¤ì¼Å§Ò¹ ´éÇÂ¡ÒÃÅÒ¡<b><u>ÍØ»¡Ã³ì</u></b>·Õèâ»¢ÍÅ§º¹<b><u>¡ÃÐ´Ò¹ÇÒ´ÃÙ»</u></b>",
        "ªèÇÂâ»·ÓÍÒËÒÃ ´éÇÂ¡ÒÃÅÒ¡<b><u>ÇÑµ¶Ø´Ôº</u></b>µÒÁÊÙµÃ·Õèâ»ºÍ¡Å§ã¹<b><u>ËÁéÍ</u></b>"};


    private List<int> allRoutePage = new List<int>() ;


    private List<KeyValuePair<string,int>> minigamePointList;
    private Dictionary<string, Choice> allChoice;
    private string currentPagename;




    // --------------- Summary ------------------------------

    private List<string> correctSum = new List<string>();
    private List<string> wrongSum = new List<string>();

    [SerializeField]
    private GameObject SummaryBox;

    [SerializeField]
    private Text correctCountText;
    [SerializeField]
    private Text wrongCountText;
    [SerializeField]
    private Text correctSumText;
    [SerializeField]
    private Text wrongSumText;

    // -------------- End Summary ----------------------------


    private int totalQuiz = 20;


    void Awake()
    {

        //Real
        player.LoadPlayer();

        //For Testing
       /* player = new Player("Test",23);
        player.SetNextPage("S9");
        player.SetOnePageFlag(8, true);
        player.SetOnePageFlag(7, true);*/

        currentPagename = player.getNextPage();
        Debug.Log(currentPagename);

        if (currentPagename == "S5")
        {
            type = "wealth";
        }
        else if (currentPagename == "S9")
        {
            type = "love";
        }
        else if (currentPagename == "S12")
        {
            type = "art";
        }
        else if (currentPagename == "S17")
        {
            type = "food";
        }
        else
        {

        }

        Page currentPage = new Page(currentPagename);
        allChoice = currentPage.getChoice();
        var sprite = Resources.Load<Sprite>("Image/UI/Minigame/"+type+"/goal");
        goalObject.sprite = sprite;
        int selection = -1;

         if (type=="wealth")
        {
            selection = 0;
            //allRoutePage = new int[] { 1, 2, 3, 4, 5 };
        }
        else if (type=="love")
        {
            selection = 1;
          //  allRoutePage = new int[] { 1, 2, 3, 8, 9 };
        }
        else if (type=="art")
        {
            selection = 2;
           // allRoutePage = new int[] { 1, 2, 3, 11, 12 };
        }
        else if (type=="food")
        {
            selection = 3;
          //  allRoutePage = new int[] { 1, 2, 3, 15, 16 };
        }
        else
        {
            Debug.Log("Error! not have title");
          // allRoutePage = new int[] { };
        }
        titleText.text = allTitleGame[selection];


        //------- Generate Page ----------------
        bool[] isPage = player.getAllPageFlag();
         bool[] isTest = player.getAllTestFlag();
        testText.text = "Page Size : " + isPage.Length.ToString() + "\nTest Size : " + isTest.Length.ToString();


        for (int i=0;i<isPage.Length;i++)
        {
            if(isPage[i]==true && isTest[i]==false)
            {
                isTest[i] = true;
                int pageNum = i + 1;
                allRoutePage.Add(pageNum);
            }

            // Page 3 - false for re-read
            if (i == 2)
            {
                int pageNum = i + 1;
                allRoutePage.Add(pageNum);
            }

        }

        // add current page
        int currentNum = int.Parse(currentPagename.Replace("S", "")) ;
        allRoutePage.Add(currentNum);
        isTest[currentNum - 1] = true;

        player.SetAllTestFlag(isTest);




        //--------- Test Only ------------------

        if (allRoutePage.Count == 4)
        {
            allRoutePage.Add(1);
            allRoutePage.Add(2);

        }
        if (allRoutePage.Count == 5)
        {
            allRoutePage.Add(1);

        }


        foreach (int num in allRoutePage)
        {
            // int[] allRouteWord = {1,5,6}
            //foreach(int num in allRouteWord ){
            //}

            TextAsset WordFile = (TextAsset)Resources.Load("WordText/S" + num.ToString(), typeof(TextAsset));
            var wordString = WordFile.text;
            var wordFileSet = wordString.Split('\n');
            var engWordSet = wordFileSet[0].Split('/');
            var posWordSet = wordFileSet[1].Split('/');
            var thWordSet = wordFileSet[2].Split('/');

            for (int i = 0; i < engWordSet.Length; i++)
            {
                Word tempWord = new Word(engWordSet[i], posWordSet[i], thWordSet[i]);
                allWord.Add(tempWord);
            }
        }
        Debug.Log(allWord.Count + "Last :"+allWord[allWord.Count-1].getEngWord());

        //----------- End Test -----------------


        generateWord();
        // generateImageChoice();




        resultBoard.enabled = false;
        emojiImg.enabled = false;






    }



    void generateImageChoice()
    {
        List<int> generatedNum = new List<int>();
        foreach (Image choiceObject in allChoiceObject)
        {
            int randomNum = Random.Range(1, 12);
            while(generatedNum.Contains(randomNum) == true)
            {
                randomNum = Random.Range(1, 12);
            }
            generatedNum.Add(randomNum);
            var sprite = Resources.Load<Sprite>("Image/UI/Minigame/" + type + "/"+randomNum);
            choiceObject.sprite = sprite;
        }
    }

    void generateWord()
    {

        //  Debug.Log(allWord.Count);
        //Test
        List<int> generatedNum = new List<int>();
        int randomNum = Random.Range(0, allWord.Count);
        // food
       // generatedNum = { food ,}
       //usedWord = {clever , food}
        while ((generatedNum.Contains(randomNum) == true) || (usedWord.Contains(allWord[randomNum].getEngWord())==true))
        {
            randomNum = Random.Range(0, allWord.Count);
        }
        goalWord = allWord[randomNum];
        generatedNum.Add(randomNum);
        usedWord.Add(goalWord.getEngWord());
        Debug.Log("Goal is "+goalWord.getEngWord());


 //   Debug.Log("Goal is "+randomNum);
 goalObject.GetComponentInChildren<Text>().text = goalWord.getThWord();


        // generatedNum = { food , art,girl,boy }
        // boy
        for (int i = 1; i <= 3; i++) {


              while (generatedNum.Contains(randomNum) == true || (usedWord.Contains(allWord[randomNum].getEngWord()) == true))
              {
                  randomNum = Random.Range(1, allWord.Count);
              }
              generatedNum.Add(randomNum);

          }
        // Debug.Log(generatedNum.Count);

        // generatedNum = { food , art,girl,boy }

        for (int i = 0; i < 4; i++)
        {
            int randomList = Random.Range(0, generatedNum.Count );
          //  Debug.Log("Choice " + i + " is " + generatedNum[randomList]);

            choiceWord[i] = allWord[generatedNum[randomList]];
            allChoiceObject[i].GetComponentInChildren<Text>().text = choiceWord[i].getEngWord();



            generatedNum.Remove(generatedNum[randomList]);
        }


    }


     public bool correctAnswer(string enChoice)
    {

        if (goalWord.getEngWord() == enChoice)
        {
            string correctSentence = goalWord.getEngWord() + " = " + goalWord.getThWord();
            correctSum.Add(correctSentence);

            Debug.Log(correctSentence);

            return true;

        }
        else
        {
            string wrongSentence = goalWord.getEngWord() + " = " + goalWord.getThWord()+"\n(Your Answer = " + enChoice + ")";
            wrongSum.Add(wrongSentence);
            Debug.Log(wrongSentence);

            return false;
        }
    }

    public void resetAll()
    {
        Debug.Log("UsedWord :" + usedWord.Count + "  allWord :" + allWord.Count);
        // Declare Size
        if (usedWord.Count < totalQuiz) {
            generateWord();
        //    generateImageChoice();

        }
        else
        {
            //endMinigame();
            showSummary();
            Debug.Log(playerPoint);


        }
    }

    public void goToARScan()
    {

        player.SaveMinigameRecord("minigame", type, correctSum, wrongSum);
        SceneManager.LoadScene("ARScan", LoadSceneMode.Single);

    }


    public void increasePoint()
    {
        playerPoint++;
    }


    public int getPlayerPoint()
    {
        return playerPoint;
    }




    void Update()
    {
        pointText.text = "โจทย์ที่ " + usedWord.Count + " ใน "+ totalQuiz;

    }



    public void ShowResult(bool correct)
    {
        Sprite sprite = null;
        Sprite emoji = null;
        AudioSource[] soundSet = resultBoard.GetComponentsInChildren<AudioSource>();
        if (correct)
        {
            sprite = Resources.Load<Sprite>("Image/UI/Minigame/CorrectBoard");
            emoji = Resources.Load<Sprite>("Image/UI/Minigame/correct");
            soundSet[0].Play();
        }
        else
        {
            sprite = Resources.Load<Sprite>("Image/UI/Minigame/WrongBoard");
            emoji = Resources.Load<Sprite>("Image/UI/Minigame/wrong");
            soundSet[1].Play();

        }
        resultBoard.sprite = sprite;
        emojiImg.sprite = emoji;

        resultBoard.enabled = true;
        emojiImg.enabled = true;
        StartCoroutine(Waiter());

    }



    IEnumerator Waiter()
    {
        
        yield return new WaitForSeconds(1);
        resultBoard.enabled = false;
        emojiImg.enabled = false;


    }




    public void showSummary()
    {

        correctCountText.text = correctSum.Count+"/"+ totalQuiz;
        wrongCountText.text = wrongSum.Count + "/" + totalQuiz;
        string allCorrect = "";
        string allWrong = "";
        foreach(string correct in correctSum)
        {
            allCorrect = allCorrect + correct + "\n";

        }

        foreach (string wrong in wrongSum)
        {
            allWrong = allWrong + wrong + "\n";

        }

        correctSumText.text = allCorrect;
        wrongSumText.text = allWrong;

        SummaryBox.SetActive(true);

    }




    public void endMinigame()
    {
        SummaryBox.SetActive(false);

        Debug.Log("Endding!");
        resultPanel.SetActive(true);
        string nextPage;
        int pageNumber = int.Parse(currentPagename.Replace("S", "")) - 1;

        if (playerPoint >= totalQuiz / 2)
        {
            // Send pass to optional manager in
            choiceTitleText.text = "ทำสำเร็จแล้วนะ!";
            nextPage = allChoice["pass"].getNextPage();

        }
        else
        {
            //Send not pass to optional manager in
            choiceTitleText.text = "พลาดไปหน่อยนะ!";
            nextPage = allChoice["not"].getNextPage();
        }

        nextPageText.text = nextPage;
        nextPage = "S" + nextPage.Trim();


        //  player.AddToMinigamePointList(type, playerPoint);

        player.SetNextPage(nextPage);
        player.SetOnePageFlag(pageNumber, true);

        player.SavePlayer();
    }



}
