using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    private bool isFaded = false;

    public float duration = .4f;
    public Texture2D pointer; // normal pointer cursor

    public void Fade(bool alreadyFaded)
    {
        CanvasGroup canvasGrp = GetComponent<CanvasGroup>();

        //toggle end value based on faded state
        StartCoroutine(DoFade(canvasGrp, canvasGrp.alpha, canvasGrp.alpha == 0f ? 1 : 0));

        //Toggle the faded state
        isFaded = !isFaded;
       if(isFaded)
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
            if (end == 0 && canvasGrp.gameObject.name == "RecyclingInventory")
            {
                Cursor.SetCursor(pointer, new Vector2(16,16), CursorMode.Auto);
            } 
            yield return null;
        }
        
    }
}
