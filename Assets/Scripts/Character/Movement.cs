using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public KeyCode up = KeyCode.W, down = KeyCode.S, left = KeyCode.A, right = KeyCode.D;
	public float speed = 0.1F, minZoom = 2F, maxZoom = 20F, zoom = 2F, zoomFactor = -1F;
	public Camera camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 delta = Vector3.zero;
		if(Input.GetKey(up))
		{
			delta += Vector3.up;
			transform.rotation = new Quaternion(0, 0, 1, -1);
		}
		if (Input.GetKey(down))
		{
			delta += Vector3.down;
			transform.rotation = new Quaternion(0, 0, 1, 1);
		}
		if (Input.GetKey(left))
		{
			delta += Vector3.left;
			transform.rotation = new Quaternion(0, 0, 0, 0);
		}
		if (Input.GetKey(right))
		{
			delta += Vector3.right;
			transform.rotation = new Quaternion(0, 0, 1, 0);
		}
		transform.position += delta.normalized * speed;

		zoom += Input.mouseScrollDelta.y * zoomFactor;
		zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
		camera.transform.position = transform.position + Vector3.back * zoom;
	}
}
