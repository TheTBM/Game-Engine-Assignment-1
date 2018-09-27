using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//custom controller namespace
using ControllerInputs;

//custom namespace for command design pattern
namespace CommandPattern
{
	public class InputManager : MonoBehaviour
	{
		//creates objects for each model
		public GameObject player;
		public GameObject cube;
		public GameObject tree;
		public GameObject crystals;
		public GameObject tower;

		//base class pointers 
		private Command XButton, R1, L1, RightTrigger, LeftTrigger;

		//list of previous inputs
		public static List<Command> previous = new List<Command>();

		void Start()
		{
			//links object creation to specific buttons 
			XButton = new Jump();
			R1 = new SpawnCube();
			L1 = new SpawnTree();
			RightTrigger = new SpawnTower();
			LeftTrigger = new SpawnCrystals();
		}

		// Update is called once per frame
		void Update()
		{
			HandleInputs();
		}

		public void HandleInputs()
		{
			//if x button is pressed, make player jump
			if (ControllerPluginWrapper.GetButtonPressed(0, 0))
			{
				XButton.Execute(player, cube, XButton);
			}

			//else if right bumper is pressed, spawn cube
			else if (ControllerPluginWrapper.GetButtonPressed(0, 9))
			{
				R1.Execute(player, cube, R1);
			}

			//else if left bumper is pressed spawn tree
			else if (ControllerPluginWrapper.GetButtonPressed(0, 8))
			{
				L1.Execute(player, tree, L1);
			}

			//else if right trigger is pressed spawn tower
			else if (ControllerPluginWrapper.RightTrigger(0) > 0.1f)
			{
				RightTrigger.Execute(player, tower, RightTrigger);
			}

			//else if left trigger is pressed spawn crystals
			else if (ControllerPluginWrapper.LeftTrigger(0) > 0.1f)
			{
				LeftTrigger.Execute(player, crystals, LeftTrigger);
			}
		}
	}
}
