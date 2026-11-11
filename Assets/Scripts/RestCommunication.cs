using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestCommunication : MonoBehaviour
{

    public static IEnumerator SendGetRequest(string url, string message,
    System.Action<string> action)
    {
        UnityWebRequest www = UnityWebRequest.Get(url+"?message="+message);

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            action(www.downloadHandler.text);
        }
    }

    
    public static IEnumerator SendPostRequest(string url, string json,
    System.Action<string> action)
    {
        UnityWebRequest www = UnityWebRequest.Post(url, json, "application/json");

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            action(www.downloadHandler.text);
        }
    }
}
