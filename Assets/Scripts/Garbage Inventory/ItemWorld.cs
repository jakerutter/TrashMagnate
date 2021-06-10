using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        GameObject go = transform.Find("Canvas").gameObject;

        textMeshPro = go.transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        
        itemWorld.SetItem(item, position, transform);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        randomDir.y = 0f;
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * .5f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * .5f, ForceMode.Impulse);
        return itemWorld;
    }

    public static ItemWorld DropItemsRealTime(Vector3 dropPosition, Item item)
    {
        
        Vector3 randomDir = UtilsClass.GetRandomDir();
        randomDir.y = 0f;
        ItemWorld itemWorld  = SpawnItemWorld(dropPosition + randomDir * .5f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * .5f, ForceMode.Impulse);
        return itemWorld;
    }

    public void SetItem(Item item, Vector3 position, Transform trans)
    {
        this.item = item;
        Debug.Log("Item is " + item.GetName());
        GameObject prefab = item.GetPrefab();
        
        GameObject model = Instantiate(prefab, position, Quaternion.identity);
        model.transform.SetParent(trans, true);
        //textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if(item.amount > 1)
        {
            //Debug.Log(item.amount.ToString());
            textMeshPro.SetText(item.amount.ToString());
        }
        else 
        {
            textMeshPro.SetText("");
        }  
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
