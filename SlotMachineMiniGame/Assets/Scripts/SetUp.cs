///////////////////////////////////////////////
//Name: Breanna Henriquez
//Purpose: To set up the scene 
//05/09/2022
//////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetUp : MonoBehaviour
{
    //get the text variables
    [SerializeField]
    TextMeshProUGUI CurrentBalace, CurrentDemomination, LastGameWinnings;

    [SerializeField]
    AudioSource exitSound;

    //set up some values to begin with
    public float currentBalance;
    public float[] demonination;
    public float lastGamesWinnings;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        //setup the text
        currentBalance = 10.00f;
        CurrentBalace.text = CurrentBalace.text + string.Format(" {0:C}", currentBalance);

        demonination = new float[] { 0.25f, 0.50f, 1.00f, 5.00f};
        index = 1;
        CurrentDemomination.text = CurrentDemomination.text + string.Format(" {0:C}", demonination[index]);

        lastGamesWinnings = 0.00f;
        LastGameWinnings.text = LastGameWinnings.text + string.Format(" {0:C}", lastGamesWinnings);
    }

    private void Update()
    {
        //Check to see if user has pressed the escape key
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(PlayExitSoung());
        }
    }

    //method to play exit sound before exit
    IEnumerator PlayExitSoung()
    {
        exitSound.Play();
        yield return new WaitWhile(() => exitSound.isPlaying);

        //after sound have finished exit the game
        Application.Quit();
    }

}
