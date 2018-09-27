using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerInputs;

namespace CommandPattern
{
	public class InputManager : MonoBehaviour
	{
		public GameObject player;
		public GameObject cube;
		public GameObject tree;
		public GameObject crystals;
		public GameObject tower;

		private Command XButton, R1, L1, RightTrigger, LeftTrigger;

		public static List<GameObject> gameObjects = new List<GameObject>();

		void Start()
		{
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
			if (ControllerPluginWrapper.GetButtonPressed(0, 0))
			{
				XButton.Execute(player, cube, XButton);
			}

			else if (ControllerPluginWrapper.GetButtonPressed(0, 9))
			{
				R1.Execute(player, cube, R1);
			}

			else if (ControllerPluginWrapper.GetButtonPressed(0, 8))
			{
				L1.Execute(player, tree, L1);
			}

			else if (ControllerPluginWrapper.RightTrigger(0) > 0.1f)
			{
				RightTrigger.Execute(player, tower, RightTrigger);
			}

			else if (ControllerPluginWrapper.LeftTrigger(0) > 0.1f)
			{
				LeftTrigger.Execute(player, crystals, LeftTrigger);
			}
		}
	}
}
