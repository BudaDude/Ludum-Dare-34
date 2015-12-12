using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}

    public void MoveTarget(Vector3 pos)
    {
        target.transform.position = new Vector3(Mathf.Round(pos.x), 0, Mathf.Round(pos.z)) ;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
