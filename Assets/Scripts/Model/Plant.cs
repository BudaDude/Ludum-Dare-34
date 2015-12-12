using UnityEngine;
using System.Collections;

public class Plant {
    public enum PlantGrowthState { Seedling, Vegetative, Budding, Ripe }

    public bool WorkedToday;

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
    public void AddHealth(int amt)
    {
        Health += amt;

    }


    public void Progress()
    {
        CurrentGrowth += Health * GrowthRate;
        Debug.Log(CurrentGrowth);
        if (CurrentGrowth >= 100)
        {
            CurrentGrowth = 0;
            if (GrowthState != PlantGrowthState.Ripe)
            {
                GrowthState += 1;
            }
        }
        DamageHealth(10);
    }




    
}
