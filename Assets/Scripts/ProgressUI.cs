using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressUI : MonoBehaviour
{
    public GameObject personalWealthBar;
    public GameObject pollutionBar;
    public GameObject publicOpinionBar;

    private float counter = .5f;
    private int progressInt;

    void Start()
    {
        personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 165);
    }

    void Update()
    {
        if(counter <= 0f)
        {

            progressInt += 1;

            if(progressInt >= 230) {
                progressInt = 0;
            }
            personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(progressInt*1.5f, 230));
            pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, progressInt);
            publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 165-progressInt);


        }

        counter -= Time.deltaTime; 
    }
}
