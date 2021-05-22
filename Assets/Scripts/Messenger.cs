using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messenger : MonoBehaviour
{
   
    public enum MessageType
    {
        Success,
        Info,
        Failure,
    }

    public MessageType messageType;
    public GameObject successPanel;
    public GameObject infoPanel;
    public GameObject failurePanel;

    public void SetMessage(MessageType messageType)
    {
        if(messageType == MessageType.Success)
        {
            successPanel.GetComponent<CanvasGroup>().alpha = 1;

        }
        else if(messageType == MessageType.Info)
        {
             infoPanel.GetComponent<CanvasGroup>().alpha = 1;
        }
        else if(messageType == MessageType.Failure)
        {
             failurePanel.GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}
