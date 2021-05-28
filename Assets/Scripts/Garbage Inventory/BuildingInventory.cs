using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInventory
{
    public event EventHandler OnBuildingListChanged;

    private List<Recycler> buildingList;
    private Action<Recycler> useBuildingAction;
    private AudioManager _audio;

    public BuildingInventory(Action<Recycler> useBuildingAction)
    {
        this.useBuildingAction = useBuildingAction;
        buildingList = new List<Recycler>();

        buildingList.Add(new Recycler { recyclerType = Recycler.RecyclerType.BasicRecycler });
        buildingList.Add(new Recycler { recyclerType = Recycler.RecyclerType.ModernRecycler });
    }

    public void AddBuilding(Recycler recycler)
    {
        buildingList.Add(recycler);

        if(OnBuildingListChanged != null)
        {
            //Debug.Log("OnBuildingListChanged is Invoked");
            OnBuildingListChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveBuilding(Recycler recycler)
    {
        buildingList.Remove(recycler);
        
        if(OnBuildingListChanged != null)
        {
            OnBuildingListChanged.Invoke(this, EventArgs.Empty);
        }
    }

    // public void CreateBuilding(Recycler recycler)
    // {
    //     //check if player has resources to build this
    //     useBuildingAction(recycler);
    // }
           
    public List<Recycler> GetBuildingList()
    {
        return buildingList;
    }
}
