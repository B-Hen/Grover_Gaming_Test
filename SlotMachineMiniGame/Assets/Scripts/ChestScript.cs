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
        //change the color of the object and disable it for the round
        objectRenderer.material.SetColor("_Color", Color.gray);
        objectCollider.enabled = false;

        if(winnings.Count == 0)
        {
            GameObject.Find("ChestWinningText").GetComponent<TextMeshProUGUI>().text = "POOPER";
        }
        else
        {
            //make text reflect the current winnings
            GameObject.Find("ChestWinningText").GetComponent<TextMeshProUGUI>().text = "Current Winnings: $" +
                winnings[0];

            //remove the amount from the list
            winnings.RemoveAt(0);
        }
    }
}
