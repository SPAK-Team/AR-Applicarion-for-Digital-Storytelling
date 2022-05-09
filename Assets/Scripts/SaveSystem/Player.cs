using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private string name ="Test";
    private string nextPage = "S1";
    private bool[] isPageRead;
    private int point;
    private bool[] haveItem = new bool[6];
    private bool[] isTest;
  //  private List<KeyValuePair<string, int>> minigamePointList;

    public Player(string n,int totalPage)
    {
        name = n;
        nextPage = "S1";
        isPageRead = new bool[totalPage];
        isTest = new bool[totalPage];
        for(int i = 0; i < totalPage; i++)
        {

            isPageRead[i] = false;
            isTest[i] = false;
        }
        //  minigamePointList = new List<KeyValuePair<string, int>>();
        point = 0;
        for (int i = 0; i < haveItem.Length; i++)
        {

            haveItem[i] = false;
        }
    }
    public string getName()
    {
        return name;
    }

    public string getNextPage()
    {
        return nextPage;
    }

    public bool[] getAllPageFlag()
    {
        return isPageRead;
    }

    public int getPoint()
    {
        return point;
    }

    public bool[] getAllItemFlag()
    {
        return haveItem;
    }

    public bool[] getAllTestFlag()
    {
        return isTest;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }


    public void SaveMinigameRecord(string gameType,string storyType,List<string> correctSum, List<string> wrongSum)
    {
        SaveSystem.SaveMinigameRecord(this.name, gameType, storyType,correctSum, wrongSum);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        name = data.getName();
        nextPage = data.getNextPage();
        isPageRead = data.getAllPageFlag();
        point = data.getPoint();
        haveItem = data.getAllItemFlag();
        isTest = data.getAllTestFlag();
       // minigamePointList = data.getAllMinigamePoint();
    }

    public void SetNextPage(string p)
    {
        
        nextPage = p;
    }


    public void SetAllPageFlag(bool[] allFlag)
    {

        isPageRead = allFlag;
    }

    public void SetAllTestFlag(bool[] allFlag)
    {

        isTest = allFlag;
    }

    public void SetOnePageFlag(int num,bool flag)
    {

        isPageRead[num] = flag;
    }

    public void SetPoint(int num)
    {
        point = num;

    }

    public void IncreasePoint(int num)
    {
        point = point + num;

    }


    public void ResetRoute()
    {
        for(int i = 0; i < isPageRead.Length; i++)
        {
            isPageRead[i] = false;
            isTest[i] = false;
        }
        nextPage = "S1";

    }



    public void SetItemFlag(int num, bool flag)
    {

        haveItem[num] = flag;
    }


    public void SetAllItemFlag(bool[] allFlag)
    {

        haveItem = allFlag;
    }

    /*public void AddToMinigamePointList(string typ, int poi)
    {
        minigamePointList.Add(new KeyValuePair<string, int>(typ, poi));
    }
    public KeyValuePair<string, int> getLastMinigamePointList()
    {
        return minigamePointList.Last();
    }


    public List<KeyValuePair<string, int>> GetAllMinigamePointList()
    {
        return minigamePointList;
    }*/
}
