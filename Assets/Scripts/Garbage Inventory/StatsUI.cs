using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public List<GameObject> generalStats;
    public List<GameObject> recyclingStats;

   public void ShowStats()
   {
       foreach (GameObject item in generalStats)
       {
           //time played
           if(item.name == "GS1")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("1 hours");
           }
           else if (item.name == "GS2")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("2 hours");
           }
            else if (item.name == "GS3")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("3 hours");
           }
            else if (item.name == "GS4")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("4 hours");
           }
            else if (item.name == "GS5")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("5 hours");
           }
            else if (item.name == "GS6")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("6 hours");
           }
       }

        foreach (GameObject item in recyclingStats)
       {
           //time played
           if(item.name == "RS1")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("1 item");
           }
           else if (item.name == "RS2")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("2 item");
           }
            else if (item.name == "RS3")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("3 item");
           }
            else if (item.name == "RS4")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("4 item");
           }
            else if (item.name == "RS5")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("5 item");
           }
            else if (item.name == "RS6")
           {
               item.GetComponent<TextMeshProUGUI>().SetText("6 item");
           }
       }

    //     foreach (GameObject item in launchStats)
    //    {
    //        //time played
    //        if(item.name == "LS1")
    //        {
    //            item.GetComponent<TextMeshProUGUI>().SetText("1 launch");
    //        }
    //        else if (item.name == "LS2")
    //        {
    //            item.GetComponent<TextMeshProUGUI>().SetText("2 launch");
    //        }
    //         else if (item.name == "LS3")
    //        {
    //            item.GetComponent<TextMeshProUGUI>().SetText("3 launch");
    //        }
    //         else if (item.name == "LS4")
    //        {
    //            item.GetComponent<TextMeshProUGUI>().SetText("4 launch");
    //        }
    //         else if (item.name == "LS5")
    //        {
    //            item.GetComponent<TextMeshProUGUI>().SetText("5 launch");
    //        }
    //         else if (item.name == "LS6")
    //        {
    //            item.GetComponent<TextMeshProUGUI>().SetText("6 launch");
    //        }
    //    }
   }
}
