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
		GameObject cube;
		GameObject tree;
		GameObject crystals;
		GameObject tower;

		float cooldown = 0.5f;

		//base class pointers 
		private Command XButton, CircleButton, SquareButton, TriangleButton, 
			DPadUp, DPadDown, DPadLeft, DPadRight, L1, R1, LStickPress, RStickPress,
			Pause, Select, RightTrigger, LeftTrigger;

		//list of previous inputs
		public static List<Command> previous = new List<Command>();

		void Start()
		{
			//links object creation to specific buttons 
			XButton = new Jump();
			CircleButton = new DoNothing();
			SquareButton = new DoNothing();
			TriangleButton = new DoNothing();
			DPadUp = new DoNothing();
			DPadDown = new DoNothing();
			DPadLeft = new DoNothing();
			DPadRight = new DoNothing();
			R1 = new SpawnCube();
			L1 = new SpawnTree();
			LStickPress = new DoNothing();
			RStickPress = new DoNothing();
			Pause = new DoNothing();
			Select = new DoNothing();
			RightTrigger = new SpawnTower();
			LeftTrigger = new SpawnCrystals();

			cube = Resources.Load("Prefabs/Box") as GameObject;
		}

		// Update is called once per frame
		void Update()
		{
			if (cooldown > 0.0f)
			{
				cooldown -= Time.deltaTime;
			}

			else
			{
				HandleInputs();
			}
		}

		public void HandleInputs()
		{
			//if x button is pressed, make player jump
			if (ControllerPluginWrapper.GetButtonPressed(0, 0))
			{
				XButton.Execute(player, XButton);
				cooldown = 0.5f;
			}

			if (ControllerPluginWrapper.GetButtonPressed(0, 1))
			{
				cooldown = 0.5f;
				CircleButton.Execute(player, CircleButton);
			}

			//else if right bumper is pressed, spawn tree
			else if (ControllerPluginWrapper.GetButtonDown(0, 9))
			{
				cooldown = 0.5f;
				R1.Execute(player, R1);
			}

			//else if left bumper is pressed spawn tree
			else if (ControllerPluginWrapper.GetButtonPressed(0, 8))
			{
				cooldown = 0.5f;
				L1.Execute(player, L1);
			}

			//else if right trigger is pressed spawn tower
			else if (ControllerPluginWrapper.RightTrigger(0) > 0.1f)
			{
				cooldown = 0.5f;
				RightTrigger.Execute(player, RightTrigger);
			}

			//else if left trigger is pressed spawn crystals
			else if (ControllerPluginWrapper.LeftTrigger(0) > 0.1f)
			{
				cooldown = 0.5f;
				LeftTrigger.Execute(player, LeftTrigger);
			}
		}
	}
}
