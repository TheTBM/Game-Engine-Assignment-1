using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerInputs;

public class ObjectSpawning : MonoBehaviour
{
	public GameObject player;
	public GameObject Box;
	GameObject copy;
	float cooldown = 0.0f;

	// Use this for initialization
	void Start ()
	{
		ControllerPluginWrapper.Initiate();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ControllerPluginWrapper.UpdateControllers();

		if (cooldown > 0.0f)
		{
			cooldown -= Time.deltaTime;
		}

		if (ControllerPluginWrapper.GetButtonPressed(0, 9) && (cooldown <= 0.0f))
		{
			copy = Instantiate(Box, player.transform.position + player.transform.forward * 2.0f, player.transform.rotation) as GameObject;
			cooldown = 0.5f;
		}

		if (ControllerPluginWrapper.getButtonPressed())

		ControllerPluginWrapper.RefreshStates();
	}
}
