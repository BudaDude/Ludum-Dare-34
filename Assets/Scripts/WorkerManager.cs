using UnityEngine;
using System.Collections;

public class WorkerManager : MonoBehaviour {
    WorkerViewController worker;
    TargetManager targetMan;

    ComplexTask ct;
    void Awake()
    {
        targetMan = GameObject.FindObjectOfType<TargetManager>().GetComponent<TargetManager>();
        worker = GameObject.FindObjectOfType<WorkerViewController>().GetComponent<WorkerViewController>();
    }


    public void AssignTask(GameObject target)
    {
        if (target.tag == "Plant")
        {
            Plant plant = target.GetComponent<PlantViewController>().plant;
            Debug.Log(plant);

            if (plant.WorkedToday == false)
            {
                switch (plant.GrowthState)
                {
                    case Plant.PlantGrowthState.Ripe:
                        break;
                    default:
                        ct = new ComplexTask()
                        {
                            Priority = 3,
                            ThisGameObject = worker.gameObject
                        };
                        Debug.Log(ct);

                        ct.ComplexTaskList.Add(new MoveTask()
                        {
                            Priority = 1,
                            ThisGameObject = worker.gameObject,
                            Agent = worker.GetComponent<NavMeshAgent>(),
                            DestinationPosition = target.transform.position,
                            Anim = worker.GetComponent<Animator>()
                        });
                        ct.ComplexTaskList.Add(new TendTask()
                        {
                            Priority = 2,
                            ThisGameObject = worker.gameObject,
                            Worker = worker,
                            WorkPlant = plant,
                            Anim = worker.GetComponent<Animator>()
                        });

                        worker.AddTask(ct);
                        GameObject go = targetMan.GetPooledTarget();
                        go.transform.position = target.transform.position;
                        go.SetActive(true);
                        go.GetComponent<Target>().associatedTask = ct;

                        break;
                }
            }
        }
        else
        {
            MoveTask mt = new MoveTask()
            {
                Priority = 3,
                ThisGameObject = worker.gameObject,
                Agent = worker.GetComponent<NavMeshAgent>(),
                DestinationPosition = target.transform.position,
                Anim = worker.GetComponent<Animator>()
            };

            worker.AddTask(mt);
            GameObject go = targetMan.GetPooledTarget();
            go.transform.position = target.transform.position;
            go.SetActive(true);
            go.GetComponent<Target>().associatedTask = mt;

        }
        
    }






	
}
