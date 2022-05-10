///////////////////////////////////////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: to give the chest properties and check when they have been clicked
//Date: 05/09/2022
///////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    //variables
    private float moneyAmount;
    private Renderer objectRenderer;

    [SerializeField]
    BoxCollider2D objectCollider;

    //orginial color
    private Color ogColor;

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
        Debug.Log(OGColor);

        //change the color of the object and disable it for the round
        objectRenderer.material.SetColor("_Color", Color.gray);
        objectCollider.enabled = false;
    }

    //check to see if the chest has been clicke
    public void OnMouseDown()
    {
        //change the color of the object and disable it for the round
        objectRenderer.material.SetColor("_Color", Color.gray);
        objectCollider.enabled = false;
    }
}
