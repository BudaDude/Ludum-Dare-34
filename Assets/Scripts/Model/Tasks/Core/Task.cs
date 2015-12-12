using UnityEngine;
using System.Collections;


public abstract class Task {
	//Returns true if the conditions declared by the Task are met.
	public abstract bool Valid { get; }
	
	//Returns true if the Task has had Initialise() called.
	public bool Initialised { get; set; }
	
	//Used for sorting Tasks.
	public int Priority { get; set; }
	public int TaskID { get; set; }
	
	//Reference to the GameObject that is using this Task. Required!
	public GameObject ThisGameObject { get; set; }
	
	//Constructor.
	public Task(){
		Initialised = false;
	}
	
	//To be called before Execute or the Task will (probably) fail, depending on whether the task needs to initialise at all.
	public abstract void Initialise();
	
	//Allows the TaskManager to check if a task has finished, each task defines it's own rules as to what finished means.
	public abstract bool Finished();
	
	//Execute() needs to be called in update of the TaskManager. This will probably hold the majority of the game logic for a task.
	public abstract void Execute();

}
