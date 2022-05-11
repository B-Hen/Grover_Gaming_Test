///////////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: Decrease or increas the denimation by pressing a button
//Date: 05/09/22
//////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Increase_Decrease_Denomination : MonoBehaviour
{
    //vairbale for the scene manager
    [SerializeField]
    GameObject SceneManger;

    //variable for the text on screen
    [SerializeField]
    TextMeshProUGUI CurrentDenomination, CurrentWinnings;

    [SerializeField]
    Button playButton;

    //variable to hold the index and denomination numbers
    int index;
    float[] denominations;

    public void Start()
    {
        //get the array of numbers and the index
        index = SceneManger.GetComponent<SetUp>().index;
        denominations = SceneManger.GetComponent<SetUp>().demonination;
    }

    //method to increase the denomination
    public void IncreaseDenomination()
    {
        //first check to see if the index is the last elemtent in the array
        if(SceneManger.GetComponent<SetUp>().index == denominations.Length-1)
        {
            SceneManger.GetComponent<SetUp>().index = denominations.Length - 1;
        }
        //else increase the index
        else
        {
            SceneManger.GetComponent<SetUp>().index++;
        }

        if (SceneManger.GetComponent<SetUp>().demonination[SceneManger.GetComponent<SetUp>().index] >
            SceneManger.GetComponent<SetUp>().currentBalance)
        {
            CurrentWinnings.text = "Balance to low, try again when you have more money";
        }
        else
        {
            playButton.enabled = true;
        }

        //Update the current denomination text
        CurrentDenomination.text = string.Format("Current Denomination {0:C}",
            denominations[SceneManger.GetComponent<SetUp>().index]);
    }

    //method to decrease the denomination
    public void DecreaseDenomination()
    {
        //first check to see if the index is the last elemtent in the array
        if (SceneManger.GetComponent<SetUp>().index == 0)
        {
            SceneManger.GetComponent<SetUp>().index = 0;
        }
        //else increase the index
        else
        {
            SceneManger.GetComponent<SetUp>().index--;
            //GameObject.Find("PlayLogicManager").GetComponent<Play_Money_Amounts>().CanPlay();
        }

        if(SceneManger.GetComponent<SetUp>().demonination[SceneManger.GetComponent<SetUp>().index] > 
            SceneManger.GetComponent<SetUp>().currentBalance)
        {
            CurrentWinnings.text = "Balance to low, try again when you have more money";
        }
        else
        {
            playButton.enabled = true;
        }

        //Update the current denomination text
        CurrentDenomination.text = string.Format("Current Denomination {0:C}", 
            denominations[SceneManger.GetComponent<SetUp>().index]);
    }
}
