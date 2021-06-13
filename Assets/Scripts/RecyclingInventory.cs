﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class RecyclingInventory
{
    private static float PlasticInventory;
    private static float RubberInventory;
    private static float MetalInventory;
    private static float PaperInventory;
    private static float ElectronicInventory;
    private static float WoodInventory;
    private static float GlassInventory;
    private static float CarryingCapacity = 50f;
    private static float AvailableCapcity;
    private static float TotalInventoryMass;
    private static int RecyclingSkill = 0;
    private static int Currency;
    private static int RecyclingTechPoints = 1500;
    private static bool BasicRecyclerBuilt;
    private static bool ModernRecyclerBuilt;
    private static bool AdvancedRecyclerBuilt;
    private static bool BasicRecyclerPurchased;
    private static bool ModernRecyclerPurchased;
    private static bool AdvancedRecyclerPurchased;
    private static bool BasicRecyclerUnlocked = true;
    private static bool ModernRecyclerUnlocked;
    private static bool AdvancedRecyclerUnlocked;
    private static ManualRecyclingUpgrade[] ManualRecyclingUpgrades;
    private static RecyclingVehicle[] RecyclingVehicles;
    private static List<int> UnlockedTechNodes = new List<int>() {-1, 0, 15};

    public static float GetPlasticInventory()
    {
        return PlasticInventory;
    }

    public static void SetPlasticInventory(float inventory)
    {
        PlasticInventory = inventory;
        //Debug.Log("plastic inv should = " + inventory);
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("PlasticAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

    public static float GetRubberInventory()
    {
        return RubberInventory;
    }

    public static void SetRubberInventory(float inventory)
    {
        RubberInventory = inventory;
        //Debug.Log("rubber inv should = " + inventory);
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("RubberAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

    public static float GetMetalInventory()
    {
        return MetalInventory;
    }

    public static void SetMetalInventory(float inventory)
    {
        MetalInventory = inventory;
        //Debug.Log("metal inv should = " + inventory);
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("MetalAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

    public static float GetGlassInventory()
    {
        return GlassInventory;
    }

    public static void SetGlassInventory(float inventory)
    {
        //Debug.Log("glass inv should = " + inventory);
        GlassInventory = inventory;
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("GlassAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

    public static float GetPaperInventory()
    {
        return PaperInventory;
    }

    public static void SetPaperInventory(float inventory)
    {
        PaperInventory = inventory;
        //Debug.Log("paper inv should = " + inventory);
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("PaperAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

    public static float GetElectronicInventory()
    {
        return ElectronicInventory;
    }

    public static void SetElectronicInventory(float inventory)
    {
        ElectronicInventory = inventory;
        //Debug.Log("Electronic inv should = " + inventory);
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("ElectronicAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }
    
    public static float GetWoodInventory()
    {
        return WoodInventory;
    }

    public static void SetWoodInventory(float inventory)
    {
        WoodInventory = inventory;
        //Debug.Log("wood inv should = " + inventory);
        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("WoodAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

    public static int GetRecyclingSkill()
    {
        return RecyclingSkill;
    }

    public static void AddRecyclingSkill(int skill)
    {
        RecyclingSkill += skill;
        //send [success] message showing recycling skill increase
        Messenger messenger = GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>();
        messenger.SetMessage(Messenger.MessageType.Success, "Congrats! Recycling skill increased to " + RecyclingSkill.ToString() + ".");
        Debug.Log("Recycling skill == "+ RecyclingSkill);
    }

    public static int GetCurrency()
    {
        return Currency;
    }

    public static void SetCurrency(int currency)
    {
        Currency += currency;
    }

    public static int GetRecyclingTechPoints()
    {
        return RecyclingTechPoints;
    }

    public static void AddRecyclingTechPoints(int rtPoints)
    {
        RecyclingTechPoints += rtPoints;
    }

    public static ManualRecyclingUpgrade[] GetManualRecyclingUpgrades()
    {
        return ManualRecyclingUpgrades;
    }

    public static void SetManualRecyclingUpgrades(ManualRecyclingUpgrade[] upgrades)
    {
        ManualRecyclingUpgrades = upgrades;
    }

    public static RecyclingVehicle[] GetRecyclingVehicles()
    {
        return RecyclingVehicles;
    }

    public static void SetRecyclingVehicles(RecyclingVehicle[] vehicles)
    {
        RecyclingVehicles = vehicles;
    }

    public static float GetCarryingCapacity()
    {
        return CarryingCapacity;
    }

    public static void SetCarryingCapacity(float capacity)
    {
        CarryingCapacity += capacity;
    }

    public static float GetAvailableCapacity()
    {
        TotalInventoryMass = PlasticInventory + RubberInventory + PaperInventory + MetalInventory + GlassInventory + ElectronicInventory + WoodInventory;
        AvailableCapcity = CarryingCapacity - TotalInventoryMass;
        AvailableCapcity = Mathf.Max(AvailableCapcity, 0f);
        return AvailableCapcity;
    }

    public static bool HaveAvailableCapacity(float mass)
    {
        TotalInventoryMass = PlasticInventory + RubberInventory + PaperInventory + MetalInventory + GlassInventory + ElectronicInventory + WoodInventory;
        AvailableCapcity = CarryingCapacity - TotalInventoryMass;
        AvailableCapcity = Mathf.Max(AvailableCapcity, 0f);
        
        if(mass <= AvailableCapcity)
        {
            return true;
        }
        return false;
    }

    public static float GetTotalInventoryMass()
    {
        TotalInventoryMass = PlasticInventory + RubberInventory + PaperInventory + MetalInventory + GlassInventory + ElectronicInventory + WoodInventory;
        return TotalInventoryMass;
    }

    public static void AdjustAvailableCapacity(float mass)
    {
        float carryLimit = GetCarryingCapacity();
        float totalMass = GetTotalInventoryMass();
        AvailableCapcity -= mass;

        AvailableCapcity = Mathf.Max(AvailableCapcity, 0f);

        // GameObject cap = GameObject.FindGameObjectWithTag("GarbageCapacityText");
        // Text capText = cap.GetComponent<Text>();
        // capText.text = "Carrying Capacity\n "+totalMass+" kg / "+carryLimit+ " kg";  
    }

    public static void SetRecyclerBuilt(Recycler recycler)
    {
        if(recycler.recyclerType == Recycler.RecyclerType.BasicRecycler)
        {   
            BasicRecyclerBuilt = true;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.ModernRecycler)
        {
            ModernRecyclerBuilt= true;
        }
        else if(recycler.recyclerType == Recycler.RecyclerType.AdvancedRecycler)
        {
            AdvancedRecyclerBuilt = true;
        }
    }

  
    public static void SetRecyclerPurchased(Recycler recycler)
    {
        if(recycler.recyclerType == Recycler.RecyclerType.BasicRecycler)
        {   
            BasicRecyclerPurchased = true;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.ModernRecycler)
        {
            ModernRecyclerPurchased = true;
        }
        else if(recycler.recyclerType == Recycler.RecyclerType.AdvancedRecycler)
        {
            AdvancedRecyclerPurchased = true;
        }
    }

     public static bool GetIsRecyclerPurchased(Recycler recycler)
    {
        if(recycler.recyclerType == Recycler.RecyclerType.BasicRecycler)
        {   
            return BasicRecyclerPurchased;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.ModernRecycler)
        {
            return ModernRecyclerPurchased;
        }
        else if(recycler.recyclerType == Recycler.RecyclerType.AdvancedRecycler)
        {
            return AdvancedRecyclerPurchased;
        }

        return false;
    }

    public static bool GetIsRecyclerBuilt(Recycler recycler)
    {
        if(recycler.recyclerType == Recycler.RecyclerType.BasicRecycler)
        {   
            return BasicRecyclerBuilt;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.ModernRecycler)
        {
            return ModernRecyclerBuilt;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.AdvancedRecycler)
        {
            return AdvancedRecyclerBuilt;
        }

        return false;
    }

    public static bool GetIsRecyclerUnlocked(Recycler recycler)
    {
         if(recycler.recyclerType == Recycler.RecyclerType.BasicRecycler)
        {   
            return BasicRecyclerUnlocked;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.ModernRecycler)
        {
            return ModernRecyclerUnlocked;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.AdvancedRecycler)
        {
            return AdvancedRecyclerUnlocked;
        }
        return false;
    }
       
    public static void SetRecyclerUnlocked(Recycler recycler)
    {
        if(recycler.recyclerType == Recycler.RecyclerType.BasicRecycler)
        {   
            BasicRecyclerUnlocked = true;
        }
        else if (recycler.recyclerType == Recycler.RecyclerType.ModernRecycler)
        {
            ModernRecyclerUnlocked = true;
        }
        else if(recycler.recyclerType == Recycler.RecyclerType.AdvancedRecycler)
        {
            AdvancedRecyclerUnlocked = true;
        }
    }

    public static List<int> GetUnlockedTechNodes()
    {
        return UnlockedTechNodes;
    }

    public static void SetUnlockedTechNodes(int ID)
    {
        UnlockedTechNodes.Add(ID);
    }
}
