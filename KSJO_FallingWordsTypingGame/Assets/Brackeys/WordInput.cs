using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************
*    Title: Falling-Words-Typing-Game
*    Author: ATBrackeys
*    Date: Dec 8, 2017
*    Code version: <code version>
*    Availability: https://github.com/Brackeys/Falling-Words-Typing-Game/tree/master
*
***************************************************************************************/

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    // Update is called once per frame
    private void Update()
    {
        foreach (char letter in Input.inputString)
        {
            wordManager.TypeLetter(letter);
        }
    }
}