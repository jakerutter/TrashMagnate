using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TechNode : MonoBehaviour
{
    //cost of tech upgrade
    [SerializeField] private int cost;
    //is this available to be purchased
    [SerializeField] private bool unlocked;
    //the description of the tech node
    [SerializeField] private string description;
    //the ID
    [SerializeField] private int id;
    //the ID of the node that unlocks this tech node
    [SerializeField] private int unlockedBy;
    //the tech node ID that this unlocks when purchased
    [SerializeField] private int unlocks;
    //has this tech node been purchased
    [SerializeField] private bool purchased = false;

    private int RTPoints;
    private List<int> unlockedTechNodes;
    private Color green = new Color(0f, 255f, 34f, 255f);

    public void PurchaseTechUpgrade()
    {
        if(purchased)
        {
            return;
        }

        AudioManager _audio;
        _audio = FindObjectOfType<AudioManager>();

       //Debug.Log("purchase attempt ID " + id.ToString());

       if(!CheckUnlocked())
       {
           Debug.Log("This upgrade is locked.");
           //play reject sound
           _audio.Play("PurchaseRejection");
           return;
       }

       if(!CanAfford())
       {
           Debug.Log("Can not afford");
           _audio.Play("PurchaseRejection");
           return;
       }

       //Debug.Log("Price is " + cost.ToString());

        // send negative cost to subtract recyclingTechPoints
       RecyclingInventory.AddRecyclingTechPoints(-cost);

       RecyclingInventory.AddUnlockedTechNodes(unlocks);

       purchased = true;
       
       //play tech tree upgrade sound (levelUp)
       _audio.Play("TechTreeUpgrade");

       //show particle effect
       ParticleSystem ps = gameObject.transform.Find("Effect").GetComponent<ParticleSystem>();
       ps.Play();

       UpdateNodeUI();
       UpdateArrowNode();
       UpdateRTPointDisplay();
    }

    private bool CheckUnlocked()
    {
        unlockedTechNodes = RecyclingInventory.GetUnlockedTechNodes();
        
        if(unlockedTechNodes == null)
        {
            unlockedTechNodes = new List<int>();
        }

        for(int i = 0; i < unlockedTechNodes.Count; i++)
        {
            if(unlockedTechNodes[i] == id)
            {
                return true;
            }
        }

        return false;
    }

    private bool CanAfford()
    {
        RTPoints = RecyclingInventory.GetRecyclingTechPoints();

        if(RTPoints >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateNodeUI()
    {
        //update tech node to indicate it has been purchased
        gameObject.GetComponent<Outline>().enabled = true;
    }

    private void UpdateArrowNode()
    {
        Transform nextChild = NextChild();
        Image img = nextChild.gameObject.GetComponent<Image>();
        img.color = green;
    }

    public void UpdateRTPointDisplay()
    {
        //Display current RT point total
        GameObject RecyclingTechPoints = GameObject.FindGameObjectWithTag("RTPointDisplay");
        RecyclingTechPoints.GetComponent<TextMeshProUGUI>().SetText(RecyclingInventory.GetRecyclingTechPoints().ToString());
    }

     private Transform NextChild()
     {
         // Check where we are
         int thisIndex = this.transform.GetSiblingIndex();
 
         // We have a few cases to rule out
         if ( this.transform.parent == null )
             return null;
         if ( this.transform.parent.childCount <= thisIndex + 1 )
             return null;
 
         // Then return whatever was next, now that we're sure it's there
         return this.transform.parent.GetChild(thisIndex + 1);
     }

}
