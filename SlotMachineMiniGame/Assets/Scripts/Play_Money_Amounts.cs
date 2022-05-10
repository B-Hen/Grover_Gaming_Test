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

        PlayButton.enabled = false;
        IncreaseDenominationButton.enabled = false;
        DecreaseDenominationButton.enabled = false;
    }
}
