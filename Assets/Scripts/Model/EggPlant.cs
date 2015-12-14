using UnityEngine;
using System.Collections;

public class EggPlant : Plant {

    public override string InspectorName
    {
        get
        {
            return base.InspectorName;
        }

        protected set
        {
            base.InspectorName = value;
        }
    }

    public override int Health
    {
        get
        {
            return base.Health;
        }

        protected set
        {
            base.Health = value;
        }
    }
    public override float GrowthRate
    {
        get
        {
            return base.GrowthRate;
        }

        protected set
        {
            base.GrowthRate = value;
        }
    }

    public EggPlant()
    {
        GrowthRate = .6f;
        Health = 100;
        InspectorName = "EggPlant";
        Type = PlantType.EggPlant;

    }
}
