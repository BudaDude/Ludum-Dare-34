using UnityEngine;
using System.Collections;

public class FaceTheCamera : MonoBehaviour {

    private Camera camera;

    void Awake()
    {
        camera = Camera.main;
    }

	
	// Update is called once per frame
	void Update () {
        transform.LookAt(transform.position + Vector3.forward, camera.transform.rotation * Vector3.up);
	}
}
