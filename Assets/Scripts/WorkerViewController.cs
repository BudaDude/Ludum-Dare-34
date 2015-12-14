using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[System.Serializable]
public class WorkerViewController : MonoBehaviour {
	TaskManager taskManager;
	public NavMeshAgent nav { get; protected set; }
    [SerializeField]
    public Text energyDisplay;
    public float energy = 100;
    private Animator anim;

    private bool hasFainted = false;

	// Use this for initialization
	void Awake () {
		nav = GetComponent<NavMeshAgent> ();
		taskManager = GetComponent<TaskManager> ();
        anim = GetComponent<Animator>();
        hasFainted = false;
	}

    public float GetEnergy()
    {
        return energy;
    }

    public void EndDay()
    {
        foreach(Task t in taskManager.taskList)
        {
            t.Cancel();
        }
        hasFainted = false;
        anim.SetBool("HasFainted", false);
        energy = 100;
        transform.position = new Vector3(1, 0, 1);
    }

	public void AddTask(Task task){
        if (!hasFainted)
        {
            taskManager.taskList.Add(task);
        }

	}
	
	// Update is called once per frame
	void Update () {
        energyDisplay.text = "Energy: "+energy;


        if (energy <= 0 && !hasFainted)
        {
            hasFainted = true;
            anim.SetBool("HasFainted",true);

            foreach (Task t in taskManager.taskList)
            {
                t.Cancel();
            }

        }
	}
}
