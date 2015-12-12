using UnityEngine;
using System.Collections;

public class Plant {
    public enum PlantGrowthState { Seedling, Vegetative, Budding, Ripe }


    public virtual string InspectorName
    {
        get; protected set;
    }

    public float CurrentGrowth {
        get; protected set;
    }
    public virtual int Health { get; protected set; }

    public PlantGrowthState GrowthState { get; protected set; }

    public virtual float GrowthRate { get; protected set; }

    public Plant()
    {
        CurrentGrowth = 0;

    }

    public void DamageHealth(int amt)
    {
        Health -= amt;
    }


    public void Progress()
    {
        CurrentGrowth += Health * GrowthRate;
    }




    
}
