using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    private Plant plant;
    public Image image;

    int oldHealth = 0;
    int newHeath = 0;



    // Use this for initialization
    void Awake() {

        oldHealth = plant.Health;
        plant = transform.parent.GetComponent<PlantViewController>().plant;
    }
	
	// Update is called once per frame
	void Update () {

        newHeath = plant.Health;

        if (plant != null && newHeath != oldHealth)
        {
            Debug.Log("Plant Helath: "+plant.Health / 100f);
            image.rectTransform.anchorMax = new Vector2(newHeath/ 100f,1);
            oldHealth = newHeath;

        }
	
	}
}
