using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] playerPosition;
    public float PlasticInventory;
    public float RubberInventory;
    public float MetalInventory;
    public float PaperInventory;
    public float ElectronicInventory;
    public float WoodInventory;
    public float GlassInventory;

    public float CarryingCapacity;
    public float AvailableCapcity;
    public float TotalInventoryMass;

    public int RecyclingSkill;
    public float Currency;
    public int RecyclingTechPoints;

    public bool BasicRecyclerBuilt;
    public bool ModernRecyclerBuilt;
    public bool AdvancedRecyclerBuilt;

    public bool BasicRecyclerPurchased;
    public bool ModernRecyclerPurchased;
    public bool AdvancedRecyclerPurchased;

    public bool BasicRecyclerUnlocked;
    public bool ModernRecyclerUnlocked;
    public bool AdvancedRecyclerUnlocked;

    // public ManualRecyclingUpgrade[] ManualRecyclingUpgrades;
    // public RecyclingVehicle[] RecyclingVehicles;
    public List<int> UnlockedTechNodes;
    public float PickupRadius;
    public float VariableYield;
    public float Pollution;
    public float PollutionYield;
    public float Waste;
    public float WasteYield;

    public float Energy;
    public float Opinion;
    public int Customers;
    
    public PlayerData(DataManager manager)
    {
        playerPosition = new float[3];
        playerPosition[0] = manager.transform.position.x;
        playerPosition[1] = manager.transform.position.y;
        playerPosition[2] = manager.transform.position.z;

        PlasticInventory = manager.PlasticInventory;
        RubberInventory = manager.RubberInventory;
        MetalInventory = manager.MetalInventory;
        PaperInventory = manager.PaperInventory;
        ElectronicInventory = manager.ElectronicInventory;
        WoodInventory = manager.WoodInventory;
        GlassInventory = manager.GlassInventory;
        
        CarryingCapacity = manager.CarryingCapacity;
        AvailableCapcity = manager.AvailableCapcity;
        TotalInventoryMass = manager.TotalInventoryMass;
        RecyclingSkill = manager.RecyclingSkill;

        Currency = manager.Currency;
        RecyclingTechPoints = manager.RecyclingTechPoints;

        BasicRecyclerBuilt = manager.BasicRecyclerBuilt;
        ModernRecyclerBuilt = manager.ModernRecyclerBuilt;
        AdvancedRecyclerBuilt = manager.AdvancedRecyclerBuilt;

        BasicRecyclerPurchased = manager.BasicRecyclerPurchased;
        ModernRecyclerPurchased = manager.ModernRecyclerPurchased;
        AdvancedRecyclerPurchased = manager.AdvancedRecyclerPurchased;

        BasicRecyclerUnlocked = manager.BasicRecyclerUnlocked;
        ModernRecyclerUnlocked = manager.ModernRecyclerUnlocked;
        AdvancedRecyclerUnlocked = manager.AdvancedRecyclerUnlocked;

        UnlockedTechNodes = manager.UnlockedTechNodes;
        PickupRadius = manager.PickupRadius;

        VariableYield = manager.VariableYield;
        Pollution = manager.Pollution;
        PollutionYield = manager.PollutionYield;
        Waste = manager.Waste;
        WasteYield = manager.WasteYield;

        Energy = manager.Energy;
        Opinion = manager.Opinion;
        Customers = manager.Customers;

    }
}
