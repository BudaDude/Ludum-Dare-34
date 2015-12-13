using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {
    public float time;

    bool fadeToBlack = false;

	// Use this for initialization
	void Start () {
	
	}

    void OnGUI()
    {
        if (fadeToBlack)
        {
            
        }
    }
    public void FadeToBlack()
    {
        fadeToBlack = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
