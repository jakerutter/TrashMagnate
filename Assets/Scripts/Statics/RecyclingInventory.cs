using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class RecyclingInventory
{
    public static Texture2D PlayerSkin;

    private static float PlasticInventory;
    private static float RubberInventory;
    private static float MetalInventory;
    private static float PaperInventory;
    private static float ElectronicInventory;
    private static float WoodInventory;
    private static float GlassInventory;
    private static float CarryingCapacity = 5000f;
    private static float AvailableCapcity;
    private static float TotalInventoryMass;
    private static int RecyclingSkill = 2;
    private static float Currency;
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
    private static float PickupRadius;
    public static float VariableYield = 1f;
    public static float Pollution = 0f;
    public static float PollutionYield = 50f;
    public static float Waste = 0f;
    public static float WasteYield = 10f;
    public static float Energy = 0f;
    public static float Opinion = 0f;
    public static int Customers = 0;

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

     public static void SetRecyclingSkill(int skill)
    {
        RecyclingSkill = skill;
    }

    public static void AddRecyclingSkill(int skill)
    {
        RecyclingSkill += skill;
        //send [success] message showing recycling skill increase
        Messenger messenger = GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>();
        messenger.SetMessage(Messenger.MessageType.Success, "Congrats! Recycling skill increased to " + RecyclingSkill.ToString() + ".");
        Debug.Log("Recycling skill == "+ RecyclingSkill);
    }

    public static float GetCurrency()
    {
        return Currency;
    }

    public static void SetCurrency(float currency)
    {
        Currency = currency;
    }

    public static void AddCurrency(float currency)
    {
        Currency += currency;
    }

    public static int GetRecyclingTechPoints()
    {
        return RecyclingTechPoints;
    }

    public static void SetRecyclingTechPoints(int rtPoints)
    {
        RecyclingTechPoints = rtPoints;
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
        CarryingCapacity = capacity;
    }

    public static void AddCarryingCapacity(float capacity)
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

    public static void SetAvailableCapacity(float capacity)
    {
        AvailableCapcity = capacity;
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

    public static void SetTotalInventoryMass(float mass)
    {
        TotalInventoryMass = mass;
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

    public static bool GetBasicRecyclerBuilt()
    {
        return BasicRecyclerBuilt;
    }

    public static bool GetModernRecyclerBuilt()
    {
        return ModernRecyclerBuilt;
    }

    public static bool GetAdvancedRecyclerBuilt()
    {
        return AdvancedRecyclerBuilt;
    }

    public static void SetBasicRecyclerBuilt(bool built)
    {
        BasicRecyclerBuilt = built;
    }

    public static void SetModernRecyclerBuilt(bool built)
    {
        ModernRecyclerBuilt = built;
    }

    public static void SetAdvancedRecyclerBuilt(bool built)
    {
        AdvancedRecyclerBuilt = built;
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

    public static bool GetBasicRecyclerPurchased()
    {
        return BasicRecyclerPurchased;
    }

    public static bool GetModernRecyclerPurchased()
    {
        return ModernRecyclerPurchased;
    }

    public static bool GetAdvancedRecyclerPurchased()
    {
        return AdvancedRecyclerPurchased;
    }

    public static void SetBasicRecyclerPurchased(bool purchased)
    {
        BasicRecyclerPurchased = purchased;
    }

    public static void SetModernRecyclerPurchased(bool purchased)
    {
        ModernRecyclerPurchased = purchased;
    }

    public static void SetAdvancedRecyclerPurchased(bool purchased)
    {
        AdvancedRecyclerPurchased = purchased;
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

    public static bool GetBasicRecyclerUnlocked()
    {
        return BasicRecyclerUnlocked;
    }

    public static bool GetModernRecyclerUnlocked()
    {
        return ModernRecyclerUnlocked;
    }

    public static bool GetAdvancedRecyclerUnlocked()
    {
        return AdvancedRecyclerUnlocked;
    }

    public static void SetBasicRecyclerUnlocked(bool unlocked)
    {
        BasicRecyclerUnlocked = unlocked;
    }

    public static void SetModernRecyclerUnlocked(bool unlocked)
    {
        ModernRecyclerUnlocked = unlocked;
    }

    public static void SetAdvancedRecyclerUnlocked(bool unlocked)
    {
        AdvancedRecyclerUnlocked = unlocked;
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

    public static void AddUnlockedTechNodes(int ID)
    {
        UnlockedTechNodes.Add(ID);
    }

    public static void SetUnlockedTechNodes(List<int> techNodes)
    {
        UnlockedTechNodes = techNodes;
    }

    public static float GetPickupRadius()
    {
        return PickupRadius;
    }

    public static void SetPickupRadius(float radius)
    {
        PickupRadius = radius;
    }

    public static void AdjustPickupRadiusByPercent(float percent, bool isPositive)
    {
        //adjust pickup raius by percent and set its value to the static variable
        Debug.Log("PickupRadius was " + PickupRadius.ToString());
        if (isPositive)
        {
            PickupRadius = (PickupRadius + PickupRadius * percent);    
        }
        else
        {
            PickupRadius = (PickupRadius - PickupRadius * percent); 
        }

        Debug.Log("PickupRadius is now " + PickupRadius.ToString());
        
    }

    public static float GetVariableYield()
    {
        return VariableYield;
    }

    public static void SetVariableYield(float yield)
    {
        VariableYield = yield;
    }

    public static void  AdjustVariableYieldByPercent(float percent, bool isPositive)
    {
        //adjust yield by percent and set its value to the static variable
        Debug.Log("VariableYield was " + VariableYield.ToString());
        if (isPositive)
        {
            VariableYield = (VariableYield + VariableYield * percent);    
        }
        else
        {
            VariableYield = (VariableYield - VariableYield * percent); 
        }

        Debug.Log("VariableYield is now " + VariableYield.ToString());
    }

    public static float GetPollution()
    {
        return Pollution;
    }

    public static void AdjustPollutionByPercent(float percent, bool isPositive)
    {
        //adjust Pollution by percent and set its value to the static variable
        Debug.Log("Pollution was " + Pollution.ToString());
        if (isPositive)
        {
            Pollution = (Pollution + Pollution * percent);    
        }
        else
        {
            Pollution = (Pollution - Pollution * percent); 
        }

        Debug.Log("Pollution is now " + Pollution.ToString());
    }

    public static void SetPollution(float amount)
    {
        Pollution = amount;
    }

    public static void AddPollution(float amount)
    {
        //adjust Pollution by percent and set its value to the static variable
        Debug.Log("Pollution was " + Pollution.ToString());
        
        Pollution += amount;

        Debug.Log("Pollution is now " + Pollution.ToString());
    }

    public static float GetPollutionYield()
    {
        return PollutionYield;
    }

    public static void SetPollutionYield(float amount)
    {
        PollutionYield = amount;
    }

    public static void AdjustPollutionYieldByPercent(float percent, bool isPositive)
    {
        //adjust Pollution by percent and set its value to the static variable
        Debug.Log("PollutionYield was " + PollutionYield.ToString());
        if (isPositive)
        {
            PollutionYield = (PollutionYield + PollutionYield * percent);    
        }
        else
        {
            PollutionYield = (PollutionYield - PollutionYield * percent); 
        }

        Debug.Log("PollutionYield is now " + PollutionYield.ToString());
    }

    public static void AdjustPollutionYieldByAmount(float amount)
    {
        //adjust Pollution by percent and set its value to the static variable
        Debug.Log("PollutionYield was " + PollutionYield.ToString());
        
        PollutionYield += amount;

        Debug.Log("PollutionYield is now " + PollutionYield.ToString());
    }

    public static float GetWaste()
    {
        return Waste;
    }

    public static void SetWaste(float amount)
    {
        Waste = amount;
    }

    public static void AdjustWasteByPercent(float percent, bool isPositive)
    {
        //adjust Waste by percent and set its value to the static variable
        Debug.Log("Waste was " + Waste.ToString());
        if (isPositive)
        {
            Waste = (Waste + Waste * percent);    
        }
        else
        {
            Waste = (Waste - Waste * percent); 
        }

        Debug.Log("Waste is now " + Waste.ToString());
    }

    public static void AddWaste(float amount)
    {
        //adjust Waste by percent and set its value to the static variable
        Debug.Log("Waste was " + Waste.ToString());
        
        Waste += amount;

        Debug.Log("Waste is now " + Waste.ToString());
    }

    public static float GetWasteYield()
    {
        return WasteYield;
    }

    public static void SetWasteYield(float amount)
    {
        WasteYield = amount;
    }

    public static void AdjustWasteYieldByPercent(float percent, bool isPositive)
    {
        //adjust WasteYield by percent and set its value to the static variable
        Debug.Log("WasteYield was " + WasteYield.ToString());
        if (isPositive)
        {
            WasteYield = (WasteYield + WasteYield * percent);    
        }
        else
        {
            WasteYield = (WasteYield - WasteYield * percent); 
        }

        Debug.Log("WasteYield is now " + WasteYield.ToString());
    }

    public static void AddWasteYield(float amount)
    {
        //adjust WasteYield by percent and set its value to the static variable
        Debug.Log("WasteYield was " + WasteYield.ToString());
        
        WasteYield += amount;

        Debug.Log("WasteYield is now " + WasteYield.ToString());
    }

    public static float GetEnergy()
    {
        return Energy;
    }

    public static void SetEnergy(float energy)
    {
        Energy = energy;
    }

    public static void AdjustEnergyByPercent(float percent, bool isPositive)
    {
        //adjust Energy by percent and set its value to the static variable
        Debug.Log("Energy was " + Energy.ToString());
        if (isPositive)
        {
            Energy = (Energy + Energy * percent);    
        }
        else
        {
            Energy = (Energy - Energy * percent); 
        }

        Debug.Log("Energy is now " + Energy.ToString());
    }

    public static void AdjustEnergyByAmount(int amount)
    {
        //adjust Energy by percent and set its value to the static variable
        Debug.Log("Energy was " + Energy.ToString());
        
        Energy += amount;

        Debug.Log("Energy is now " + Energy.ToString());
    }

    public static float GetOpinion()
    {
        return Opinion;
    }

    public static void SetOpinion(float opinion)
    {
        Opinion = opinion;
    }

    public static void AdjustOpinionByPercent(float percent, bool isPositive)
    {
        //adjust Opinion by percent and set its value to the static variable
        Debug.Log("Opinion was " + Opinion.ToString());
        if (isPositive)
        {
            Opinion = (Opinion + Opinion * percent);    
        }
        else
        {
            Opinion = (Opinion - Opinion * percent); 
        }

        Debug.Log("Opinion is now " + Opinion.ToString());
    }

    public static void AdjustOpinionByAmount(int amount)
    {
        //adjust Opinion by percent and set its value to the static variable
        Debug.Log("Opinion was " + Opinion.ToString());
        
        Opinion += amount;

        Debug.Log("Opinion is now " + Opinion.ToString());
    }

    public static void UpdateOpinion()
    {
        // Opinion formula: Opinion = - Pollution + -2(Waste) + Customers + 2(Energy) + VariableOpinion?
        Opinion = -Pollution +  -2*Waste + Customers + 2*Energy;
    }

    public static List<float> GetProgressData()
    {
        List<float> progressList = new List<float>();

        progressList.Add(Currency);
        progressList.Add(Pollution);
        progressList.Add(Opinion);
        progressList.Add(Waste);

        return progressList;
    }

    public static int GetCustomers()
    {
        return Customers;
    }

    public static void SetCustomers(int customers)
    {
        Customers = customers;
    }

    public static void AddCustomers(int customers)
    {
        Customers += customers;
    }

    public static Texture2D GetPlayerSkin()
    {
        return PlayerSkin;
    }

    public static void SetPlayerSkin(Texture2D skin)
    {
        PlayerSkin = skin;
        Debug.Log("saved skin in SetPlayerSkin");
    }

    public static void SaveSkinToDisk()
    {
        string saveFileName = SaveSystem.GetSpecificPath();

        Texture2D skin = DeCompress(PlayerSkin);
        
        byte[] bytes = skin.EncodeToPNG();

        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + saveFileName + "PlayerSkin.png", bytes);

        //Debug.Log("skin saved " + bytes.Length / 1024 + "Kb was saved as " + Application.persistentDataPath + saveFileName + "/PlayerSkin");
    }

    public static void LoadSkinFromDisk()
    {
        string saveFileName = SaveSystem.GetSpecificPath();

        byte[] bytes;
        bytes = System.IO.File.ReadAllBytes(Application.persistentDataPath +"/"+ saveFileName + "PlayerSkin.png");
        PlayerSkin = new Texture2D(1,1);
        PlayerSkin.LoadImage(bytes);

        // apply skin to character
        GameObject playerSkinObj = GameObject.FindGameObjectWithTag("Skin");

        SkinnedMeshRenderer renderer = playerSkinObj.GetComponent<SkinnedMeshRenderer>();
        renderer.materials[0].mainTexture = PlayerSkin;
    }

    public static Texture2D DeCompress(this Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

}
