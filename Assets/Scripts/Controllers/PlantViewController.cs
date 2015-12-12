using UnityEngine;
using System.Collections;

public class PlantViewController : MonoBehaviour {

    private Plant plant = new Carrot();

    public SkinnedMeshRenderer meshRend;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Grow", 2.0f, 5);
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
