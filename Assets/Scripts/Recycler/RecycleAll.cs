using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleAll : MonoBehaviour
{
    private Inventory inventory;
    
    public void SetRecycleAllInv(Inventory inventory)
    {
        //Debug.Log("Calling SetRecycleAllInv. Inv item count = " + inventory.GetItemList().Count);

       this.inventory = inventory; 
    }

    public void RecycleAllItems()
    {
        inventory.RecycleAll();
    }
}
