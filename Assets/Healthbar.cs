using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    private Plant plant;
    public Image image;



	// Use this for initialization
	void Awake() {
        
	}
	
	// Update is called once per frame
	void Update () {
        plant = transform.parent.GetComponent<PlantViewController>().plant;
        if (plant != null)
        {
            Debug.Log("Plant Helath: "+plant.Health / 100f);
            image.rectTransform.anchorMax = new Vector2(plant.Health / 100f,1);

        }
	
	}
}
