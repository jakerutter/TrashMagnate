using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //need a variable for each value that will be saved
    //1) All static values
    //2) Player position
    //3) Tech nodes purchased
    //4) Collectables found
    //5) Inventory Items and amounts
    //6) Stats
    //7) Date / Time
    //8) Decision Dates pending

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
    
    // This is my version of Brackeys Player script
    // I named it this because it will house all kinds of data in stead of just player info
    private Messenger messenger;
    private float delay = 0f;

    void Start()
    {
        messenger = GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>();

        //Game is starting from a loaded game -- load all data
        if(SaveSystem.GetIsLoadingGame() == true)
        {
            LoadGame();
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            if(delay <= 0f)
            {
                SaveGame();
                delay = 2f;
            }
            
        }
        else if(Input.GetKeyUp(KeyCode.P))
        {
            if(delay <= 0f)
            {
                LoadGame();
                delay = 2f;
            }
        }

        delay -= Time.deltaTime;
    }
  
    public void SaveGame()
    {
        Debug.Log("attempting save");
        HydrateVariables();
        SaveSystem.SaveGame(this);
        //save current skin
        RecyclingInventory.SaveSkinToDisk();

        messenger.SetMessage(Messenger.MessageType.Success, "Game Saved");
    }

    public void LoadGame()
    {
        Debug.Log("attempting load");
        messenger.SetMessage(Messenger.MessageType.Success, "Game Loaded");
        PlayerData data = SaveSystem.LoadGame();

        //Set player position
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position =  position;
        
        //Set Player skin
        RecyclingInventory.LoadSkinFromDisk();
        //RecyclingInventory.SetPlayerSkin(PlayerSkin);
        //Set statics
        RecyclingInventory.SetPlasticInventory(PlasticInventory);
        RecyclingInventory.SetRubberInventory(RubberInventory);
        RecyclingInventory.SetMetalInventory(MetalInventory);
        RecyclingInventory.SetPaperInventory(PaperInventory);
        RecyclingInventory.SetElectronicInventory(ElectronicInventory);
        RecyclingInventory.SetWoodInventory(WoodInventory);
        RecyclingInventory.SetGlassInventory(GlassInventory);
        
        RecyclingInventory.SetRecyclingSkill(RecyclingSkill);
        RecyclingInventory.SetCarryingCapacity(CarryingCapacity); 
        RecyclingInventory.SetAvailableCapacity(AvailableCapcity);
        RecyclingInventory.SetTotalInventoryMass(TotalInventoryMass);

        RecyclingInventory.SetCurrency(Currency);
        RecyclingInventory.SetRecyclingTechPoints(RecyclingTechPoints);

        RecyclingInventory.SetBasicRecyclerBuilt(BasicRecyclerBuilt);
        RecyclingInventory.SetModernRecyclerBuilt(ModernRecyclerBuilt);
        RecyclingInventory.SetAdvancedRecyclerBuilt(AdvancedRecyclerBuilt);

        RecyclingInventory.SetBasicRecyclerPurchased(BasicRecyclerPurchased);
        RecyclingInventory.SetModernRecyclerPurchased(ModernRecyclerPurchased);
        RecyclingInventory.SetAdvancedRecyclerPurchased(AdvancedRecyclerPurchased);

        RecyclingInventory.SetBasicRecyclerUnlocked(BasicRecyclerUnlocked);
        RecyclingInventory.SetModernRecyclerUnlocked(ModernRecyclerUnlocked);
        RecyclingInventory.SetAdvancedRecyclerUnlocked(AdvancedRecyclerUnlocked);

        RecyclingInventory.SetUnlockedTechNodes(UnlockedTechNodes);
        RecyclingInventory.SetPickupRadius(PickupRadius);

        RecyclingInventory.SetVariableYield(VariableYield);
        RecyclingInventory.SetPollution(Pollution);
        RecyclingInventory.SetPollutionYield(PollutionYield);
        RecyclingInventory.SetWaste(Waste);
        RecyclingInventory.SetWasteYield(WasteYield);

        RecyclingInventory.SetEnergy(Energy);
        RecyclingInventory.SetOpinion(Opinion);
        RecyclingInventory.SetCustomers(Customers);
    }

    public void HydrateVariables()
    {
        PlasticInventory = RecyclingInventory.GetPlasticInventory();
        RubberInventory = RecyclingInventory.GetRubberInventory();
        MetalInventory = RecyclingInventory.GetMetalInventory();
        PaperInventory = RecyclingInventory.GetPaperInventory();
        ElectronicInventory = RecyclingInventory.GetElectronicInventory();
        WoodInventory = RecyclingInventory.GetWoodInventory();
        GlassInventory = RecyclingInventory.GetGlassInventory();

        CarryingCapacity = RecyclingInventory.GetCarryingCapacity();
        AvailableCapcity = RecyclingInventory.GetAvailableCapacity();
        TotalInventoryMass = RecyclingInventory.GetTotalInventoryMass();
        RecyclingSkill = RecyclingInventory.GetRecyclingSkill();

        Currency = RecyclingInventory.GetCurrency();
        RecyclingTechPoints = RecyclingInventory.GetRecyclingTechPoints();

        BasicRecyclerBuilt = RecyclingInventory.GetBasicRecyclerBuilt();
        ModernRecyclerBuilt = RecyclingInventory.GetModernRecyclerBuilt();
        AdvancedRecyclerBuilt = RecyclingInventory.GetAdvancedRecyclerBuilt();

        BasicRecyclerPurchased = RecyclingInventory.GetBasicRecyclerPurchased();
        ModernRecyclerPurchased = RecyclingInventory.GetModernRecyclerPurchased();
        AdvancedRecyclerPurchased = RecyclingInventory.GetAdvancedRecyclerPurchased();

        BasicRecyclerUnlocked = RecyclingInventory.GetBasicRecyclerUnlocked();
        ModernRecyclerUnlocked = RecyclingInventory.GetModernRecyclerUnlocked();
        AdvancedRecyclerUnlocked = RecyclingInventory.GetAdvancedRecyclerUnlocked();

        // public ManualRecyclingUpgrade[] ManualRecyclingUpgrades;
        // public RecyclingVehicle[] RecyclingVehicles;

        List<int> UnlockedTechNodes = RecyclingInventory.GetUnlockedTechNodes();
        PickupRadius = RecyclingInventory.GetPickupRadius();
        
        VariableYield = RecyclingInventory.GetVariableYield();
        Pollution = RecyclingInventory.GetPollution();
        PollutionYield = RecyclingInventory.GetPollutionYield();
        Waste = RecyclingInventory.GetWaste();
        WasteYield = RecyclingInventory.GetWasteYield();

        Energy = RecyclingInventory.GetEnergy();
        Opinion = RecyclingInventory.GetOpinion();
        Customers = RecyclingInventory.GetCustomers();
    }
}
