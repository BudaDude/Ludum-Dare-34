﻿using UnityEngine;
using System.Collections;

public class PlantViewController : MonoBehaviour {

    public Plant plant { get; private set; }

    public SkinnedMeshRenderer[] meshRend;

    private SkinnedMeshRenderer currentMesh;

    public GameObject healthBar;

    private Inventory inventory;

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindObjectOfType<Inventory>();
        healthBar = GetComponentInChildren<Canvas>().gameObject;
        healthBar.SetActive(false);

    }

    public void Grow()
    {
        if (plant != null)
        {
            
            currentMesh.SetBlendShapeWeight((int)plant.GrowthState, 0);

            plant.Progress();
            if (inventory.doubleSpeedFert)
            {

                plant.AddHealth(20);
                plant.Progress();

            }


            if (plant.Health > 0) {
                Debug.Log(plant.Health);
                currentMesh.SetBlendShapeWeight((int)plant.GrowthState, 100);

            if (plant.GrowthState == Plant.PlantGrowthState.Ripe)
            {
                healthBar.SetActive(false);
            }
            else
            {
                healthBar.SetActive(true);
            }
            }
            else
            {
                currentMesh.gameObject.SetActive(false);
                plant = null;
            }
        }
        else
        {

        }

    }

    public void Harvest()
    {
        if (plant != null)
        {
            if (plant.GrowthState == Plant.PlantGrowthState.Ripe)
            {
                if (plant.Type == PlantType.Carrot)
                {
                    inventory.carrotAmount += 1;
                    

                }
                else
                {
                    inventory.eggplantAmount += 2;
                }
                currentMesh.gameObject.SetActive(false);
                plant = null;
            }

        }
    }
    
    public void GrowNewPlant(PlantType type)
    {
        switch (type)
        {
            case PlantType.Carrot:
                plant = new Carrot();
                currentMesh = meshRend[0];
                currentMesh.gameObject.SetActive(true);
                currentMesh.SetBlendShapeWeight(0, 100);
                healthBar.SetActive(true);
                break;
            case PlantType.EggPlant:
                plant = new EggPlant();
                currentMesh = meshRend[1];
                currentMesh.gameObject.SetActive(true);
                currentMesh.SetBlendShapeWeight(0, 100);
                healthBar.SetActive(true);

                break;
            default:
                Debug.LogError("Plant Name not valid, Cannot create plant");
                break;

        }
    }


	
	// Update is called once per frame
	void Update () {
	

	}
}
