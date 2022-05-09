using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataClass;
using TMPro;
using UnityEngine.SceneManagement;

public class BonusGameManager : MonoBehaviour
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


    private Word goalWord;
    private Word[] choiceWord = new Word[4];

    private List<Word> allWord = new List<Word>();

    private int playerPoint = 0;

    //Use real - in word not int
    private List<string> usedWord = new List<string>();


    private List<int> allRoutePage = new List<int>() ;


    private List<KeyValuePair<string,int>> minigamePointList;
    private string currentPagename;


    private string type = "none";



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


    private int totalQuiz = 5;


    void Awake()
    {

        //Real
        player.LoadPlayer();

        //For Testing
     /*   player = new Player("Test",23);
        player.SetNextPage("S23");
       // player.SetOnePageFlag(18, true);
       // player.SetOnePageFlag(2, true);*/

        currentPagename = player.getNextPage();
        Debug.Log(currentPagename);


        Page currentPage = new Page(currentPagename);
       
        titleText.text = "มาเพิ่มแต้มสะสมพิเศษเพื่อแลกรางวัลกันเถอะ!";


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
            // false -> Pass 3 but not last pass
            // true -> Pass 3 4 times 
            if (i == 2 && isPage[i]==false)
            {
                int pageNum = i + 1;
                allRoutePage.Add(pageNum);
            }

        }

        // add current page
        int currentNum = int.Parse(currentPagename.Replace("S", "")) ;
        allRoutePage.Add(currentNum);
        isTest[currentNum - 1] = true;
        Debug.Log(allRoutePage.Count);

        player.SetAllTestFlag(isTest);

        if (allRoutePage.Count == 1)
        {
            allRoutePage.Add(1);
        }





        //--------- Test Only ------------------
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



   /* void generateImageChoice()
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
    }*/

    void generateWord()
    {

        //  Debug.Log(allWord.Count);
        //Test
        List<int> generatedNum = new List<int>();
        int randomNum = Random.Range(0, allWord.Count);

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


              while (generatedNum.Contains(randomNum) == true)
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

        string sumEndScene;

        if (currentPagename == "S19")
        {

            sumEndScene = "SumVocaburaly1_update";
            type = "wealth";
        }
        else if (currentPagename == "S20")
        {

            sumEndScene = "SumVocaburaly2_update";
            type = "love";


        }
        else if (currentPagename == "S21")
        {

            sumEndScene = "SumVocaburaly3_update";
            type = "art";


        }
        else if (currentPagename == "S22")
        {

            sumEndScene = "SumVocaburaly4_update";
            type = "food";


        }
        else if (currentPagename == "S23")
        {

            sumEndScene = "SumVocaburaly5_update";
            type = "special";


        }
        else
        {
            sumEndScene = "MainMenu";
        }

        player.SaveMinigameRecord("ending", type, correctSum, wrongSum);
        SceneManager.LoadScene(sumEndScene, LoadSceneMode.Single);

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
        pointText.text = "Q. " + usedWord.Count + "/" + totalQuiz;

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
        player.SetOnePageFlag(pageNumber, true);

        nextPageText.text = correctSum.Count + " คะแนน";

        player.IncreasePoint(correctSum.Count);
        player.SavePlayer();







    }


}
