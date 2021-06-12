using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechNode : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private bool unlocked;
    [SerializeField] private string description;
    [SerializeField] private int id;
    [SerializeField] private int unlockedBy;
    [SerializeField] private int unlocks;

    private bool isUnlocked;

    public bool GetIsUnlocked(int id)
    {
        return false;
    }

}
