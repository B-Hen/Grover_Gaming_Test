///////////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez 
//Purpose: Decrease or increas the denimation by pressing a button
//Date: 05/09/22
//////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Increase_Decrease_Denomination : MonoBehaviour
{
    //vairbale for the scene manager
    [SerializeField]
    GameObject SceneManger;

    //variable for the text on screen
    [SerializeField]
    TextMeshProUGUI CurrentDenomination;

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
        if(index == denominations.Length-1)
        {
            index = denominations.Length - 1;
        }
        //else increase the index
        else
        {
            index++;
        }

        //Update the current denomination text
        CurrentDenomination.text = "Current Denomination $" + denominations[index];
    }

    //method to decrease the denomination
    public void DecreaseDenomination()
    {
        //first check to see if the index is the last elemtent in the array
        if (index == 0)
        {
            index = 0;
        }
        //else increase the index
        else
        {
            index--;
        }

        //Update the current denomination text
        CurrentDenomination.text = "Current Denomination $" + denominations[index];
    }
}
