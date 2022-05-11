///////////////////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: to give the chest properties and check when they have been clicked
//Date: 05/09/2022
///////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestScript : MonoBehaviour
{
    //variables
    private float moneyAmount;
    private Renderer objectRenderer;

    //get the box collider
    [SerializeField]
    BoxCollider2D objectCollider;

    //orginial color
    private Color ogColor;

    //get the winning list
    List<float> winnings;

    //get the text
    private TextMeshProUGUI CurrentWinnings;

    [SerializeField]
    Animator anim;

    [SerializeField]
    AudioSource soundEffect, pooperEffect;

    //property
    public float MoneyAmount
    {
        get { return moneyAmount; }
        set { moneyAmount = value; }
    }

    public Color OGColor
    {
        get { return ogColor; }
    }

    private void Start()
    {
        //get the object renderer
        objectRenderer = this.GetComponent<Renderer>();
        ogColor = objectRenderer.material.GetColor("_Color");

        //change the color of the object and disable it for the round
        objectRenderer.material.SetColor("_Color", Color.gray);
        objectCollider.enabled = false;

        //get the winnings
        winnings = GameObject.Find("PlayLogicManager").GetComponent<Play_Money_Amounts>().winnings;
    }

    //check to see if the chest has been clicke
    public void OnMouseDown()
    {
        anim.SetBool("Spin", true);

        //change the color of the object and disable it for the round
        objectRenderer.material.SetColor("_Color", Color.gray);
        objectCollider.enabled = false;

        if(winnings.Count == 0)
        {
            pooperEffect.Play();
            anim.SetBool("OpenAir", true);
            //update the current balance
            GameObject.Find("SceneManager").GetComponent<SetUp>().currentBalance +=
                GameObject.Find("SceneManager").GetComponent<SetUp>().lastGamesWinnings;

            GameObject.Find("CurrentBalanceText").GetComponent<TextMeshProUGUI>().text =
                string.Format("Current Balance: {0:C}",
                GameObject.Find("SceneManager").GetComponent<SetUp>().currentBalance);

            GameObject.Find("ChestWinningText").GetComponent<TextMeshProUGUI>().text = "Hit POOPER";
            GameObject.Find("PlayLogicManager").GetComponent<Play_Money_Amounts>().Reset();
        }
        else
        {
            soundEffect.Play();
            anim.SetBool("OpenMoney", true);
            //make text reflect the current winnings
            GameObject.Find("ChestWinningText").GetComponent<TextMeshProUGUI>().text = "Current Winnings: " + string.Format("{0:C}"
                , winnings[0]);

            //add the total to the last game winnings and update the text
            GameObject.Find("SceneManager").GetComponent<SetUp>().lastGamesWinnings += winnings[0];
            GameObject.Find("LastGameWinningsText").GetComponent<TextMeshProUGUI>().text =
                string.Format("Last Game Winnings: {0:C}",
                GameObject.Find("SceneManager").GetComponent<SetUp>().lastGamesWinnings);

            //remove the amount from the list
            winnings.RemoveAt(0);
        }
    }
}
