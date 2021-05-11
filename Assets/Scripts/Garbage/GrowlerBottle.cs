using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerBottle : MonoBehaviour
{
    private string productType;

    public float mass;
    public int rarityLevel;
    public int skillRequirement;
    public bool hasAdditionalResources;

    void Start()
    {
        productType = "glass";
        mass = .75f;
        rarityLevel = 1;
        skillRequirement = 2;
        hasAdditionalResources = false;

        if (hasAdditionalResources)
        {
            LoadAdditionalResources();
        }
    }

    public float GetMass()
    {
        return mass;
    }

    public int GetRarityLevel()
    {
        return rarityLevel;
    }

    public int GetSkillRequirement()
    {
        return skillRequirement;
    }

    public bool GetHasAdditionalResources()
    {
        return hasAdditionalResources;
    }

    private void LoadAdditionalResources()
    {
        return;
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {           
            // check available inventory  space against mass
            bool canHold = RecyclingInventory.HaveAvailableCapacity(mass);
            //if there is enough room, add it
            if(canHold)
            {
                //play sound for item added or item not added
                float totalGlass = RecyclingInventory.GetGlassInventory();
                float newTotal = totalGlass + mass;
                RecyclingInventory.SetGlassInventory(newTotal);
                RecyclingInventory.AdjustAvailableCapacity(mass);
            }
        }
    }
}

// Aluminum Can: Metal Products : Garbage
// mass: .1 kg;
// rarityLevel: common;
// retrievalSkillRequirement: 1;
// hasAdditionalResources: false;
// additionalResourcesList: null;
// additionalResourceType: null;
// additionalResourceRarityLevel: null;
// additionalResourceMass: null;
// additional ResourceSkillRequirement: null;