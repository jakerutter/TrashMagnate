using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class BuildUI : MonoBehaviour
{
    private Transform buildSlotContainer;
    private Transform buildSlotTemplate;
    private Transform buildStatusIcon;
    private Transform buildingName;
    private BuildingInventory buildingInventory;
    private Player player;
    private Messenger messenger;

    private void Awake()
    {
        buildSlotContainer = transform.Find("BuildSlotContainer");

        if(buildSlotContainer != null)
        {
            buildSlotTemplate = buildSlotContainer.Find("BuildSlotTemplate");
        }
    }

    private void Start()
    {
        if(buildSlotContainer == null)
        {
            buildSlotContainer = transform.Find("BuildSlotContainer");
        }

        if(buildSlotTemplate == null)
        {
            if(buildSlotContainer == null) {return;}
            buildSlotTemplate = buildSlotContainer.Find("BuildSlotTemplate");
        }

        messenger = GameObject.FindGameObjectWithTag("Messenger").GetComponent<Messenger>();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public BuildingInventory GetBuildingInventory()
    {
        return buildingInventory;
    }

    public void SetBuildingInventory(BuildingInventory buildingInventory)
    {
        //Debug.Log("Calling SetBuildInventory. Inv item count = " + buildingInventory.GetBuildingList().Count);

        this.buildingInventory = buildingInventory;

        buildingInventory.OnBuildingListChanged += BuildingInventory_OnBuildingListChanged;
       
        RefreshBuildingInventory();  
    }

    private void RefreshBuildingInventory()
    {
        //Debug.Log("Refreshing BuildInventory Items");
        if(buildSlotContainer == null){
            Debug.Log("item slot container is null in RefreshBuildingInventory");
        }
        
        foreach(Transform child in buildSlotContainer)
        {
            if (child == buildSlotTemplate)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float buildSlotCellSize = 190f;

        foreach (Recycler recycler in buildingInventory.GetBuildingList())
        {        
            RectTransform buildSlotRectTransform = Instantiate(buildSlotTemplate, buildSlotContainer).GetComponent<RectTransform>();
            buildSlotRectTransform.gameObject.SetActive(true);

            buildStatusIcon = buildSlotRectTransform.Find("StatusImage");
            buildingName  = buildSlotRectTransform.Find("BuildingName");

            //get the text area and set the short name
            TextMeshProUGUI nameText = buildingName.gameObject.GetComponent<TextMeshProUGUI>();
            //Debug.Log("short name is " + recycler.GetShortName());
            
            nameText.SetText(recycler.GetShortName());

            if(RecyclingInventory.GetIsRecyclerPurchased(recycler))
            {
                //these Recyclers have been purchased -- can be built and placed onto the map
                buildSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => {

                    Recycler dupeRecycler = new Recycler { recyclerType = recycler.recyclerType };
                    buildingInventory.RemoveBuilding(recycler);

                    RecyclerWorld.DropRecycler(player.GetPosition(), dupeRecycler);

                    //handle build quests
                    player.CheckBuildQuest(recycler);

                };

                 buildSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                    //if player has the appropriate resources, create the building
                    PurchaseBuilding(recycler);
                };

                //place the checkmark sprite because this can be placed in the game
                Image statusIcon = buildStatusIcon.gameObject.GetComponent<Image>();
                statusIcon.sprite = ItemAssets.Instance.CheckSprite;

            }
            //these recyclers are unlocked but not yet purchased
            else if(RecyclingInventory.GetIsRecyclerUnlocked(recycler))
            {
                buildSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
                    //if player has the appropriate resources, create the building
                    PurchaseBuilding(recycler);
                };

                  //place the hand sprite because this can be purchased
                Image statusIcon = buildStatusIcon.gameObject.GetComponent<Image>();
                statusIcon.sprite = ItemAssets.Instance.PurchaseHandSprite;
            }
            //these buildings are not unlocked
            else
            {
                //place the locked sprite because this can be purchased
                Image statusIcon = buildStatusIcon.gameObject.GetComponent<Image>();
                statusIcon.sprite = ItemAssets.Instance.LockSprite;
            }
        
            buildSlotRectTransform.anchoredPosition = new Vector2(x * buildSlotCellSize, y * buildSlotCellSize);
            Image image = buildSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = recycler.GetSprite();
            
            x++;

            if(x > 5)
            {
                x=0;
                y--;
            }
        }
    }

    private void BuildingInventory_OnBuildingListChanged(object sender, System.EventArgs e)
    {
        RefreshBuildingInventory();
    }

    private void PurchaseBuilding(Recycler recycler)
    {
        //first identify if this building has been purchased 
        bool hasBeenPurchased = RecyclingInventory.GetIsRecyclerPurchased(recycler);

        if(hasBeenPurchased) 
        {
            messenger.SetMessage(Messenger.MessageType.Info, recycler.GetName() + " already purchased. Right click to place.");
            return;
        }

        //check if player has resources to build this
        List<Item> costList = recycler.GetCost();

        bool hasResources = CheckHasResources(costList);

        if(hasResources)
        {           
            //set this recycler as purchased
            RecyclingInventory.SetRecyclerPurchased(recycler);

            //send message letting player know they've created building
            messenger.SetMessage(Messenger.MessageType.Success, "You have purchased the " + recycler.GetName() + ". Right click to build.");

            //set statusIcon to check mark (Showing purchased)
            Image statusIcon = buildStatusIcon.gameObject.GetComponent<Image>();
            statusIcon.sprite = ItemAssets.Instance.CheckSprite;
            //refresh build inventory
            player.RefreshBuildingInventory();

        }
        else 
        {
            //send message letting player know they're short resources
            messenger.SetMessage(Messenger.MessageType.Failure, "Resources lacking. Gather required components.");
        }

    }

    public bool CheckHasResources(List<Item> costList)
    {
        bool hasResources = true;

        //get inventory itemList
        List<Item> inventoryList = player.GetInventory();
        List<Item> dupeList = inventoryList; //this list is for rollback purposes
        //compare against cost
        foreach (Item item in costList)
        {
            for(int i = 0; i < inventoryList.Count - 1; i++)
            {
                if(item.itemType == inventoryList[i].itemType)
                {
                    if(item.amount < inventoryList[i].amount)
                    {
                        Debug.Log("Have " + item.amount.ToString() +" " + item.GetName() + " need " + inventoryList[i].amount.ToString() + " " + inventoryList[i].GetName());
                        //create new dupe item
                        int newAmount = inventoryList[i].amount -= item.amount;
                        Item.ItemType newType = inventoryList[i].itemType;
                        //remove original item from inventory
                        inventoryList.Remove(inventoryList[i]);
                        Item newItem = new Item { itemType = newType, amount = newAmount };
                        //add new item to inventory
                        inventoryList.Add(newItem);
                    }
                    else if (item.amount == inventoryList[i].amount)
                    { 
                        //had the perfect amount
                        //remove item from inventory entirely
                        inventoryList.Remove(inventoryList[i]);
                        Debug.Log("had perfect amount, removed item");
                    }
                    else 
                    {
                        // did not have enough of this type of item
                        //RESET invntory list to dupeList then RETURN false
                        Debug.Log("Resetting inventoryList to DupeList");
                        inventoryList = dupeList;
                        return false;
                    }
                }
            }
        }
        
        player.RefreshInventory();
        //for now just return false
        return hasResources;
    }
}
