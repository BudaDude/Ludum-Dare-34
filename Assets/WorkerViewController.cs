using UnityEngine;
using System.Collections;

public class WorkerViewController : MonoBehaviour {
	TaskManager taskManager;
	NavMeshAgent nav;
    public float energy;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		taskManager = GetComponent<TaskManager> ();
		Invoke ("MoveTo", 2f);
	}

	public void MoveTo(Vector3 position){
		print (position);
		taskManager.taskList.Add (new MoveTask () {
			Agent = nav,
			TaskID = 1,
			Priority = 1,
			ThisGameObject = this.gameObject,
			DestinationPosition = position
		});
	}
	
	// Update is called once per frame
	void Update () {
	}
}
