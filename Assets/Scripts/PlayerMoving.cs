using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerInputs;

public class PlayerMoving : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;
	public GameObject player;
	public Camera camera;

	Rigidbody rigidbody;

	Vector3 upVector;
	Vector3 rightVector;
	Vector3 direction;
	Vector3 lookDirection;

	// Use this for initialization
	void Start ()
	{
		direction.Set(0, 0, 0);
		upVector.Set(0, 1, 0);
		rightVector.Set(1, 0, 0);
		ControllerPluginWrapper.Initiate();
		rigidbody = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ControllerPluginWrapper.UpdateControllers();

		direction.Set(0, 0, 0);
		lookDirection.Set(0, 0, 0);

		if (!ControllerPluginWrapper.LStick_InDeadZone(0))
		{
			direction.x = ControllerPluginWrapper.LeftStick_X(0);
			direction.z = ControllerPluginWrapper.LeftStick_Y(0);
			Debug.Log(direction);
		}

		if (!ControllerPluginWrapper.RStick_InDeadZone(0))
		{
			lookDirection.x = ControllerPluginWrapper.RightStick_X(0);
			lookDirection.z = ControllerPluginWrapper.RightStick_Y(0);
		}

		if (ControllerPluginWrapper.GetButtonPressed(0, 0))
		{
			if (rigidbody.velocity.y < 0.01f && rigidbody.velocity.y > -0.01f) 
			{
				rigidbody.AddForce(new Vector3(0, 17.5f, 0), ForceMode.Impulse);
			}
		}

		player.transform.Translate(direction * speed * Time.deltaTime);
		player.transform.Rotate(upVector * lookDirection.x * rotationSpeed);
		camera.transform.Rotate(rightVector * -lookDirection.z * rotationSpeed);

		ControllerPluginWrapper.RefreshStates();
	}
}