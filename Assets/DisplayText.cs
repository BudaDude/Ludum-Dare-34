using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayText : MonoBehaviour {

    public string preText = "";
    private Text textUI;
    public UnityEvent variable;


	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        textUI.text = preText + variable;
	}
}
