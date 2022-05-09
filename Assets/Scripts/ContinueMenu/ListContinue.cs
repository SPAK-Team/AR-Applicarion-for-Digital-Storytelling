using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ListContinue : MonoBehaviour
{
    private string[] allSaveFiles;


    [SerializeField]
    private GameObject rowTemp;

    private ArrayList allRow = new ArrayList();
 
    void Start()
    {
        string filePath = Application.persistentDataPath + "/SavePlayer";
        string[] files = System.IO.Directory.GetFiles(filePath);
        allSaveFiles = files;
        var rectTransform = rowTemp.GetComponent<RectTransform>();

        foreach(string file in allSaveFiles)
        {
            var temp = Instantiate(rowTemp, rectTransform);
            temp.transform.SetParent(this.gameObject.transform);


            var tempScript = temp.GetComponent<SaveRow>();
            string name = Path.GetFileName(file).Replace(".fun", "");
            tempScript.SetRow(name);


            temp.SetActive(true);
            allRow.Add(temp);


        }
        


        




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
