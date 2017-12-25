using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public KeyCode up = KeyCode.W, down = KeyCode.S, left = KeyCode.A, right = KeyCode.D;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(up))
		{
			transform.position += Vector3.up;
			transform.rotation = new Quaternion(0, 0, 1, -1);
		}
		if (Input.GetKey(down))
		{
			transform.position += Vector3.down;
			transform.rotation = new Quaternion(0, 0, 1, 1);
		}
		if (Input.GetKey(left))
		{
			transform.position += Vector3.left;
			transform.rotation = new Quaternion(0, 0, 0, 0);
		}
		if (Input.GetKey(right))
		{
			transform.position += Vector3.right;
			transform.rotation = new Quaternion(0, 0, 1, 0);
		}
	}
}
