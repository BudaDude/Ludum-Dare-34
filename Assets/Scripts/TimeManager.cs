using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public GameObject fadeScreenObject;

	// Use this for initialization
	void Start () {
	
	}


    public void EndDay()
    {
        StartCoroutine(EndTheDay());
    }

    public IEnumerator EndTheDay()
    {
        fadeScreenObject.SetActive(true);
        fadeScreenObject.GetComponent<Animator>().SetBool("FadedToBlack", true);
        yield return new WaitForSeconds(1);
        foreach (PlantViewController plant in GameObject.FindObjectsOfType<PlantViewController>())
        {
            plant.Grow();
        }
        foreach (WorkerViewController worker in GameObject.FindObjectsOfType<WorkerViewController>())
        {
            worker.EndDay();
        }

        fadeScreenObject.GetComponent<Animator>().SetBool("FadedToBlack", false);
        yield return new WaitForSeconds(1);
        fadeScreenObject.SetActive(false);
        

    }

    // Update is called once per frame
    void Update () {
	
	}
}
