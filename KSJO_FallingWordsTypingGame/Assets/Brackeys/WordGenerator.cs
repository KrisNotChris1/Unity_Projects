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

public class WordGenerator : MonoBehaviour
{
    // Modification
    // Creating an instance for access to StartCoroutine later
    private static WordGenerator instance;

    // Modification
    // Changed from an array to a list for convenience
    // Hard-coded words kept for now
    private static List<string> wordList = new List<string>{   "sidewalk", "robin", "three", "protect", "periodic",
                                    "somber", "majestic", "jump", "pretty", "wound", "jazzy",
                                    "memory", "join", "crack", "grade", "boot", "cloudy", "sick",
                                    "mug", "hot", "tart", "dangerous", "mother", "rustic", "economic",
                                    "weird", "cut", "parallel", "wood", "encouraging", "interrupt",
                                    "guide", "long", "chief", "mom", "signal", "rely", "abortive",
                                    "hair", "representative", "earth", "grate", "proud", "feel",
                                    "hilarious", "addition", "silent", "play", "floor", "numerous",
                                    "friend", "pizzas", "building", "organic", "past", "mute", "unusual",
                                    "mellow", "analyze", "crate", "homely", "protest", "painstaking",
                                    "society", "head", "female", "eager", "heap", "dramatic", "present",
                                    "sin", "box", "pies", "awesome", "root", "available", "sleet", "wax",
                                    "boring", "smash", "anger", "tasty", "spare", "tray", "daffy", "scarce",
                                    "account", "spot", "thought", "distinct", "nimble", "practice", "cream",
                                    "ablaze", "thoughtless", "love", "verdict", "giant"    };

    // Modification
    // Making sure the instance is set upon game start
    private void Awake()
    {
        // Modification
        instance = this;
    }

    public static string GetRandomWord()
    {
        // Modification
        // Giving an IEnumerator the value of the ProduceAWord IEnumerator
        // for convenience
        IEnumerator coroutine = RandomWordAPI.ProduceAWord();
        // Modification
        // Using the instance to StartCoroutine and call the ProduceAWord
        // IEnumerator that was placed within the coroutine IEnumerator
        instance.StartCoroutine(coroutine);
        // Modification
        // Once the ProduceAWord IEnumerator is done the string
        // cleanedWord, that gets a new value at the end of the IEnumerator,
        // gets added to the wordList as a choose-able word
        wordList.Add(RandomWordAPI.cleanedWord);
        int randomIndex = Random.Range(0, wordList.Count);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}