using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    private Texture2D skin;
    // Start is called before the first frame update
    void Start()
    {
        
        skin = RecyclingInventory.GetPlayerSkin();

        if(skin != null)
        {      
            Debug.Log("skin is not null");
            SkinnedMeshRenderer renderer = this.GetComponent<SkinnedMeshRenderer>();
            renderer.materials[0].mainTexture = skin;
        }
        else
        {
            Debug.Log("skin is null, retrying");
            RecyclingInventory.LoadSkinFromDisk();
            skin = RecyclingInventory.GetPlayerSkin();

            if(skin != null)
            {
                SkinnedMeshRenderer renderer = this.GetComponent<SkinnedMeshRenderer>();
                renderer.materials[0].mainTexture = skin;
            }
            else
            {
                Debug.Log("skin skin skin is null again");
            }

           
        }
    }
}
