///////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: To set up the scene 
//05/09/2022
//////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUp : MonoBehaviour
{
    //get the text variables
    [SerializeField]
    TextMeshProUGUI CurrentBalace, CurrentDemomination, LastGameWinnings;

    //set up some values to begin with
    public float amount;
    public float[] demonination;
    public float lastGamesWinnings;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        //setup the text
        amount = 10.00f;
        CurrentBalace.text = CurrentBalace.text + " $" + amount;

        demonination = new float[] { 0.25f, 0.50f, 1.00f, 5.00f};
        index = 1;
        CurrentDemomination.text = CurrentDemomination.text + " $" + demonination[index];

        lastGamesWinnings = 0.00f;
        LastGameWinnings.text = LastGameWinnings.text + " $" + lastGamesWinnings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
