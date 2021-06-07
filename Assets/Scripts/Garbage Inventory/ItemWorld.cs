using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        GameObject prefab = item.GetPrefab();
        //Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        Transform transform = go.transform;
        if(transform == null)
        {
            Debug.LogWarning("transform is null");
        }

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        
        if(itemWorld == null)
        {
            Debug.Log("itemWorld is null");
            return itemWorld;
        }

        if(item == null)
        {
            Debug.Log("item is null");
            return itemWorld;
        }

        if(position == null)
        {
            Debug.Log("position is null");
            return itemWorld;
        }

        itemWorld.SetItem(item, position, transform);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        randomDir.y = 0f;
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * .5f, item);
        //itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * .5f, ForceMode2D.Impulse);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * .5f, ForceMode.Impulse);
        return itemWorld;
    }

    public static ItemWorld DropItemsRealTime(Vector3 dropPosition, Item item)
    {
        
        Vector3 randomDir = UtilsClass.GetRandomDir();
        randomDir.y = 0f;
        ItemWorld itemWorld  = SpawnItemWorld(dropPosition + randomDir * .5f, item);
        //itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * .5f, ForceMode2D.Impulse);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * .5f, ForceMode.Impulse);
        return itemWorld;
    }

    public void SetItem(Item item, Vector3 position, Transform trans)
    {
        this.item = item;
        GameObject itemObj = item.GetPrefab();
        Instantiate(itemObj, position, Quaternion.identity, trans);

        // textMeshPro = gameObject.transform.Find("Text").GetComponent<TextMeshPro>();
        
        // spriteRenderer.sprite = null;

        // if(item.amount > 1)
        // {
        //     textMeshPro.SetText(item.amount.ToString());
        // }
        // else 
        // {
        //     textMeshPro.SetText("");
        // }  
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
