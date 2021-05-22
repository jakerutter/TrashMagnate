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
    private List<GameObject> spawnedPanels;

    void Start()
    {
        spawnedPanels = new List<GameObject>();
    }

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
                GameObject thisPanel = Instantiate(successMessagePrefab, panel.transform);
                spawnedPanels.Add(thisPanel);

                //insert text
                Transform textObj = successMessagePrefab.transform.Find("SuccessText");
                textObj.GetComponent<TextMeshProUGUI>().SetText(message);
                
                //call FadeOut coRoutine 
                StartCoroutine(FadeOut(canva, 1, 0));
                //set MessageShown to true
                messageShown = true;
            }
            else if(messageType == MessageType.Info)
            {
                 //instantiate prefab
                GameObject thisPanel = Instantiate(infoMessagePrefab, panel.transform);
                spawnedPanels.Add(thisPanel);

                //insert text
                Transform textObj = infoMessagePrefab.transform.Find("InfoText");
                textObj.GetComponent<TextMeshProUGUI>().SetText(message);
                
                //call FadeOut coRoutine 
                StartCoroutine(FadeOut(canva, 1, 0));
                //set MessageShown to true
                messageShown = true;
            }
            else if(messageType == MessageType.Failure)
            {
                 //instantiate prefab
                GameObject thisPanel = Instantiate(failureMessagePrefab, panel.transform);
                spawnedPanels.Add(thisPanel);

                //insert text
                Transform textObj = failureMessagePrefab.transform.Find("FailureText");
                textObj.GetComponent<TextMeshProUGUI>().SetText(message);
                
                //call FadeOut coRoutine 
                StartCoroutine(FadeOut(canva, 1, 0));
                //set MessageShown to true
                messageShown = true;
            }
        } 
    }

    private IEnumerator FadeOut(CanvasGroup canvasGrp, float start, float end)
    {
        // Debug.Log("fading out " + canvasGrp.gameObject.name);
        float counter = 0f;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvasGrp.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }

        for(int i = spawnedPanels.Count-1; i>spawnedPanels.Count-2; i--)
        {
            Destroy(spawnedPanels[i]);
        }      
    }
}
