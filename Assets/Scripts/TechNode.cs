using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        unlockedTechNodes = RecyclingInventory.GetUnlockedTechNodes();
    }

    public void PurchaseTechUpgrade()
    {
       Debug.Log("purchase attempt ID " + id.ToString());

       if(!CheckUnlocked())
       {
           Debug.Log("This upgrade is locked.");
           return;
       }

       if(!CanAfford())
       {
           Debug.Log("Can not afford");
           return;
       }

       Debug.Log("Price is " + cost.ToString());

        // send negative cost to subtract recyclingTechPoints
       RecyclingInventory.AddRecyclingTechPoints(-cost);

       RecyclingInventory.AddUnlockedTechNode(unlocks);

       purchased = true;

       UpdateNodeUI();
    }

    private bool CheckUnlocked()
    {
        List<int> unlockedTechNodes = RecyclingInventory.GetUnlockedTechNodes();

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
    }

}
