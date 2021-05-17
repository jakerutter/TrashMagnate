using System.Collections;
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

    private static int RecyclingSkill = 2;
    private static int Currency;

    private static ManualRecyclingUpgrade[] ManualRecyclingUpgrades;
    private static RecyclingVehicle[] RecyclingVehicles;

    public static float GetPlasticInventory()
    {
        return PlasticInventory;
    }

    public static void SetPlasticInventory(float inventory)
    {
        PlasticInventory = inventory;
        Debug.Log("plastic inv should = " + inventory);
        GameObject plasticInv = GameObject.FindGameObjectWithTag("PlasticInv");

        Text plasticText = plasticInv.GetComponent<Text>();

        plasticText.text = "Plastic: \n "+string.Format("{0:F2}",inventory)+ "kg";

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
        Debug.Log("rubber inv should = " + inventory);
        GameObject rubberInv = GameObject.FindGameObjectWithTag("RubberInv");

        Text rubberText = rubberInv.GetComponent<Text>();

        rubberText.text = "Rubber: \n "+string.Format("{0:F2}",inventory)+ "kg";

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
        Debug.Log("metal inv should = " + inventory);
        GameObject metalInv = GameObject.FindGameObjectWithTag("MetalInv");

        Text metalText = metalInv.GetComponent<Text>();

        metalText.text = "Meetal: \n "+string.Format("{0:F2}",inventory)+ "kg";

        TextMeshProUGUI text = GameObject.FindGameObjectWithTag("MetalAmount").GetComponent<TextMeshProUGUI>();
        text.SetText(string.Format("{0:F2}",inventory)+ " kg");
    }

     public static float GetGlassInventory()
    {
        return GlassInventory;
    }

    public static void SetGlassInventory(float inventory)
    {
        Debug.Log("glass inv should = " + inventory);
        GlassInventory = inventory;
        GameObject glassInv = GameObject.FindGameObjectWithTag("GlassInv");

        Text glassText = glassInv.GetComponent<Text>();

        glassText.text = "Glass: \n "+string.Format("{0:F2}",inventory)+ "kg";

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
        Debug.Log("paper inv should = " + inventory);

        GameObject paperInv = GameObject.FindGameObjectWithTag("PaperInv");

        Text paperText = paperInv.GetComponent<Text>();

        paperText.text = "Paper: \n "+string.Format("{0:F2}",inventory)+ "kg";

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

        Debug.Log("Electronic inv should = " + inventory);

        GameObject ElectronicInv = GameObject.FindGameObjectWithTag("ElectronicInv");

        Text ElectronicText = ElectronicInv.GetComponent<Text>();

        ElectronicText.text = "Electronic: \n "+string.Format("{0:F2}",inventory)+ "kg";

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

        Debug.Log("wood inv should = " + inventory);

        GameObject woodInv = GameObject.FindGameObjectWithTag("WoodInv");

        Text woodText = woodInv.GetComponent<Text>();

        woodText.text = "Wood: \n "+string.Format("{0:F2}",inventory)+ "kg";

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
    }

    public static int GetCurrency()
    {
        return Currency;
    }

    public static void SetCurrency(int currency)
    {
        Currency += currency;
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

        GameObject cap = GameObject.FindGameObjectWithTag("GarbageCapacityText");
        Text capText = cap.GetComponent<Text>();
        capText.text = "Carrying Capacity\n "+totalMass+" kg / "+carryLimit+ " kg";  
    }

    // public static void SetRecyclerType(RecyclerType recType)
    // {
    //     recyclerType = recType;
    // }

    // public static RecyclerType GetRecyclerType()
    // {
    //     return recyclerType;
    // }
}
