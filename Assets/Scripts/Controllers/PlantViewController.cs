using UnityEngine;
using System.Collections;

public class PlantViewController : MonoBehaviour {

    public Plant plant { get; private set; }

    public SkinnedMeshRenderer meshRend;

	// Use this for initialization
	void Start () {
        plant = new Carrot();
        Invoke("Grow", 2.0f);
	}

    public void Grow()
    {
        plant.Progress();
        meshRend.SetBlendShapeWeight((int)plant.GrowthState,100);
    }
    
    public void GrowNewPlant(string type)
    {
        switch (type)
        {
            case "carrot":
                plant = new Carrot();
                meshRend.SetBlendShapeWeight(0, 0);
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
