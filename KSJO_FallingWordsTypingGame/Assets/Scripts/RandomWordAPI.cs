using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class RandomWordAPI : MonoBehaviour
{
    // URL for the random word API that will be used to produce
    // new words for the project
    public static string randomWordURL = "https://random-word-api.vercel.app/api?words=1";

    // Strings that will be holding the results of the UnityWebRequest (API Calls)
    public static string fetchedWord;

    public static string cleanedWord;
    public static string pattern;
    public static string result;

    // An UnityWebRequest will be made to produce a random word
    // using the randomWordURL
    public static IEnumerator ProduceAWord()
    {
        // A Get request will be sent and the IEnumerator will not
        // proceed unity the request is sent
        UnityWebRequest www = UnityWebRequest.Get(randomWordURL);
        yield return www.SendWebRequest();

        // If the request fails, display the error within the console
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        // If the request succeeds...
        else
        {
            // Get the word that the API produced and clean it up for
            // proper use
            fetchedWord = www.downloadHandler.text;
            cleanedWord = RemoveSpecialCharacters(fetchedWord);

            Debug.Log("Fetched Word: " + fetchedWord);
            Debug.Log("Cleaned Word: " + cleanedWord);
        }
    }

    // Remove special characters that might of come along with the
    // word the API produces
    public static string RemoveSpecialCharacters(string input)
    {
        pattern = "[^a-zA-Z0-9]+";
        result = Regex.Replace(input, pattern, "");
        return result;
    }
}