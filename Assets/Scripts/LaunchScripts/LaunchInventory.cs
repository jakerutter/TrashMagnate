using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    private float VehicleMass;
    private float CurrentStageThrust;
    private float CurrentStageFuel;
    private float Throttle;
    private float YawInput;
    private float PitchInput;
    private int RemoteControlLevel;
    private int CurrentAltitude;
    private int CurrentFlightDuration;
    private int CurrentFlightMaximumAltitude;

    public float GetVehicleMass()
    {
        return VehicleMass;
    }

    public void SetVehicleMass(float mass)
    {
        VehicleMass = mass;
    }

    public float GetCurrentStageThrust()
    {
        return CurrentStageThrust;
    }

    public void SetCurrentStageThrust(float thrust)
    {
        CurrentStageThrust = thrust;
    }

    public float GetCurrentStageFuel()
    {
        return CurrentStageFuel;
    }

    public void SetCurrentStageFuel(float fuel)
    {
        CurrentStageFuel = fuel;
    }

    public float GetThrottle()
    {
        return Throttle;
    }

    public void SetThrottle(float throttle)
    {
        Throttle = throttle;
    }

}
