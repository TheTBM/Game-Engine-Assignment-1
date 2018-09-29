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

		float cooldown = 0.5f;

		//base class pointers 
		private Command XButton, CircleButton, SquareButton, TriangleButton, 
			DPadUp, DPadDown, DPadLeft, DPadRight, L1, R1, LStickPress, RStickPress,
			Pause, Select, RightTrigger, LeftTrigger;

		//list of previous inputs
		public static Stack<Command> inputs = new Stack<Command>();

		void Start()
		{
			//links object creation to specific buttons 
			XButton = new Jump();
			CircleButton = new DoNothing();
			SquareButton = new DoNothing();
			TriangleButton = new DoNothing();
			DPadUp = new DoNothing();
			DPadDown = new DoNothing();
			DPadLeft = new UndoButton();
			DPadRight = new DoNothing();
			R1 = new SpawnCube();
			L1 = new SpawnTree();
			LStickPress = new DoNothing();
			RStickPress = new DoNothing();
			Pause = new DoNothing();
			Select = new DoNothing();
			RightTrigger = new SpawnTower();
			LeftTrigger = new SpawnCrystals();
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

			//Debug.Log(inputs.Peek());
		}

		public void HandleInputs()
		{
			//if x button is pressed, make player jump
			if (ControllerPluginWrapper.GetButtonDown(0, 0))
			{
				if ((XButton.getCommand() != "DoNothing") && (XButton.getCommand() != "Jump") && (XButton.getCommand() != "UndoButton"))
				{
					inputs.Push(XButton);
				}

				cooldown = 0.5f;
				XButton.Execute(player, XButton);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 1))
			{
				if ((CircleButton.getCommand() != "DoNothing") && (CircleButton.getCommand() != "Jump") && (CircleButton.getCommand() != "UndoButton"))
				{
					inputs.Push(CircleButton);
				}

				cooldown = 0.5f;
				CircleButton.Execute(player, CircleButton);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 2))
			{
				if ((SquareButton.getCommand() != "DoNothing") && (SquareButton.getCommand() != "Jump") && (SquareButton.getCommand() != "UndoButton"))
				{
					inputs.Push(SquareButton);
				}

				cooldown = 0.5f;
				SquareButton.Execute(player, SquareButton);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 3))
			{
				if ((TriangleButton.getCommand() != "DoNothing") && (TriangleButton.getCommand() != "Jump") && (TriangleButton.getCommand() != "UndoButton"))
				{
					inputs.Push(TriangleButton);
				}

				cooldown = 0.5f;
				TriangleButton.Execute(player, TriangleButton);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 4))
			{
				if ((DPadUp.getCommand() != "DoNothing") && (DPadUp.getCommand() != "Jump") && (DPadUp.getCommand() != "UndoButton"))
				{
					inputs.Push(DPadUp);
				}

				cooldown = 0.5f;
				DPadUp.Execute(player, DPadUp);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 5))
			{
				if ((DPadDown.getCommand() != "DoNothing") && (DPadDown.getCommand() != "Jump") && (DPadDown.getCommand() != "UndoButton"))
				{
					inputs.Push(DPadDown);
				}

				cooldown = 0.5f;
				DPadDown.Execute(player, DPadDown);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 6))
			{
				if ((DPadLeft.getCommand() != "DoNothing") && (DPadLeft.getCommand() != "Jump") && (DPadLeft.getCommand() != "UndoButton"))
				{
					inputs.Push(DPadLeft);
				}

				cooldown = 0.5f;
				Debug.Log("I will now execute");
				DPadLeft.Execute(player, inputs.Peek());

				if (DPadLeft.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 7))
			{
				if ((DPadRight.getCommand() != "DoNothing") && (DPadRight.getCommand() != "Jump") && (DPadRight.getCommand() != "UndoButton"))
				{
					inputs.Push(DPadRight);
				}

				cooldown = 0.5f;
				DPadRight.Execute(player, DPadRight);
			}

			//else if left bumper is pressed spawn tree
			else if (ControllerPluginWrapper.GetButtonDown(0, 8))
			{
				if ((L1.getCommand() != "DoNothing") && (L1.getCommand() != "Jump") && (L1.getCommand() != "UndoButton"))
				{
					inputs.Push(L1);
				}

				cooldown = 0.5f;
				L1.Execute(player, L1);
			}

			//else if right bumper is pressed, spawn tree
			else if (ControllerPluginWrapper.GetButtonDown(0, 9))
			{
				if ((R1.getCommand() != "DoNothing") && (R1.getCommand() != "Jump") && (R1.getCommand() != "UndoButton"))
				{
					inputs.Push(R1);
				}

				cooldown = 0.5f;
				R1.Execute(player, R1);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 10))
			{
				if ((LStickPress.getCommand() != "DoNothing") && (LStickPress.getCommand() != "Jump") && (LStickPress.getCommand() != "UndoButton"))
				{
					inputs.Push(LStickPress);
				}

				cooldown = 0.5f;
				LStickPress.Execute(player, LStickPress);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 11))
			{
				if ((RStickPress.getCommand() != "DoNothing") && (RStickPress.getCommand() != "Jump") && (RStickPress.getCommand() != "UndoButton"))
				{
					inputs.Push(RStickPress);
				}

				cooldown = 0.5f;
				RStickPress.Execute(player, RStickPress);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 12))
			{
				if ((Pause.getCommand() != "DoNothing") && (Pause.getCommand() != "Jump") && (Pause.getCommand() != "UndoButton"))
				{
					inputs.Push(Pause);
				}

				cooldown = 0.5f;
				Pause.Execute(player, Pause);
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 13))
			{
				if ((Select.getCommand() != "DoNothing") && (Select.getCommand() != "Jump") && (Select.getCommand() != "UndoButton"))
				{
					inputs.Push(Select);
				}

				cooldown = 0.5f;
				Select.Execute(player, Select);
			}

			//else if right trigger is pressed spawn tower
			else if (ControllerPluginWrapper.RightTrigger(0) > 0.1f)
			{
				if ((RightTrigger.getCommand() != "DoNothing") && (RightTrigger.getCommand() != "Jump") && (RightTrigger.getCommand() != "UndoButton"))
				{
					inputs.Push(RightTrigger);
				}

				cooldown = 0.5f;
				RightTrigger.Execute(player, RightTrigger);
			}

			//else if left trigger is pressed spawn crystals
			else if (ControllerPluginWrapper.LeftTrigger(0) > 0.1f)
			{
				if ((LeftTrigger.getCommand() != "DoNothing") && (LeftTrigger.getCommand() != "Jump") && (LeftTrigger.getCommand() != "UndoButton"))
				{
					inputs.Push(LeftTrigger);
				}

				cooldown = 0.5f;
				LeftTrigger.Execute(player, LeftTrigger);
			}
		}
	}
}
