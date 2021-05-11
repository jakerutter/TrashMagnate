using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class will hold generic game stats
public static class GameStats
{

    private static int NumberOfLaunches;
    private static float MaximumAltitude;
    private static float MaximumFlightTime;
    private static int GarbageCleared;
    private static int MoneyEarned;
    private static int MoneySpent;

    public static int GetNumberOfLaunches()
    {
        return NumberOfLaunches;
    }

    public static void AddOneLaunchToTotal()
    {
        NumberOfLaunches += 1;
    }

     public static float GetMaximumAltitude()
    {
        return MaximumAltitude;
    }

    public static void SetMaximumAltitude(float altitude)
    {
        if (altitude > MaximumAltitude)
        {
            MaximumAltitude = altitude;
        }
    }

     public static float GetMaximumFlightTime()
    {
        return MaximumFlightTime;
    }

    public static void SetMaximumFlightTime(float time)
    {
        if (time > MaximumFlightTime)
        {
            MaximumFlightTime = time;
        }
    }

     public static int GetGarbageCleared()
    {
        return GarbageCleared;
    }

    public static void AddGarbageCleared(int garbage)
    {
        GarbageCleared += garbage;
    }

     public static int GetMoneyEarned()
    {
        return MoneyEarned;
    }

    public static void AddMoneyEarned(int money)
    {
        MoneyEarned += money;
    }

    public static int GetMoneySpent()
    {
        return MoneySpent;
    }

    public static void AddMoneySpent(int money)
    {
        MoneySpent += money;
    }

}
