using UnityEngine;
using System.Collections;

public class WorkerViewController : MonoBehaviour {
	TaskManager taskManager;
	public NavMeshAgent nav { get; protected set; }
    public float energy = 100;

	// Use this for initialization
	void Awake () {
		nav = GetComponent<NavMeshAgent> ();
		taskManager = GetComponent<TaskManager> ();
	}

    public void EndDay()
    {
        energy = 100;
        transform.position = new Vector3(1, 0, 1);
    }

	public void AddTask(Task task){
        taskManager.taskList.Add(task);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
