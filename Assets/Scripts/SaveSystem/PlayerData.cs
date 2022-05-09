using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataClass;

[System.Serializable]
public class PlayerData 
{
    private string name;
    private string nextPage;
    private bool[] isPageRead;
    private int point;
    private bool[] haveItem;
    private bool[] isTest;
  //  private List<KeyValuePair<string, int>> minigamePointList;

    public PlayerData(Player player)
    {
        name = player.getName();
        nextPage = player.getNextPage();
        isPageRead = player.getAllPageFlag();
        point = player.getPoint();
        haveItem = player.getAllItemFlag();
        isTest = player.getAllTestFlag();
     //   minigamePointList = player.GetAllMinigamePointList();

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

    /*
        public List<KeyValuePair<string, int>> getAllMinigamePoint()
        {
            return minigamePointList;
        }*/

}
