using UnityEngine;
using System.Collections;

public class Carrot : Plant {

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

    public Carrot()
    {
        GrowthRate = .7f;
        Health = 100;
        InspectorName = "Carrot";
        Type = PlantType.Carrot;
    }



}
