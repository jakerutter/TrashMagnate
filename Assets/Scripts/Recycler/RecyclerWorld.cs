using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class RecyclerWorld : MonoBehaviour
{
    public Button recycleInventoryToggle;
    // Need to know what objects are clickable
    //Need to swap cursors per object type
    public LayerMask clickableLayer;
    public Texture2D pointer; // normal pointer
    public Texture2D recycleCursor; // recycle pointer
    public EventVector3 OnClickEnvironment;

    public static RecyclerWorld SpawnRecyclerWorld(Vector3 position, Recycler recycler)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfRecyclerWorld, position, Quaternion.identity);

        RecyclerWorld recyclerWorld = transform.GetComponent<RecyclerWorld>();
        recyclerWorld.SetRecycler(recycler);

        return recyclerWorld;
    }

    public static RecyclerWorld DropRecycler(Vector3 dropPosition, Recycler recycler)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        randomDir.y = 0f;
        RecyclerWorld recyclerWorld  = SpawnRecyclerWorld(dropPosition + randomDir * .5f, recycler);
        //recyclerWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * .5f, ForceMode2D.Impulse);
        recyclerWorld.GetComponent<Rigidbody>().AddForce(randomDir * .5f, ForceMode.Impulse);
        return recyclerWorld;
    }

    private Recycler recycler;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetRecycler(Recycler recycler)
    {
        this.recycler = recycler;
        spriteRenderer.sprite = recycler.GetSprite();
    }

    public Recycler GetRecycler()
    {
        Debug.Log("GetRecycler has been called");
        Debug.Log(recycler.GetName());
        return recycler;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

      private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Selecting item "+ this.gameObject.name);

            recycleInventoryToggle = GameObject.FindGameObjectWithTag("RecycleInventoryToggle").GetComponent<Button>();
            recycleInventoryToggle.onClick.Invoke();
            Cursor.SetCursor(recycleCursor, new Vector2(16,16), CursorMode.Auto);
        }
    }
}
