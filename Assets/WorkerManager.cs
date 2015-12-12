using UnityEngine;
using System.Collections;

public class WorkerManager : MonoBehaviour {
    WorkerViewController worker;


    void Awake()
    {
        worker = gameObject.GetComponent<WorkerViewController>();
    }


    public void AssignTask(GameObject target)
    {
        if (target.tag == "Plant")
        {
            Plant plant = gameObject.GetComponent<Plant>();

            if (plant.WorkedToday == false)
            {
                switch (plant.GrowthState)
                {
                    case Plant.PlantGrowthState.Ripe:
                        break;
                    default:
                        ComplexTask ct = new ComplexTask();

                        ct.ComplexTaskList.Add(new MoveTask
                        {
                            Priority = 1,
                            TaskID = 1,
                            Agent = worker.nav,
                            DestinationPosition = gameObject.transform.position
                        });

                        worker.AddTask(ct);
                        break;
                }
            }
        }
    }






	
}
