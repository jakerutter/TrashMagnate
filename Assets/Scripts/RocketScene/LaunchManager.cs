using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    public Engine engine;
    public FuelTank tank;
    public GameObject rocket;
    public GameObject exhaust;
    public GameObject fuelPanel;

    private float thrust;
    private float consumption;
    private float fuel;
    private float movementSpeed;
    private Transform trans;
    private bool thrustOn = false;

    void Start()
    {
        exhaust.SetActive(true);

        thrust = engine.thrust;
        consumption = engine.fuelConsumption;
        fuel = tank.fuelAmount;
        movementSpeed = .5f * thrust;
        trans = rocket.transform;

        //get fuel panel and set its height to max
        fuelPanel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 400);
    }


    void Update()
    {

        if(Input.GetKeyDown("t"))
        {
            thrustOn = true;
        }
         if(Input.GetKeyDown("g"))
        {
            thrustOn = false;
        }


        if (thrustOn && fuel > 0)
        {
            exhaust.SetActive(false);

            // move rocket upward by thrust amount
            trans.position = rocket.transform.position + new Vector3(0, movementSpeed * Time.deltaTime, 0);
            rocket.transform.position = trans.position;
            //consume fuel
            fuel -= consumption * Time.deltaTime;
            //show fuel being consumed
            fuelPanel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, fuel*4);
        }
        else
        {
            exhaust.SetActive(false);
        }
    }
}
