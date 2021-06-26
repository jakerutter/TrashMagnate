using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingCenterBuilding : MonoBehaviour
{
    [SerializeField] private GameObject SellUI;

   void OnTriggerEnter(Collider other)
   {
       Debug.Log("collided with " + other.name);
   }
}
