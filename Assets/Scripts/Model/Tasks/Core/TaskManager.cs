using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class TaskManager : MonoBehaviour {
	public List<Task> taskList = new List<Task>();
	

	
	void SortListByPriority(){
		if (taskList.Count > 0){
			taskList = taskList.OrderBy(x => -x.Priority ).ThenBy(x=>x.TaskID).ToList();
		}
	}

    public void AddTask(Task task)
    {

    }
	
	void ProcessList(){
		//IF this Task decides it is invalid, then delete it.
		if (taskList[0].Valid){
			//If its not initialised, intialise it.
			if (taskList[0].Initialised){
				//If the task isn't finished, execute it.
				if (!taskList[0].Finished ()){
					taskList[0].Execute();                
				}
				else {
					Debug.Log ("TaskManager - Task finished, removing!");
					taskList.RemoveAt(0);

                    if (taskList.Count > 1)
                    {
                        SortListByPriority();
                    }
                }
			}
			else {
				taskList[0].Initialise();
			}
		}
		else {
			Debug.LogWarning ("TaskManager - Invalid Task detected, removing!");
			taskList.RemoveAt(0);
		}
	}
	
	void Update(){

		if (taskList.Count > 0){
			ProcessList();
		}
		else {
			Debug.Log ("TaskManager - TaskList is empty!");
		}
	}
	

}
