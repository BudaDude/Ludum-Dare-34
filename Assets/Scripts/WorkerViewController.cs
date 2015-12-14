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
    private bool hasYawned = false;

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
        energy = 100;
        hasFainted = false;
        anim.SetBool("HasFainted", false);
        anim.SetBool("Working", false);
        anim.SetBool("Walking", false);

        transform.position = new Vector3(-18, 0, 0);
        Camera.main.transform.position = new Vector3(-18, 8, -5);
        hasYawned = false;
    }

	public void AddTask(Task task){
        if (!hasFainted)
        {
            taskManager.taskList.Add(task);
        }

	}
	
	// Update is called once per frame
	void Update () {
        energyDisplay.text = "Energy: "+(int)energy;


        if (energy <= 0 && !hasFainted)
        {
            hasFainted = true;
            anim.SetBool("HasFainted",true);

            foreach (Task t in taskManager.taskList)
            {
                t.Cancel();
            }

        }

        if (energy <= 25 && !hasYawned)
        {
            anim.SetTrigger("Sleepy");
            hasYawned = true;
        }
    }
}
