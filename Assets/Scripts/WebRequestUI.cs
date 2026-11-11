using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class WebRequestUI : MonoBehaviour
{
    [SerializeField]private TMP_Text serverURL;
    [SerializeField]private TMP_Text message;
    [SerializeField]private TMP_Text returnValue;
    
    public void SendGetMessage()
    {
        string serverUrl = serverURL.text;
        string message = this.message.text;

        serverUrl = serverUrl.Remove(serverUrl.Length-1);
        message = message.Remove(message.Length-1);

        StartCoroutine(RestCommunication.SendGetRequest(serverUrl,message, UpdateReturnValueText));
    }

    public void UpdateReturnValueText(string text)
    {
        returnValue.text = text;
    }
}
