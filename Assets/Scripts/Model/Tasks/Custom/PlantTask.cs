using UnityEngine;
using System.Collections;
using System;

public class PlantTask : Task {
    public PlantViewController WorkPlant;

    public WorkerViewController Worker;
    public Animator Anim;

    public PlantType PlantToGrow;

    float planttingProgess = 0;

    //Constructor
    public PlantTask()
    {
        Initialised = false;

    }

    //Called to check if the task has been setup correctly, returns true if everything seems right.
    private bool SetupCheck()
    {
        if (WorkPlant == null || Priority == 0 || TaskID == 0 || ThisGameObject == null || Worker == null || Anim == null || PlantToGrow == null)
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
            if (!SetupCheck() || Worker.energy <= 0 || WasCancelled == true)
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
        Debug.Log(ThisGameObject.name);
    }

    public override void Execute()
    {

        Anim.SetBool("Working", true);


    }

    bool WorkisDone()
    {
        if (planttingProgess < 5)
        {
            planttingProgess += Time.deltaTime;

            return false;
        }
        else
        {
            Debug.Log(PlantToGrow);
            WorkPlant.GrowNewPlant(PlantToGrow);
            return true;
        }
        
    }

    public override bool Finished()
    {
        if (WorkisDone())
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
