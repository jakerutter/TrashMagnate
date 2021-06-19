﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressUI : MonoBehaviour
{
    public GameObject personalWealthBar;
    public GameObject pollutionBar;
    public GameObject publicOpinionBar;

    private float counter = 2.5f;
    //private int progressInt;

    void Start()
    {
        personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
        publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 0);
    }

    void Update()
    {
        if(counter <= 0f)
        {
            List<float> progressList = RecyclingInventory.GetProgressData();

            float wealth = progressList[0];
            float pollution = progressList[1];
            float opinion = progressList[2];
            
            personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(progressInt*1.25f, 230));
            pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, .5f * progressInt);
            publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 165-progressInt);

            // progressInt += 1;

            // if(progressInt >= 230) 
            // {
            //     progressInt = 0;
            // }

            // personalWealthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, Mathf.Min(progressInt*1.25f, 230));
            // pollutionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, .5f * progressInt);
            // publicOpinionBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 165-progressInt);


        }

        counter -= Time.deltaTime; 
    }
}
