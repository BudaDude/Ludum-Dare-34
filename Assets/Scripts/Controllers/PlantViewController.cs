using UnityEngine;
using System.Collections;

public class PlantViewController : MonoBehaviour {

    private Plant plant;

    public MeshRenderer meshRend;

	// Use this for initialization
	void Start () {
	
	}
    
    public void GrowNewPlant(string type)
    {
        switch (type)
        {
            case "carrot":
                plant = new Carrot();
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
