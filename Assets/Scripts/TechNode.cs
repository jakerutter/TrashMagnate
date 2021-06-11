using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechNode : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private bool unlocked;
    [SerializeField] private string description;
    [SerializeField] private int id;
    [SerializeField] private List<int> predcessors;
    [SerializeField] private List<int> successors;

    private bool isUnlocked;

    public bool GetIsUnlocked(int id)
    {
        return false;
    }

}
