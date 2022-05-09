using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataClass {

    //-------------------- Page Class --------------------------------------------
    public class Page
    {
        // name = Number of Page example "S1" = Page 1
        private string name;
        // 3D Model
        private GameObject prefab;
        // Set of Story
        private string[] allStory;
        // Set of word
        private Dictionary<string,Word> allWord  = new Dictionary<string, Word> { };
        // Set of choice
        private Dictionary<string, Choice> allChoice = new Dictionary<string, Choice> { };
        // Type of Page - choice or minigame (choice will be pass/not) or  ending (will be end,typeofend)
        private string type;
        private string extraType = "none";

        //Constructor
        public Page(string pageName, GameObject pagePrefab)
        {
            name = pageName;
            prefab = pagePrefab;

            TextAsset TextFile = (TextAsset)Resources.Load("StoryText/" + name, typeof(TextAsset));
            var fileString = TextFile.text;
            allStory = fileString.Split('\n');


            TextAsset WordFile = (TextAsset)Resources.Load("WordText/" + name, typeof(TextAsset));
            var wordString = WordFile.text;
            var wordFileSet = wordString.Split('\n');
            var engWordSet = wordFileSet[0].Split('/');
            var posWordSet = wordFileSet[1].Split('/');
            var thWordSet = wordFileSet[2].Split('/');

            for (int i = 0; i < engWordSet.Length; i++)
            {
                Word tempWord = new Word(engWordSet[i], posWordSet[i], thWordSet[i]);
                allWord.Add(engWordSet[i], tempWord);
            }

                  TextAsset OptionFile = (TextAsset)Resources.Load("OptionText/" + name, typeof(TextAsset));
                   var optionString = OptionFile.text;
           // Debug.Log("string = " + optionString);

            var optionSet = optionString.Split('\n');

            int optionSize = optionSet.Length;

            if (optionSize > 3)
            {
                type = "main";
            }
            for (int i = 0; i< optionSize; i++)
                   {

                var lineSet = optionSet[i].Split(',');
             //   Debug.Log(name+" - Option Size: " + lineSet.Length);

                   Choice tempChoice = new Choice(lineSet[0], lineSet[1]);
                allChoice.Add(lineSet[0], tempChoice);
                if (i == 0 && type!="main")
                {
                    if (lineSet[0] == "pass")
                    {
                        type = "minigame";
                       
                        extraType = lineSet[2];
                       // Debug.Log("Minigame - " + extraType);



                    }
                    else if (lineSet[0]=="end")
                    {
                        type = "endding";
                        extraType = lineSet[1];
                        //Debug.Log("Endding - " + extraType);

                    }

                    else
                    {
                        type = "choice";
                    }
                }

            }





        }



        // Constructor for Minigame
        public Page(string pageName)
        {
            name = pageName;
            prefab = (GameObject)Resources.Load("Prefabs/" + name, typeof(GameObject)); 

            TextAsset TextFile = (TextAsset)Resources.Load("StoryText/" + name, typeof(TextAsset));
            var fileString = TextFile.text;
            allStory = fileString.Split('\n');


            TextAsset WordFile = (TextAsset)Resources.Load("WordText/" + name, typeof(TextAsset));
            var wordString = WordFile.text;
            var wordFileSet = wordString.Split('\n');
            var engWordSet = wordFileSet[0].Split('/');
            var posWordSet = wordFileSet[1].Split('/');
            var thWordSet = wordFileSet[2].Split('/');

            for (int i = 0; i < engWordSet.Length; i++)
            {
                Word tempWord = new Word(engWordSet[i], posWordSet[i], thWordSet[i]);
                allWord.Add(engWordSet[i], tempWord);
            }

            TextAsset OptionFile = (TextAsset)Resources.Load("OptionText/" + name, typeof(TextAsset));
            var optionString = OptionFile.text;
            // Debug.Log("string = " + optionString);

            var optionSet = optionString.Split('\n');

            int optionSize = optionSet.Length;

            if (optionSize > 3)
            {
                type = "main";
            }
            for (int i = 0; i < optionSize; i++)
            {

                var lineSet = optionSet[i].Split(',');
                //   Debug.Log(name+" - Option Size: " + lineSet.Length);

                Choice tempChoice = new Choice(lineSet[0], lineSet[1]);
                allChoice.Add(lineSet[0], tempChoice);
                if (i == 0 && type != "main")
                {
                    if (lineSet[0] == "pass")
                    {
                        type = "minigame";

                        extraType = lineSet[2];
                        // Debug.Log("Minigame - " + extraType);



                    }
                    else if (lineSet[0] == "end")
                    {
                        type = "endding";
                        extraType = lineSet[1];
                        //Debug.Log("Endding - " + extraType);

                    }

                    else
                    {
                        type = "choice";
                    }
                }

            }





        }

        public GameObject getPrefab()
        {
            return prefab;
        }

        public string[] getStory()
        {
            return allStory;
        }
        public Dictionary<string, Word> getWord()
        {
            return allWord;
        }

        public Dictionary<string, Choice> getChoice()
        {
            return allChoice;
        }

        public string getName()
        {
            return name;
        }

        public string getType()
        {
            return type;
        }

        public string getExtraType()
        {
            return extraType;
        }

    }


    //-------------------- Word Class --------------------------------------------

    public class Word
    {
        private string enWord;
        private string posTag;
        private string thWord;
        private string[] synnonymWord; //Not use now

        public Word(string en,string pos ,string th)
        {
            enWord = en;
            posTag = pos;
            thWord = th;
            
        }

        public string getEngWord()
        {
            return enWord;
        }



        public string getVocab()
        {
            return enWord + "(" + posTag + ") = " + thWord;
        }


        public string getThWord()
        {
            return thWord;
        }


       

    }

 //-------------------- Choice Class --------------------------------------------
    public class Choice
    {
        private string myChoice;
        private string nextPage;

        public Choice(string choice,string nPage)
        {
            myChoice = choice;
            nextPage = nPage;
        }

        public string getNextPage()
        {
            return nextPage;
        }


    }


 

}