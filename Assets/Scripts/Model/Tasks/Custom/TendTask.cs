using UnityEngine;
using System.Collections;

public class TendTask : Task
{


    public Plant WorkPlant;

    public WorkerViewController Worker;

    float workAmount;
    float workRequired = .5f;
    //Constructor
    public TendTask()
    {
        Initialised = false;
    }

    //Called to check if the task has been setup correctly, returns true if everything seems right.
    private bool SetupCheck()
    {
        if (WorkPlant == null || Priority == 0 || TaskID == 0 || ThisGameObject == null|| Worker == null)
        {
            Debug.LogWarning("TendTask - Task was not setup correctly!");
            return false;
        }
        else
        {
            return true;
        }
    }

    //This tasks implementation of Valid() simply relays the output of the function SetupCheck() waste of a call right now but maybe useful for later Tasks?
    public override bool Valid
    {
        get
        {
            if (!SetupCheck() || Worker.energy <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    //This Tasks implementation of Initilise() simply sets the NavMeshAgents 'DestinationPosition'.
    public override void Initialise()
    {
        //IMPORTANT that this is now set to true. The TaskManager relies on this variable.
        Initialised = true;
    }

    public override void Execute()
    {
        workAmount += Time.deltaTime;

        if (workAmount >= workRequired)
        {
            WorkPlant.AddHealth(1);
            Worker.energy -= 1;
            workAmount = 0;
        }

    }

    bool WorkisDone()
    {
        if (WorkPlant.Health <= 100)
        {

            return false;
        }
        else
        {
            return true;
        }
     
    }

    public override bool Finished()
    {
        if (WorkisDone())
        {
            return true;
        }
        else return false;
    }


}