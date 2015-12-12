using UnityEngine;
using System.Collections;

public class MouseControls : MonoBehaviour {

	WorkerViewController worker;

	// Use this for initialization
	void Start () {
		worker = GameObject.FindObjectOfType<WorkerViewController> ().GetComponent<WorkerViewController> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)){
				worker.MoveTo(hit.point);
			}
		}
	
	}
}
