using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlasticJug : MonoBehaviour
{
    private string productType;

    public float mass;
    public int rarityLevel;
    public int skillRequirement;
    public bool hasAdditionalResources;

    void Start()
    {
        productType = "plastic";
        mass = 1.5f;
        rarityLevel = 1;
        skillRequirement = 1;
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
            SpriteRenderer thisSprite = gameObject.GetComponent<SpriteRenderer>();   
            Garbage garbage = gameObject.GetComponent<Garbage>();
            garbage.AddItemToInventory(mass, productType, thisSprite.sprite);
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