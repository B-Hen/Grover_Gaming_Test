//////////////////////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: Take care of all the game logic
//Date: 05/09/2022
/////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play_Money_Amounts : MonoBehaviour
{
    //list of all the chest
    [SerializeField]
    GameObject[] chest;

    //get the buttons to disable
    [SerializeField]
    Button PlayButton, IncreaseDenominationButton, DecreaseDenominationButton;

    //get the denimations
    [SerializeField]
    GameObject SceneManager;
    float[] denimations;
    int index;

    //varable to hold the winning amount
    public List<float> winnings;
    private float TotalWinAmount = 0.00f;
    int multipiler;

    // Start is called before the first frame update
    public void PlayLogicSetUp()
    {
        //enable all the chest
        //make it so you can't click any of the chest and they are grayed out
        for (int i = 0; i < chest.Length; i++)
        {
            chest[i].GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            chest[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        //diable all the buttons
        PlayButton.enabled = false;
        IncreaseDenominationButton.enabled = false;
        DecreaseDenominationButton.enabled = false;

        //run the winning amounts method
        DetermineWinnings();
    }

    //method to determine money amount
    public void DetermineWinnings()
    {
        //get the denimations for this round
        denimations = SceneManager.GetComponent<SetUp>().demonination;
        index = SceneManager.GetComponent<SetUp>().index;
        float denimation = denimations[index];
        Debug.Log(index);
        Debug.Log(denimation);

        int percent = Random.Range(81, 100);

        //check the 30%
        if(percent >= 51 && percent <= 80)
        {
            multipiler = Random.Range(1, 10);
            TotalWinAmount = multipiler * denimation;
            Debug.Log(TotalWinAmount);
            SplitWinnings(TotalWinAmount, 10);
        }
        //check the 15%
        else if(percent >= 81 && percent <= 95)
        {
            int[] amounts = new int[] { 12, 16, 24, 32, 48, 64 };
            multipiler = Random.Range(1, 6);
            TotalWinAmount = amounts[multipiler] * denimation;
            Debug.Log(TotalWinAmount);
            SplitWinnings(TotalWinAmount, 50);
        }
        //check the 5%
        else
        {
            int[] amounts = new int[] {100,200,300,400,500};
            multipiler = Random.Range(1, 5);
            TotalWinAmount = amounts[multipiler] * denimation;
            Debug.Log(TotalWinAmount);
            SplitWinnings(TotalWinAmount, 400);
        }
    }

    //method to split the winnings
    public void SplitWinnings(float TotalWinningAmount, int SplitAmount)
    {
        int amount = 0;

        while (TotalWinningAmount != 0)
        {
            //first check if the amount can be split
            if (TotalWinningAmount - SplitAmount < 0)
            {
                winnings.Add(TotalWinningAmount);
                TotalWinningAmount = 0;
                break;
            }
        }


        for (int i = 0; i < winnings.Count; i++)
        {
            Debug.Log(winnings[i]);
        }
    }
}
