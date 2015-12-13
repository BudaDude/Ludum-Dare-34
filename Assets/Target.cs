using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
    


    void FixedUpdate()
    {
        Vector3 workerPos = GameObject.FindObjectOfType<WorkerViewController>().transform.position;


        if (Vector3.Distance(transform.position,workerPos) < 1.5f)
        {
            gameObject.SetActive(false);
        }
    }

}
