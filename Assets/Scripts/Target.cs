using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public Task associatedTask;





    void FixedUpdate()
    {
        if (associatedTask != null)
        {
            Debug.Log(associatedTask);
            if (associatedTask.Finished() || associatedTask.Valid == false)
            {
                associatedTask = null;
                gameObject.SetActive(false);
            }
        }
    }

}
