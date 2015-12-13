using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    Vector3 workerPos;

    void Awake()
    {
        workerPos = GameObject.FindObjectOfType<WorkerViewController>().transform.position;
    }



    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position,workerPos) < 1.5f)
        {
            gameObject.SetActive(false);
        }
    }

}
