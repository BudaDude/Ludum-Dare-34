using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseControls : MonoBehaviour {

    public int boundary = 50;
    public float panSpeed = 5;

    private int screenWidth;
    private int screenHeight;
    private Camera camera;

    public GameObject actionMenuObject;

    TargetManager targetMan;

    WorkerManager workMan;


	// Use this for initialization
	void Start () {
        workMan = GameObject.FindObjectOfType<WorkerManager>().GetComponent<WorkerManager>();
        camera = Camera.main;
        screenHeight = camera.pixelHeight;
        screenWidth = camera.pixelWidth;
        targetMan = GameObject.FindObjectOfType<TargetManager>().GetComponent<TargetManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        Vector3 camerPos = camera.transform.position;
        //
        // Move Screen when mouse is out of bounds
        //

        //horizantol

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.mousePosition.x > screenWidth - boundary)
            {
                camerPos.x += panSpeed * Time.deltaTime;
                camerPos.x = Mathf.Clamp(camerPos.x, -25, 25);
            }
            if (Input.mousePosition.x < boundary)
            {
                camerPos.x -= panSpeed * Time.deltaTime;
                camerPos.x = Mathf.Clamp(camerPos.x, -25, 25);
            }
            //Vertical
            if (Input.mousePosition.y > screenHeight - boundary)
            {
                camerPos.z += panSpeed * Time.deltaTime; // move on +Z axis
                camerPos.z = Mathf.Clamp(camerPos.z, -25, 25);
            }
            if (Input.mousePosition.y < 0 + boundary)
            {
                camerPos.z -= panSpeed * Time.deltaTime; // move on -Z axis
                camerPos.z = Mathf.Clamp(camerPos.z, -25, 25);
            }

            camera.transform.position = camerPos;
        }



        if (Input.GetMouseButtonUp (1)) {
			Ray ray = Camera.main.ScreenPointToRay(mousePos);
			RaycastHit hit;

            actionMenuObject.SetActive(false);

            if (Physics.Raycast(ray, out hit)){

                if (hit.collider.tag == "Target")
                {

                    hit.collider.GetComponent<Target>().associatedTask.Cancel();
                }
                else if (hit.collider.tag == "Plant")
                {
                    Debug.Log("THIS IS HAPPENING");
                    if (hit.collider.gameObject.GetComponent<PlantViewController>().plant == null)
                    {

                        actionMenuObject.GetComponent<RectTransform>().position = mousePos;
                        actionMenuObject.SetActive(true);
                        for (int i = 0; i < 1; i++)
                        {
                            actionMenuObject.GetComponentsInChildren<Button>()[i].onClick.AddListener(() => workMan.PlantNewPlant(i, hit.collider.gameObject.GetComponent<PlantViewController>()));
                        }
                    }
                    else
                    {
                        workMan.AssignTask(hit.collider.gameObject);
                    }


                }
                else
                {
                    workMan.AssignTask(hit.collider.gameObject);

                }

                
            }
		}
	
	}
}
