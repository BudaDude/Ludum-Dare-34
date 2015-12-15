using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Inventory inventory;

    public GameObject winScreen;

	// Use this for initialization
	void Start () {
        inventory = GetComponent<Inventory>();
	}


    public void WinGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {

        if (inventory.money >= 200)
        {
            winScreen.SetActive(true);
        }
	
	}
}
