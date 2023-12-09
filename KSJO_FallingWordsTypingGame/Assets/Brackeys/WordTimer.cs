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

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}