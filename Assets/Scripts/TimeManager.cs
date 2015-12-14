using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public GameObject fadeScreenObject;

    public int day = 0;

    public Bunny[] bunnies;

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
        day++;
        fadeScreenObject.GetComponent<Animator>().SetBool("FadedToBlack", false);

        if (Random.value <= .20f)
        {
            bunnies[Random.Range(0, bunnies.Length)].gameObject.SetActive(true);
            bunnies[Random.Range(0, bunnies.Length)].gameObject.SetActive(true);
            bunnies[Random.Range(0, bunnies.Length)].gameObject.SetActive(true);
        }


        yield return new WaitForSeconds(1);
        fadeScreenObject.SetActive(false);
        

    }

    // Update is called once per frame
    void Update () {
	
	}
}
