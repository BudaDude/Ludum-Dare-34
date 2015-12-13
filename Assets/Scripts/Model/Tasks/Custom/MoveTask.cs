using UnityEngine;
using System.Collections;
using System;

public class MoveTask : Task {
	
	//The Game World Coordinates for the NavMeshAgent to head towards.
	public Vector3 DestinationPosition { get; set; }
	//Agent reference.
	public NavMeshAgent Agent;
    public Animator Anim;
	
	//Constructor
	public MoveTask(){
		Initialised = false;
        WasCancelled = false;
        Debug.Log(WasCancelled);
	}
	
	//Called to check if the task has been setup correctly, returns true if everything seems right.
	private bool SetupCheck(){
		if (Agent == null || Priority == 0 || TaskID == 0 || ThisGameObject == null || Anim == null){
			Debug.LogWarning("MoveTask - Task was not setup correctly!");
			return false;
		}
		else {
			return true;
		}
	}
	
	//This tasks implementation of Valid() simply relays the output of the function SetupCheck() waste of a call right now but maybe useful for later Tasks?
	public override bool Valid{
		get {
			if (!SetupCheck())
            {
				return false;
			}
			else {
				return true;
			}
		}
	}


    //This Tasks implementation of Initilise() simply sets the NavMeshAgents 'DestinationPosition'.
    public override void Initialise (){
		Agent.SetDestination(DestinationPosition);
		//IMPORTANT that this is now set to true. The TaskManager relies on this variable.
		Initialised = true;
	}
	
	//Execute() needs to be called in update of the TaskManager. Setting the destination doesn't need to be done in each update,
	//but might need to change later to check for updates to the destination. As it is, this Task will only move to a fixed point.
	public override void Execute(){
        Anim.SetBool("Walking",true);
	}
	
	bool HasReachedDestination(){
		//IMPORTANT! If the agent is still calculating its route then leave it alone or program flow will be fucked.
		if (Agent.hasPath){
			//If the path is NOT complete or totally invalid, return false.
			if (Agent.pathStatus == NavMeshPathStatus.PathInvalid || Agent.pathStatus == NavMeshPathStatus.PathPartial){
				Debug.Log ("MoveTask - Destination Un-Reachable!");
                //TODO find a way to invalidate this task is path is done. Marking it as finished may have problems in the future
				return true;
			}
			//If the path is complete (valid) and it is within 0.1f of the target then return true.
			if (Agent.pathStatus == NavMeshPathStatus.PathComplete && Agent.remainingDistance < 0.1f){
				Debug.Log ("MoveTask - Destination Reached! with a remaining distance of "+Agent.remainingDistance);
                Agent.Stop();
                Agent.ResetPath();
                return true;
			}
			return false;
		}
		//Otherwise, just return false and allow the agent to continue processing or moving.
		else return false;    
	}
	
	//This Task defines if it is finished purely by the return of HasReachedDestination(). Note 'HasReachedDe...' currently cannot tell if it hasnt reached
	//its destination because it is blocked or unreachable, possibly need to just set this Task to invalid if the spot is blocked and allow the AI to set
	//itself another Task when needed.
	public override bool Finished(){
		if (HasReachedDestination() || WasCancelled==true) {
            Anim.SetBool("Walking", false);
            
            return true;
		}
		else return false;
	}

    public override void Cancel()
    {
        
        if (Initialised)
        {
            Anim.SetBool("Walking", false);
            Agent.ResetPath();
            
        }
        WasCancelled = true;

    }
}