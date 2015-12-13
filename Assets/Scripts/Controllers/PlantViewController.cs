using UnityEngine;
using System.Collections;

public class PlantViewController : MonoBehaviour {

    public Plant plant { get; private set; }

    public SkinnedMeshRenderer[] meshRend;

    private SkinnedMeshRenderer currentMesh;

	// Use this for initialization
	void Start () {
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
    
    public void GrowNewPlant(PlantType type)
    {
        switch (type)
        {
            case PlantType.Carrot:
                plant = new Carrot();
                currentMesh = meshRend[0];
                currentMesh.gameObject.SetActive(true);
                currentMesh.SetBlendShapeWeight(0, 100);
                break;
            case PlantType.EggPlant:
                plant = new EggPlant();
                currentMesh = meshRend[1];
                currentMesh.gameObject.SetActive(true);
                currentMesh.SetBlendShapeWeight(0, 100);
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
