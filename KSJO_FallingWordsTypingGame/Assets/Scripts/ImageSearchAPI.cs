using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class ImageSearchAPI : MonoBehaviour
{
    // The base URL that will be used to find images of the
    // various words that are put into the game
    public static string url = "https://pixabay.com/api/?key=38508555-fc9321bb80d9857f13634f247";

    // Reference to the Raw Image that will be used as the background
    public RawImage background;

    // Use the API to find an image of the desired word
    public IEnumerator FindAnImage(string word)
    {
        // Modified version of the API url
        // needed to properly do a search query
        string imageURL = url + "&q=" + word;

        // A Get request will be sent and the IEnumerator will not
        // proceed unity the request is sent
        UnityWebRequest imageRequest = UnityWebRequest.Get(imageURL);
        yield return imageRequest.SendWebRequest();

        // If the request fails, display the error within the console
        if (imageRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Image search error: " + imageRequest.error);
        }
        // If the request succeeds...
        else
        {
            // Take all the data from the call and place the URLs within
            // a list
            string jsonResponse = imageRequest.downloadHandler.text;
            List<string> imageUrls = ExtractImageUrls(jsonResponse);

            // While the URL count is more than zero...
            if (imageUrls.Count > 0)
            {
                // download the image of the first URL within the list
                StartCoroutine(DownloadImage(imageUrls[0]));
            }
            // Or display the error within the console
            else
            {
                Debug.Log("No image URLs found in the API response.");
            }
        }
    }

    // This helps to grab all the various URLs that get produced from the
    // API call
    public static List<string> ExtractImageUrls(string jsonResponse)
    {
        List<string> imageUrls = new List<string>();
        // This string will contain the types of URLs that we want to
        // take from the data
        string pattern = @"https://pixabay\.com/get/[\w\d]+\.jpg";
        // Once the correct URLs are found they're place within imageUels list
        // for use
        MatchCollection matches = Regex.Matches(jsonResponse, pattern);
        foreach (Match match in matches)
        {
            imageUrls.Add(match.Value);
        }

        return imageUrls;
    }

    // Once called the image from the first URL within the imageUrls
    // list will be downloaded and displayed on the Raw Image
    public IEnumerator DownloadImage(string imageUrl)
    {
        // The request is getting the image that the URL will produce
        UnityWebRequest imageRequest = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return imageRequest.SendWebRequest();
        // If there's no image, the error is displayed within the console
        if (imageRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Image download error: " + imageRequest.error);
        }
        // If there's an image, the Raw Image's texture (what determines its
        // look) gets turned into the newly downloaded image
        else
        {
            background.texture = ((DownloadHandlerTexture)imageRequest.downloadHandler).texture;
        }
    }
}