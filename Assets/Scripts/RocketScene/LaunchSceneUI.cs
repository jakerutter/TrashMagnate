using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaunchSceneUI : MonoBehaviour
{
    public List<GameObject> altitudeIndicators;

    public GameObject rocket;
    private float altitude;

    // Start is called before the first frame update
    void Start()
    {
        altitude = rocket.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        altitude = rocket.transform.position.y;
        
        for (int i =0; i<altitudeIndicators.Count; i++)
        {
            TextMeshProUGUI text = altitudeIndicators[i].GetComponent<TextMeshProUGUI>();
            
            if (i==0)
            { 
                text.SetText(altitude.ToString("0"));
            }
            else if (i == 1)
            {
                text.SetText((altitude + 50).ToString("0"));
            }
            else if (i == 2)
            {
                text.SetText((altitude + 100).ToString("0"));
            }
            else if (i == 3)
            {
                text.SetText((altitude + 150).ToString("0"));  
            }
            else if (i == 4)
            {
                text.SetText((altitude + 200).ToString("0"));
            }
            else if (i == 5)
            {
                text.SetText((altitude - 50).ToString("0"));
            }
            else if (i == 6)
            {
                text.SetText((altitude - 100).ToString("0"));
            }
             else if (i == 7)
            {
                text.SetText((altitude - 150).ToString("0"));
            }
            else if (i == 8)
            {
                text.SetText((altitude - 200).ToString("0"));
            }
        }
    }
}
