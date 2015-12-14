using UnityEngine;
using System.Collections;

public class Bunny : MonoBehaviour {
    public PlantViewController plantTarget;
    private NavMeshAgent agent;
    private Animator anim;
    private WorkerViewController worker;

    public bool runningAway;

    private float eatTimer = 0;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        worker = FindObjectOfType<WorkerViewController>();

        
    }
    void Awake()
    {
        runningAway = false;
        eatTimer = 0; 
    }

    void GoToPlant()
    {
        foreach( PlantViewController plantvc in GameObject.FindObjectsOfType<PlantViewController>())
        {
            if (plantvc.plant != null)
            {
                plantTarget = plantvc;
                agent.SetDestination(plantTarget.transform.position);
                break;
            }
        }
    }

    void RunAway()
    {
        agent.ResetPath();
        Debug.Log("RUN AWEAY");
        agent.SetDestination(new Vector3(10,0,30));
        agent.Resume();
    }

    void NomPlant()
    {
        eatTimer += Time.deltaTime;
        if (eatTimer > 1.5)
        {
            plantTarget.plant.DamageHealth(1);
            eatTimer = 0;
        }

    }

    // Update is called once per frame
    void Update () {

        if (runningAway && Vector3.Distance(transform.position, agent.pathEndPosition )< 1.0f){
            gameObject.SetActive(false);
        }


            //run away from player
            if (Vector3.Distance(transform.position, worker.transform.position)  < 2.0 && !runningAway)
        {
            RunAway();
            runningAway = true;
        }else

            if (plantTarget != null)
        {
            if (plantTarget.plant != null)
            {

                if (Vector3.Distance(transform.position, plantTarget.transform.position) < .5f)
                {
                    NomPlant();
                }
            }
            else
            {
                GoToPlant();
            }
        }
        else
        {
            GoToPlant();
        }
    }
}
