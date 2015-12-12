using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}

    public void MoveTarget(Vector3 pos)
    {
        target.transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
