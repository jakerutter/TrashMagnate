// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Garbage : MonoBehaviour
// {

//     public void AddItemToInventory(float mass, string productType, Sprite newSprite)
//     {
//         // check available inventory space against mass of clicked object
//         bool canHold = RecyclingInventory.HaveAvailableCapacity(mass);
//         //if there is enough room, add it
//         if(canHold)
//         {
//             float totalPlastic = RecyclingInventory.GetPlasticInventory();
//             float newTotal = totalPlastic + mass;
//             RecyclingInventory.SetPlasticInventory(newTotal);
//             RecyclingInventory.AdjustAvailableCapacity(mass);

//             //put item into inventory UI menu
//             GameObject[] cubes = GameObject.FindGameObjectsWithTag("InventoryCube");

//             for(int i = 0; i < cubes.Length; i++)
//             {
//                 if(cubes[i].GetComponent<Image>().sprite == null)
//                 {
//                     Debug.Log(cubes[i].name);

//                     Image img = cubes[i].GetComponent<Image>();
//                     img.sprite = newSprite;
//                     return;
//                 }
//             }
//         }
//     }
// }
