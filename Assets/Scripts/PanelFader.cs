using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    private bool mFaded = false;

    public float duration = .4f;

    public void Fade()
    {
        CanvasGroup canvasGrp = GetComponent<CanvasGroup>();

        //toggle end value based on faded state
        StartCoroutine(DoFade(canvasGrp, canvasGrp.alpha, mFaded ? 1: 0));
        //Toggle the faded state
        mFaded = !mFaded;
       if(mFaded)
       {
           canvasGrp.blocksRaycasts = false;
       } else 
       {
            canvasGrp.blocksRaycasts = true;
       }
    }

    public IEnumerator DoFade(CanvasGroup canvasGrp, float start, float end)
    {
        float counter = 0f;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvasGrp.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
        
    }
}
