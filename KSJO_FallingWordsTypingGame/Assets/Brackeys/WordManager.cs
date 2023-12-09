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

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;

    // Modification
    // Creating a reference to the ImageSearchAPI script
    // in order to use methods
    public ImageSearchAPI searchAPI;

    private bool hasActiveWord;
    private Word activeWord;

    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            // Modification
            // Using the FindAnImage IEnumerator to search for an image
            // using the current activeWord (The search will begin as soon
            // as a letter of a word is typed)
            StartCoroutine(searchAPI.FindAnImage(activeWord.word));
            if (activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}