using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float moveSpeed = 10f;
	[SerializeField] private float rotSpeed = 10f;
	
	// Update is called once per frame
	void Update () {
		Vector3 offset = Vector3.zero;
		if (Input.GetKey("w"))
		{
			offset += Vector3.forward;
		}
		if (Input.GetKey("s"))
		{
			offset += Vector3.back;
		}
		if (Input.GetKey("a"))
		{
			offset += Vector3.left;
		}
		if (Input.GetKey("d"))
		{
			offset += Vector3.right;
		}
		offset = Vector3.Normalize(offset) * moveSpeed * Time.deltaTime;
		transform.Translate(offset, Space.World);
		if (offset.magnitude > 0)
		{
			Quaternion rotDir = Quaternion.LookRotation(offset);
			transform.rotation = Quaternion.RotateTowards( transform.rotation, rotDir, rotSpeed * Time.deltaTime );
		}
	}
}
