using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//custom controller namespace
using ControllerInputs;

public class PlayerMoving : MonoBehaviour
{
	//variables for player movement and rotation speed
	public float speed; 
	public float rotationSpeed;
	
	//creates player object
	public GameObject player;

	//variable of type camera
	public Camera camera;

	//variable of type rigidbody
	Rigidbody rigidbody;

	//rotation for y and x axis
	Vector3 upVector;
	Vector3 rightVector;

	//gets direction from controller inputs 
	Vector3 direction;
	Vector3 lookDirection;

	// Use this for initialization
	void Start ()
	{
		//initialzing variables
		direction.Set(0, 0, 0);
		upVector.Set(0, 1, 0);
		rightVector.Set(1, 0, 0);
		ControllerPluginWrapper.Initiate();
		rigidbody = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//updates controller inputs 
		ControllerPluginWrapper.UpdateControllers();

		//resets player movement when stick is not being used 
		direction.Set(0, 0, 0);
		lookDirection.Set(0, 0, 0);

		//gets the x and y values from the controller analog sticks 
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
		
		//equations for movement and rotation
		player.transform.Translate(direction * speed * Time.deltaTime);
		player.transform.Rotate(upVector * lookDirection.x * rotationSpeed);
		camera.transform.Rotate(rightVector * -lookDirection.z * rotationSpeed);

		//save controller states as previous actions for next frame
		ControllerPluginWrapper.RefreshStates();
	}
}