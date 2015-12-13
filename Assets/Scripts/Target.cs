using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public Task associatedTask;

    private TaskManager taskMan;

    void Awake()
    {
        taskMan = FindObjectOfType<TaskManager>().GetComponent<TaskManager>();
    }

    void FixedUpdate()
    {
        if (associatedTask != null)
        {
            if (!taskMan.taskList.Contains(associatedTask) || associatedTask.WasCancelled)
            {
                Debug.Log("Removing target");
                associatedTask = null;
                gameObject.SetActive(false);
            }
        }
    }

}
