using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerInputs;
using CommandPattern;

public class ObjectSpawning : MonoBehaviour
{
	public GameObject player;
	public GameObject Box;
	public GameObject Tree;
	public GameObject Crystals;
	public GameObject Tower;
	GameObject copy;
	float cooldown = 0.5f;

	// Use this for initialization
	void Start ()
	{
		ControllerPluginWrapper.Initiate();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ControllerPluginWrapper.UpdateControllers();

		//if (cooldown > 0.0f)
		//{
		//	cooldown -= Time.deltaTime;
		//}

		//if (ControllerPluginWrapper.GetButtonPressed(0, 9) && (cooldown <= 0.0f))
		//{
		//	copy = Instantiate(Box, player.transform.position + player.transform.forward * 2.0f, player.transform.rotation) as GameObject;
		//	cooldown = 0.5f;
		//}

		//if (ControllerPluginWrapper.GetButtonPressed(0, 8) && (cooldown <= 0.0f))
		//{
		//	copy = Instantiate(Tree, player.transform.position + ((player.transform.forward * 2.0f) + new Vector3(0, -1, 0)), player.transform.rotation) as GameObject;
		//	cooldown = 0.5f;
		//}

		//if (ControllerPluginWrapper.LeftTrigger(0) > 0.1 && (cooldown <= 0.0f))
		//{
		//	copy = Instantiate(Crystals, player.transform.position + ((player.transform.forward * 2.0f) + new Vector3(0, -0.75f , 0)), player.transform.rotation) as GameObject;
		//	cooldown = 0.5f;
		//}

		//if (ControllerPluginWrapper.RightTrigger(0) > 0.1 && (cooldown <= 0.0f))
		//{
		//	copy = Instantiate(Tower, player.transform.position + ((player.transform.forward * 2.0f) + new Vector3(0, -1, 0)), player.transform.rotation) as GameObject;
		//	cooldown = 0.5f;
		//}



		ControllerPluginWrapper.RefreshStates();
	}
}
