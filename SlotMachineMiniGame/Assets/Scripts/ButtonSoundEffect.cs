///////////////////////////////////////////////
//Name:Breanna Henriquez
//Purpose: To play sound effects for buttons
//Date: 5/11/2022
///////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundEffect : MonoBehaviour
{
    //variable to get sound effects
    AudioSource soundEffect;

    public void Start()
    {
        soundEffect = GameObject.Find("SoundEffectForButtons").GetComponent<AudioSource>();
    }

    //helper method to play sound effect anytime a button is pressed
    public void SoundForButtons()
    {
        soundEffect.Play();
    }
}
