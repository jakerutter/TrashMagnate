using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AssemblyInventory
{

    private static int PartLimit;
    private static float MassLimit;
    private static int BuildSkill;
    private static Engine[] AllEngines;
    private static Engine[] UnlockedEngines;
    private static FuelTank[] AllFuelTanks;
    private static FuelTank[] UnlockedFuelTanks;

    public static int GetPartLimit()
    {
        return PartLimit;
    }

    public static void SetPartLimit(int limit)
    {
        PartLimit = limit;
    }

    public static float GetMassLimit()
    {
        return MassLimit;
    }

    public static void SetPartLimit(float limit)
    {
        MassLimit = limit;
    }

    public static int GetBuildSkill()
    {
        return BuildSkill;
    }

    public static void AddToBuilSkill(int skill)
    {
        BuildSkill += skill;
    }

    public static Engine[] GetAllEngines()
    {
        return AllEngines;
    }

    public static void SetAllEngines(Engine[] engines)
    {
        AllEngines = engines;
    }

    public static Engine[] GetUnlockedEngines()
    {
        return UnlockedEngines;
    }

    public static void SetUnlockedEngines(Engine[] engines)
    {
        UnlockedEngines = engines;
    }

    public static FuelTank[] GetAllFuelTanks()
    {
        return AllFuelTanks;
    }

    public static void SetAllFuelTanks(FuelTank[] tanks)
    {
        AllFuelTanks = tanks;
    }

    public static FuelTank[] GetUnlockedFuelTanks()
    {
        return UnlockedFuelTanks;
    }

    public static void SetUnlockedFuelTanks(FuelTank[] tanks)
    {
        UnlockedFuelTanks = tanks;
    }
}
