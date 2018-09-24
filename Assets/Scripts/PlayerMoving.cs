using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerInputs;

public class PlayerMoving : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;
	public Camera camera;
	Vector3 direction;
	Vector3 lookDirection;

	// Use this for initialization
	void Start ()
	{
		direction = new Vector3(0, 0, 0);
		ControllerPluginWrapper.Initiate();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ControllerPluginWrapper.UpdateControllers();

		direction = new Vector3(0, 0, 0);
		lookDirection = new Vector3(0, 0, 0);

		if (!ControllerPluginWrapper.LStick_InDeadZone(0))
		{
			direction.x = ControllerPluginWrapper.LeftStick_X(0);
			direction.z = ControllerPluginWrapper.LeftStick_Y(0);
		}

		if (!ControllerPluginWrapper.RStick_InDeadZone(0))
		{
			lookDirection.x = ControllerPluginWrapper.RightStick_X(0);
			lookDirection.z = ControllerPluginWrapper.RightStick_Y(0);
		}

		camera.transform.Translate(direction * speed * Time.deltaTime);
		camera.transform.Rotate(Vector3.up * lookDirection.x * rotationSpeed);

		ControllerPluginWrapper.RefreshStates();
	}
}
