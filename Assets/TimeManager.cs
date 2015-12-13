using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void EndDay()
    {
        foreach (PlantViewController plant in GameObject.FindObjectsOfType<PlantViewController>())
        {
            plant.Grow();
            plant.plant.WorkedToday = false;
        }
        foreach (WorkerViewController worker in GameObject.FindObjectsOfType<WorkerViewController>())
        {
            worker.EndDay();
        }


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
