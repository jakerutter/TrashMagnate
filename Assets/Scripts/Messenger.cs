using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messenger : MonoBehaviour
{
   
    public enum MessageType
    {
        Success,
        Info,
        Failure,
    }

    public List<GameObject> messagePanels;
    public GameObject successMessagePrefab;
    public GameObject infoMessagePrefab;
    public GameObject failureMessagePrefab;

    private float duration = 3f;
    private bool messageShown = false;

    public void SetMessage(MessageType messageType, string message)
    {
        messageShown = false;
        foreach(GameObject panel in messagePanels)
        {
            if(panel.GetComponent<CanvasGroup>().alpha > 0)
            {
                continue;
            }

            if(messageShown)
            {
                return;
            }

            //set panel alpha to 1
            CanvasGroup canva = panel.GetComponent<CanvasGroup>();
            canva.alpha = 1;

            if(messageType == MessageType.Success)
            {
                //instantiate prefab
                Instantiate(successMessagePrefab, panel.transform);

                //insert text
                Transform textObj = successMessagePrefab.transform.Find("SuccessText");
                textObj.GetComponent<TextMeshProUGUI>().SetText(message);
                //call FadeOut coRoutine 
                Debug.Log("calling fadeOut");
                StartCoroutine(FadeOut(canva, 1, 0));
                //set MessageShown to true
                messageShown = true;
            }
            else if(messageType == MessageType.Info)
            {

            }
            else if(messageType == MessageType.Failure)
            {

            }
        } 
    }

    private IEnumerator FadeOut(CanvasGroup canvasGrp, float start, float end)
    {
        Debug.Log("fading out " + canvasGrp.gameObject.name);
        float counter = 0f;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvasGrp.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }      
    }
}
