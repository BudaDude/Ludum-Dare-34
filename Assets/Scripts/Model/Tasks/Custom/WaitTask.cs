using UnityEngine;
using System.Collections;
using System;

public class WaitTask : Task {

	public float timeLength;
	private float timeElapsed;

	public WaitTask(){
		timeElapsed = 0;
		Initialised = false;
	}

	private bool SetupCheck(){
		if (timeLength == null || Priority == 0 || TaskID == 0 || ThisGameObject == null){
			Debug.LogWarning("WaitTask - Task was not setup correctly!");
			return false;
		}
		else {
			return true;
		}
	}

	public override bool Valid {
		get {
			return SetupCheck();

		}
	}
	
	public override void Initialise ()
	{

		Initialised = true;
		Debug.Log ("WaitTask - waiting for " + timeLength + " seconds");
	}
	
	public override bool Finished (){
		return (timeElapsed >= timeLength);
	}
	
	//Execute() needs to be called in update of the TaskManager.
	public override void Execute(){
			timeElapsed += Time.deltaTime;

	}
}
