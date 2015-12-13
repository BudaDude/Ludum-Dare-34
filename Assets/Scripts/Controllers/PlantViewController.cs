using UnityEngine;
using System.Collections;

public class PlantViewController : MonoBehaviour {

    public Plant plant { get; private set; }

    public SkinnedMeshRenderer[] meshRend;

    private SkinnedMeshRenderer currentMesh;

	// Use this for initialization
	void Start () {
        plant = new Carrot();
	}

    public void Grow()
    {
        if (plant != null)
        {
            plant.Progress();
            currentMesh.SetBlendShapeWeight((int)plant.GrowthState, 100);
        }
        else
        {
            Debug.LogError("No Plant type found when calling the Grow Command");
        }

    }
    
    public void GrowNewPlant(string type)
    {
        switch (type)
        {
            case "carrot":
                plant = new Carrot();
                currentMesh = meshRend[0];
                currentMesh.SetBlendShapeWeight(0, 0);
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
