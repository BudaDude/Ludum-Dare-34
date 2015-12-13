using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    private PlantViewController plantView;
    public Image image;

    int oldHealth = 0;
    int newHeath = 0;



    // Use this for initialization
    void Start() {

        
        plantView = transform.parent.GetComponent<PlantViewController>();
    }
	
	// Update is called once per frame
	void Update() {

        

        if (plantView.plant != null)
        {
            newHeath = plantView.plant.Health;
            if (newHeath != oldHealth)
            {

                image.rectTransform.anchorMax = new Vector2(newHeath / 100f, 1);
                oldHealth = newHeath;
            }


        }
        else
        {

        }
	
	}
}
