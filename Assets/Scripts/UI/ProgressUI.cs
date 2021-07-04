using System.Collections.Generic;
using UnityEngine;

public class ProgressUI : MonoBehaviour
{
    public GameObject personalWealthBar;
    public GameObject pollutionBar;
    public GameObject publicOpinionBar;
    public GameObject wasteBar;

    private float counter = 2.5f;
    private int progressInt;

    void Start()
    {
        personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        wasteBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
    }

    void Update()
    {
        if(counter <= 0f)
        {
            //call to todo update opinion
            RecyclingInventory.UpdateOpinion();

            List<float> progressList = RecyclingInventory.GetProgressData();

            float wealth = progressList[0];
            float pollution = progressList[1];
            float opinion = progressList[2];
            float waste =  progressList[3];
            
            personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(wealth, 230));
            pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(pollution, 230));
            wasteBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(waste, 230));
            publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(115 + opinion, 230));

            progressInt += 1;

            if(progressInt >= 230) 
            {
                progressInt = 0;
            }

            // personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(progressInt*1.25f, 230));
            // pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, .5f * progressInt);
            // publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 165-progressInt);


        }

        counter -= Time.deltaTime; 
    }
}
