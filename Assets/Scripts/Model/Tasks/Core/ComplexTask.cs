using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ComplexTask : Task {
	
	//List of Tasks to complete.
	public List<Task> ComplexTaskList;
	//Current Task to execute.
	public delegate void CurrentTask();
	//Constructor
	public ComplexTask(){
		ComplexTaskList = new List<Task>();
	}
	
	
	void ProcessComplexTask(){
		//If this task is not initialised, initialise it.
		if (ComplexTaskList[0].Valid){
			if (ComplexTaskList[0].Initialised){
				if (!ComplexTaskList[0].Finished ()){
					ComplexTaskList[0].Execute();                                    
				}
				else {
					Debug.Log ("ComplexTask - Task finished, removing!");
					ComplexTaskList.RemoveAt(0);
				}
			}
			else {
				ComplexTaskList[0].Initialise();
			}
		}
		else {
			Debug.LogWarning ("ComplexTask - Invalid Task detected, removing!");
			ComplexTaskList.RemoveAt(0);
		}
	}
	
	
	private bool SetupCheck(){
		if (Priority == 0 || TaskID == 0 || ThisGameObject == null){
			Debug.LogWarning("ComplexTask - Task was not setup correctly!");
			return false;
		}
		else {
			return true;
		}
	}
	
	public override bool Valid {
		get {
			if (!SetupCheck()){
				return false;
			}
			else {
				return true;
			}
		}
	}


    public override void Initialise ()
	{
		Initialised = true;
	}
	
	public override bool Finished (){
		if (ComplexTaskList.Count <= 0 || WasCancelled==true) {
			return true;
		}
		else {
			return false;
		}
	}
	
	//Execute() needs to be called in update of the TaskManager.
	public override void Execute(){
		ProcessComplexTask();
	}

    public override void Cancel()
    {
        foreach (Task t in ComplexTaskList) {
            t.Cancel();
        }

        WasCancelled = true;
    
    }
}