using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	// Makes the camera follow a target at a smooth speed.
	// Attached to the Main Camera object.

	public Transform target;
	public float camSpeed;

	void Start () 
	{
        target = GameObject.Find("Player").transform;
	}

	void FixedUpdate () 
	{
        if (target) 
		{
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0,0,-10), camSpeed);
		}
	}
}
