using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using DataClass;
using System;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(ARTrackedImageManager))]


public class ImageTrackingCustom : MonoBehaviour
{
    // Test Only
   /* [SerializeField]
    private Text TestText;*/


    // Prefeb Models
    [SerializeField]
    private GameObject[] PrefabsSet;


    // Dialog Manager
    [SerializeField]
    private DialogManager dialogManager;

    // Word Manager
    [SerializeField]
    private WordManager wordManager;

    // Option Manager
    [SerializeField]
    private OptionManager optionManager;


    // WrongPage Box
    [SerializeField]
    private GameObject wrongBox;




    // AR Object Set - Retrieve by prefab name
    private Dictionary<string, Page> allPages = new Dictionary<string, Page> { };
    
    // From Original ARTrackedImageManager (Marker)
    private ARTrackedImageManager trackedImageManager;



    // Instance Object Model Set 
    private Dictionary<string, GameObject> RespawnSet = new Dictionary<string, GameObject> { };


    // Keep Page was read
    private bool[] isPageRead;

    //Current Read
    private string readingPage ="S0";

    //Next Read
    private string nextPage = "S1";


    // Player
    [SerializeField]
    private Player player;

    // AR Session
    [SerializeField]
    private ARSession arSession;

    //Boolean Check WrongBox will show
    private bool wrongBoxActive = true;

   

    //Test Var
    private string changeText="none";


    private void Awake()
    {
        // get original ARTrackedImageManager
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        // setup all game objects in dictionary
        foreach (GameObject prefab in PrefabsSet)
        {
            Page tempPage = new Page(prefab.name, prefab); 
            allPages.Add(prefab.name, tempPage);
           // Debug.Log("Type page : " + allPages[prefab.name].getType());
    

        }

        //----- Load Player -Run From MainMenu only ----------
         player.LoadPlayer();
         readingPage = "S0";
         nextPage = player.getNextPage();
         isPageRead = player.getAllPageFlag();
         //TestText.text = "FirstNext : " + nextPage;
      

        //---------------- Test on PC Only ------------------
        
      /*  player = new Player("Test123456", 23);
        readingPage = "S0";
        nextPage = "S19";
        isPageRead = player.getAllPageFlag();

        string pageName = "S1";

        wrongBoxActive = false;
        dialogManager.SetDialogText(allPages[pageName].getStory(), allPages[pageName].getType(), allPages[pageName].getExtraType());
        dialogManager.SetDialogVisible(true);
        wordManager.SetWordButton(allPages[pageName].getWord());
        //wordManager.SetBoxActive(true);
        optionManager.SetOptionChoice(allPages[pageName].getChoice());
        readingPage = pageName;
        */

    }

    private void Update()
    {
        
        int pageNumber = int.Parse(nextPage.Replace("S", "")) - 1;

        //Test Only (Show status)
       /* TestText.text = "Reading:" + readingPage + "  Next:" + nextPage + "  isRead:" + isPageRead[pageNumber] + "\n" + changeText+
            "\n Response Size: "+RespawnSet.Count+"\nWrongActive: "+ wrongBoxActive + "\nWrongActiveReal: " + wrongBox.activeSelf
            ;*/

        // Setting Display Number of page that user must scan
        Text[] nextText = wrongBox.GetComponentsInChildren<Text>();
        nextText[0].text = nextPage.Replace("S", "").Trim();

        // Check user scan successfully
        if (readingPage == "S0")
        {
            wrongBoxActive = true;
        }

        //Check choice box is display
        if (optionManager.GetOptionActive() || optionManager.GetResultActive())
        {
            wrongBoxActive = false;
        }


        wrongBox.SetActive(wrongBoxActive);



    }


    private void OnEnable()
    {

        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        changeText = eventArgs.ToString();
        // Add Instance , Respawn 3d Model
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            var pageName = trackedImage.referenceImage.name.ToString();

            Vector3 modelRotation = trackedImage.transform.rotation.eulerAngles;
            modelRotation = new Vector3(0 , 180 , 0);
            
            GameObject temp = Instantiate(allPages[pageName].getPrefab(), trackedImage.transform.position, Quaternion.Euler(modelRotation));
            RespawnSet.Add(pageName, temp);
        }

        // Update Instance , Check marker
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            var pageName = trackedImage.referenceImage.name.ToString();
            Debug.Log("ARImage Update : " + pageName);
            int pageNumber = int.Parse(pageName.Replace("S", ""))-1;


            if (trackedImage.trackingState == TrackingState.Tracking){
                    // First Time Access
                    if (nextPage == pageName )
                    {

                    wrongBoxActive = false;


                    // if this page is first meet and not have reading page (S0)
                    if (isPageRead[pageNumber] == false && readingPage == "S0")
                        {
                            dialogManager.SetDialogText(allPages[pageName].getStory(), allPages[pageName].getType(), allPages[pageName].getExtraType());
                            dialogManager.SetDialogVisible(true);
                            wordManager.SetWordButton(allPages[pageName].getWord());
                            optionManager.SetOptionChoice(allPages[pageName].getChoice());
                            readingPage = pageName;

                         // Test Only
                        /*  wordManager.SetBoxActive(true);
                            TestText.text = "Choice Size: " + allPages[pageName].getChoice().Count;
                            TestText.text = "Page : " + readingPage;*/

                    }
                }
                    else
                    {
                        dialogManager.SetDialogVisible(false);
                       // wordManager.SetBoxActive(false);
                        wrongBoxActive = true;
                        RespawnSet[pageName].SetActive(false);


                }

                //-----------------------------------------------
                if (readingPage == pageName)
                {

                    RespawnSet[pageName].SetActive(true);
                    Vector3 modelRotation = trackedImage.transform.rotation.eulerAngles;
                    modelRotation = new Vector3(0, 180 , 0);
                    RespawnSet[pageName].transform.SetPositionAndRotation(trackedImage.transform.position, Quaternion.Euler(modelRotation));

                    dialogManager.SetDialogVisible(true);
                   // wordManager.SetBoxActive(true);

                    if (optionManager.GetOptionActive() || optionManager.GetResultActive())
                    {
                        dialogManager.SetDialogVisible(false);
                        //wordManager.SetBoxActive(false);
                    }
                   


                    
                }
                else
                {
                    RespawnSet[pageName].SetActive(false);

                }

            }
            else
            {
                    RespawnSet[pageName].SetActive(false);
                


            }


        }





        // Remove Instance
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            var pageName = trackedImage.referenceImage.name.ToString();

            Debug.Log("ARImage Remove : " + pageName);
            Destroy(RespawnSet[pageName]);
            
        }
    }




    // Update Status and Save user file
    public void UpdateSuccessPages(Text optionText)
    {
        int pageNumber = int.Parse(readingPage.Replace("S", "")) - 1;

        // Because S3 can multiple visit
        if (readingPage == "S3") {
            if (isPageRead[3] && isPageRead[7] && isPageRead[10] && isPageRead[14])
            {
                isPageRead[pageNumber] = true;
                nextPage = "S23";

            }
            else
            {
                nextPage = "S" + optionText.text.Trim();


            }
        }
        else
        {
            isPageRead[pageNumber] = true;
            nextPage = "S" + optionText.text.Trim();


        }

        optionManager.SetResultActive(false);
        readingPage = "S0";
        player.SetNextPage(nextPage);
        player.SetAllPageFlag(isPageRead);
        player.SetPoint(wordManager.getPlayerPoint());
        player.SavePlayer();


        if(nextPage == "S3")
        {

            SceneManager.LoadScene("ARScan", LoadSceneMode.Single);

        }


    }



  

}


