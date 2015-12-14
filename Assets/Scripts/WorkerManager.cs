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


    public void PlantNewPlant(int plantType, PlantViewController plantVC)
    {
        ct = new ComplexTask()
        {
            Priority = 3,
            ThisGameObject = worker.gameObject
        };
        ct.ComplexTaskList.Add(new MoveTask()
        {
            Priority = 1,
            ThisGameObject = gameObject,
            Agent = worker.GetComponent<NavMeshAgent>(),
            DestinationPosition = plantVC.transform.position,
            Anim = worker.GetComponent<Animator>()
        });

        ct.ComplexTaskList.Add(new PlantTask
        {
            Priority = 2,
            ThisGameObject = gameObject,
            Worker = worker,
            Anim = worker.GetComponent<Animator>(),
            PlantToGrow = (PlantType)plantType,
            WorkPlant = plantVC

        });


        worker.AddTask(ct);

        GameObject go = targetMan.GetPooledTarget();
        go.transform.position = plantVC.transform.position;
        go.GetComponent<Target>().associatedTask = ct;
        go.SetActive(true);



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
            go.GetComponent<Target>().associatedTask = mt;
            go.SetActive(true);
            


        }
        
    }






	
}
