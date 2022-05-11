//////////////////////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: Take care of all the game logic
//Date: 05/09/2022
/////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    float denimation;
    int index;

    //varable to hold the winning amount
    public List<float> winnings;
    private float TotalWinAmount = 0.00f;
    int multipiler;

    //variable to reset the Current winnings text
    [SerializeField]
    TextMeshProUGUI CurrentWinnings, CurrentBalance;

    // Start is called before the first frame update
    public void PlayLogicSetUp()
    {
        //subtract the denomination everytime the play button is hit
        SceneManager.GetComponent<SetUp>().currentBalance -= 
            SceneManager.GetComponent<SetUp>().demonination[SceneManager.GetComponent<SetUp>().index];

        //if current balance is less than 0 make it equal to zero, can't have negaitive money
        if(SceneManager.GetComponent<SetUp>().currentBalance < 0) { SceneManager.GetComponent<SetUp>().currentBalance = 0; }

        //reset the last game winning text
        GameObject.Find("SceneManager").GetComponent<SetUp>().lastGamesWinnings = 0;
        GameObject.Find("LastGameWinningsText").GetComponent<TextMeshProUGUI>().text =
                string.Format("Last Game Winnings: {0:C}", 0);

        //update the current balance text
        CurrentBalance.text = string.Format("Current Balance: {0:C}", SceneManager.GetComponent<SetUp>().currentBalance);

        //enable all the chest
        //make it so you can't click any of the chest and they are grayed out
        for (int i = 0; i < chest.Length; i++)
        {
            chest[i].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            chest[i].GetComponent<BoxCollider2D>().enabled = true;
            chest[i].GetComponent<Animator>().Rebind();
            chest[i].GetComponent<Animator>().Update(0f);
        }

        //diable all the buttons
        PlayButton.enabled = false;
        IncreaseDenominationButton.enabled = false;
        DecreaseDenominationButton.enabled = false;

        //run the winning amounts method
        DetermineWinnings();

        //reset the text each time
        CurrentWinnings.text = "";
    }

    //method to determine money amount
    public void DetermineWinnings()
    {
        //get the denimations for this round
        denimations = SceneManager.GetComponent<SetUp>().demonination;
        index = SceneManager.GetComponent<SetUp>().index;
        denimation = denimations[index];

        int percent = Random.Range(1, 100);

        //check the 30%
        if(percent >= 51 && percent <= 80)
        {
            multipiler = Random.Range(1, 10);
            TotalWinAmount = multipiler * denimation;
            SplitWinnings(TotalWinAmount);
        }
        //check the 15%
        else if(percent >= 81 && percent <= 95)
        {
            int[] amounts = new int[] { 12, 16, 24, 32, 48, 64 };
            multipiler = Random.Range(1, 6);
            TotalWinAmount = amounts[multipiler] * denimation;
            SplitWinnings(TotalWinAmount);
        }
        //check the 5%
        else if(percent >= 96 && percent <= 100)
        {
            int[] amounts = new int[] {100,200,300,400,500};
            multipiler = Random.Range(1, 5);
            TotalWinAmount = amounts[multipiler] * denimation;
            SplitWinnings(TotalWinAmount);
        }
    }

    //method to split the winnings
    public void SplitWinnings(float TotalWinningAmount)
    {
        //variable to get final amount need to get total split
        float amount = 0;
        float originalTotal = TotalWinningAmount;

        //loop while the amount is greater than 0
        while (TotalWinningAmount > 0)
        {
            //check to see if the amount need can be divided nicely into any of these splits
            //if so divide by that amount than add that to the amount variable
            //then add it to the winning list of split numbers
            if (TotalWinningAmount % 200 == 0)
            {
                TotalWinningAmount /= 200;
                amount += TotalWinningAmount;
                winnings.Add(TotalWinningAmount);
            }
            else if (TotalWinningAmount % 50 == 0)
            {
                TotalWinningAmount /= 50;
                amount += TotalWinningAmount;
                winnings.Add(TotalWinningAmount);
            }
            else if(TotalWinningAmount % 10 == 0)
            {
                TotalWinningAmount /= 10;
                amount += TotalWinningAmount;
                winnings.Add(TotalWinningAmount);
            }
            else if(TotalWinningAmount % 5 == 0)
            {
                TotalWinningAmount /= 5;
                amount += TotalWinningAmount;
                winnings.Add(TotalWinningAmount);
            }
            else if(TotalWinningAmount % 2 == 0)
            {
                TotalWinningAmount /= 2;
                amount += TotalWinningAmount;
                winnings.Add(TotalWinningAmount);
            }
            //final condition if the number can no longer be split
            //check to see if it id divisble by itself of 0.5
            //if so get the original amount - the amount to see how much is left of the total
            //then add that to the list
            else if(TotalWinningAmount % 1 == 0 || TotalWinningAmount % 0.5 == 0)
            {
                winnings.Add(originalTotal - amount);
                TotalWinningAmount = 0;
            }

        }
    }

    //method to reset the game when a pooper is found
    public void Reset()
    {
        //loop through the list of chest and unenable them
        for(int i = 0; i < chest.Length; i++)
        {
            chest[i].GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            chest[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        //enable all the buttons again
        IncreaseDenominationButton.enabled = true;
        DecreaseDenominationButton.enabled = true;
        CanPlay();
        
    }

    //method for check
    public void CanPlay()
    {
        //check to see if the play button can be enabled again
        if (SceneManager.GetComponent<SetUp>().demonination[SceneManager.GetComponent<SetUp>().index] >
            SceneManager.GetComponent<SetUp>().currentBalance && CurrentWinnings.text != "")
        {
            CurrentWinnings.text = "Hit POOPER and Balance to low, try again with different denimation or when you have more money";
        }
        else
        {
            CurrentWinnings.text = "Hit POOPER, Press the play button to continue";
            PlayButton.enabled = true;
        }
    }
}
