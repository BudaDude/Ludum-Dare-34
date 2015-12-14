using UnityEngine;
using System.Collections;
using System;

public class HarvestTask : Task
{


    public PlantViewController WorkPlantVC;

    public WorkerViewController Worker;
    public Animator Anim;

    float workAmount;
    float workRequired = .5f;
    private float harvestingProgress;

    //Constructor
    public HarvestTask()
    {
        Initialised = false;
    }

    //Called to check if the task has been setup correctly, returns true if everything seems right.
    private bool SetupCheck()
    {
        if (WorkPlantVC == null || Priority == 0 || TaskID == 0 || ThisGameObject == null|| Worker == null || Anim == null)
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
            if (!SetupCheck() || Worker.energy <= 0 || WasCancelled==true)
            {
                Anim.SetBool("Working", false);
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

    }

    bool WorkisDone()
    {
        Anim.SetBool("Working", true);
        if (harvestingProgress < 6)
        {
            harvestingProgress += Time.deltaTime;

            return false;
        }
        else
        {
            Worker.energy -= 5;
            WorkPlantVC.Harvest();
            return true;
        }

    }

    public override bool Finished()
    {
        if (WorkisDone()|| WasCancelled==true)
        {
            Anim.SetBool("Working", false);
            return true;
        }
        else return false;
    }

    public override void Cancel()
    {
        WasCancelled = true;
    }
}