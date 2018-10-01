using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//custom controller namespace
using ControllerInputs;
using UnityEngine.UI;

//custom namespace for command design pattern
namespace CommandPattern
{
	public class InputManager : MonoBehaviour
	{
		//creates objects for each model
		public GameObject player;

		static float maxCD = 0.25f;
		float cooldown = maxCD;

		bool remapping = false;
		int buttonBeingRemapped;

		//base class pointers 
		private Command XButton, CircleButton, SquareButton, TriangleButton, 
			DPadUp, DPadDown, DPadLeft, DPadRight, L1, R1, LStickPress, RStickPress,
			Pause, Select, RightTrigger, LeftTrigger;

		private Command Blank, tempCopy;

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
			Select = new RemapButton();
			RightTrigger = new SpawnTower();
			LeftTrigger = new SpawnCrystals();

			inputs.Push(XButton);
		}

		// Update is called once per frame
		void Update()
		{
			if (cooldown > 0.0f)
			{
				cooldown -= Time.deltaTime;
			}

			else if (!remapping)
			{
				HandleInputs();
			}

			else
			{
				if (buttonBeingRemapped < 7)
				{
					RemapButtons();
				}

				else
				{
					buttonBeingRemapped = 0;
					remapping = false;
				}
			}
		}

		public void HandleInputs()
		{
			GameObject.Find("Prompt").GetComponent<Text>().text = "";

			//perform action linked to x button
			if (ControllerPluginWrapper.GetButtonDown(0, 0))
			{
				if ((XButton.getCommand() != "DoNothing") && (XButton.getCommand() != "Jump") && (XButton.getCommand() != "UndoButton") && (XButton.getCommand() != "RemapButton"))
				{
					inputs.Push(XButton);
				}


				cooldown = maxCD;
				XButton.Execute(player, inputs.Peek());

				if (XButton.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (XButton.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to circle button
			else if (ControllerPluginWrapper.GetButtonDown(0, 1))
			{
				if ((CircleButton.getCommand() != "DoNothing") && (CircleButton.getCommand() != "Jump") && (CircleButton.getCommand() != "UndoButton") && (CircleButton.getCommand() != "RemapButton"))
				{
					inputs.Push(CircleButton);
				}

				cooldown = maxCD;
				CircleButton.Execute(player, inputs.Peek());

				if (CircleButton.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (CircleButton.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to square button
			else if (ControllerPluginWrapper.GetButtonDown(0, 2))
			{
				if ((SquareButton.getCommand() != "DoNothing") && (SquareButton.getCommand() != "Jump") && (SquareButton.getCommand() != "UndoButton") && (SquareButton.getCommand() != "RemapButton"))
				{
					inputs.Push(SquareButton);
				}

				cooldown = maxCD;
				SquareButton.Execute(player, inputs.Peek());

				if (SquareButton.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (SquareButton.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to triangle button
			else if (ControllerPluginWrapper.GetButtonDown(0, 3))
			{
				if ((TriangleButton.getCommand() != "DoNothing") && (TriangleButton.getCommand() != "Jump") && (TriangleButton.getCommand() != "UndoButton") && (TriangleButton.getCommand() != "RemapButton"))
				{
					inputs.Push(TriangleButton);
				}

				cooldown = maxCD;
				TriangleButton.Execute(player, inputs.Peek());

				if (TriangleButton.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (TriangleButton.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to up on directional pad
			else if (ControllerPluginWrapper.GetButtonDown(0, 4))
			{
				if ((DPadUp.getCommand() != "DoNothing") && (DPadUp.getCommand() != "Jump") && (DPadUp.getCommand() != "UndoButton") && (DPadUp.getCommand() != "RemapButton"))
				{
					inputs.Push(DPadUp);
				}

				cooldown = maxCD;
				DPadUp.Execute(player, inputs.Peek());

				if (DPadUp.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (DPadUp.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to down on directional pad
			else if (ControllerPluginWrapper.GetButtonDown(0, 5))
			{
				if ((DPadDown.getCommand() != "DoNothing") && (DPadDown.getCommand() != "Jump") && (DPadDown.getCommand() != "UndoButton") && (DPadDown.getCommand() != "RemapButton"))
				{
					inputs.Push(DPadDown);
				}

				cooldown = maxCD;
				DPadDown.Execute(player, inputs.Peek());

				if (DPadDown.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (DPadDown.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to left on directional pad
			else if (ControllerPluginWrapper.GetButtonDown(0, 6))
			{
				if ((DPadLeft.getCommand() != "DoNothing") && (DPadLeft.getCommand() != "Jump") && (DPadLeft.getCommand() != "UndoButton") && (DPadLeft.getCommand() != "RemapButton"))
				{
					inputs.Push(DPadLeft);
				}

				cooldown = maxCD;
				DPadLeft.Execute(player, inputs.Peek());

				if (DPadLeft.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (DPadLeft.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to right on directional pad
			else if (ControllerPluginWrapper.GetButtonDown(0, 7))
			{
				if ((DPadRight.getCommand() != "DoNothing") && (DPadRight.getCommand() != "Jump") && (DPadRight.getCommand() != "UndoButton") && (DPadRight.getCommand() != "RemapButton"))
				{
					inputs.Push(DPadRight);
				}

				cooldown = maxCD;
				DPadRight.Execute(player, inputs.Peek());

				if (DPadRight.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (DPadRight.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to left bumper
			else if (ControllerPluginWrapper.GetButtonDown(0, 8))
			{
				if ((L1.getCommand() != "DoNothing") && (L1.getCommand() != "Jump") && (L1.getCommand() != "UndoButton") && (L1.getCommand() != "RemapButton"))
				{
					inputs.Push(L1);
				}

				cooldown = maxCD;
				L1.Execute(player, inputs.Peek());

				if (L1.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (L1.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			  //perform action linked to right bumper
			else if (ControllerPluginWrapper.GetButtonDown(0, 9))
			{
				if ((R1.getCommand() != "DoNothing") && (R1.getCommand() != "Jump") && (R1.getCommand() != "UndoButton") && (R1.getCommand() != "RemapButton"))
				{
					inputs.Push(R1);
				}

				cooldown = maxCD;
				R1.Execute(player, inputs.Peek());

				if (R1.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (R1.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to left stick pressed 
			else if (ControllerPluginWrapper.GetButtonDown(0, 10))
			{
				if ((LStickPress.getCommand() != "DoNothing") && (LStickPress.getCommand() != "Jump") && (LStickPress.getCommand() != "UndoButton") && (LStickPress.getCommand() != "RemapButton"))
				{
					inputs.Push(LStickPress);
				}

				cooldown = maxCD;
				LStickPress.Execute(player, inputs.Peek());

				if (LStickPress.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (LStickPress.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to right stick pressed 
			else if (ControllerPluginWrapper.GetButtonDown(0, 11))
			{
				if ((RStickPress.getCommand() != "DoNothing") && (RStickPress.getCommand() != "Jump") && (RStickPress.getCommand() != "UndoButton") && (RStickPress.getCommand() != "RemapButton"))
				{
					inputs.Push(RStickPress);
				}

				cooldown = maxCD;
				RStickPress.Execute(player, inputs.Peek());

				if (RStickPress.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (RStickPress.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to start button
			else if (ControllerPluginWrapper.GetButtonDown(0, 12))
			{
				if ((Pause.getCommand() != "DoNothing") && (Pause.getCommand() != "Jump") && (Pause.getCommand() != "UndoButton") && (Pause.getCommand() != "RemapButton"))
				{
					inputs.Push(Pause);
				}

				cooldown = maxCD;
				Pause.Execute(player, inputs.Peek());

				if (Pause.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (Pause.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to back button
			else if (ControllerPluginWrapper.GetButtonDown(0, 13))
			{
				if ((Select.getCommand() != "DoNothing") && (Select.getCommand() != "Jump") && (Select.getCommand() != "UndoButton") && (Select.getCommand() != "RemapButton"))
				{
					inputs.Push(Select);
				}

				cooldown = maxCD;
				Select.Execute(player, inputs.Peek());

				if (Select.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (Select.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to right trigger
			else if (ControllerPluginWrapper.RightTrigger(0) > 0.1f)
			{
				if ((RightTrigger.getCommand() != "DoNothing") && (RightTrigger.getCommand() != "Jump") && (RightTrigger.getCommand() != "UndoButton") && (RightTrigger.getCommand() != "RemapButton"))
				{
					inputs.Push(RightTrigger);
				}

				cooldown = maxCD;
				RightTrigger.Execute(player, inputs.Peek());

				if (RightTrigger.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (RightTrigger.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}

			//perform action linked to left trigger
			else if (ControllerPluginWrapper.LeftTrigger(0) > 0.1f)
			{
				if ((LeftTrigger.getCommand() != "DoNothing") && (LeftTrigger.getCommand() != "Jump") && (LeftTrigger.getCommand() != "UndoButton") && (LeftTrigger.getCommand() != "RemapButton"))
				{
					inputs.Push(LeftTrigger);
				}

				cooldown = maxCD;
				LeftTrigger.Execute(player, inputs.Peek());

				if (LeftTrigger.getCommand() == "UndoButton")
				{
					inputs.Pop();
				}

				else if (LeftTrigger.getCommand() == "RemapButton")
				{
					remapping = true;
					ResetAllButtons();
				}
			}
		}

		//resets all button mapping
		private void ResetAllButtons()
		{
			XButton = new DoNothing();
			CircleButton = new DoNothing();
			SquareButton = new DoNothing();
			TriangleButton = new DoNothing();
			DPadUp = new DoNothing();
			DPadDown = new DoNothing();
			DPadLeft = new DoNothing();
			DPadRight = new DoNothing();
			L1 = new DoNothing();
			R1 = new DoNothing();
			LStickPress = new DoNothing();
			RStickPress = new DoNothing();
			Pause = new DoNothing();
			Select = new DoNothing();
			RightTrigger = new DoNothing();
			LeftTrigger = new DoNothing();
		}

		//gets button pressed to change control commands
		private void RemapButtons()
		{
			switch (buttonBeingRemapped)
			{
				case 0:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping jump command";
					break;
				case 1:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping spawn tree command";
					break;
				case 2:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping spawn spruce command";
					break;
				case 3:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping spawn crystals command";
					break;
				case 4:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping spawn tower command";
					break;
				case 5:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping undo command";
					break;
				case 6:
					GameObject.Find("Prompt").GetComponent<Text>().text =
						"Currently remapping command remapping command";
					break;
				default:
					break;
			}

			if (getNextButtonPress() == XButton)
			{
				GiveCommand(ref XButton);
			}

			if (getNextButtonPress() == CircleButton)
			{
				GiveCommand(ref CircleButton);
			}

			if (getNextButtonPress() == SquareButton)
			{
				GiveCommand(ref SquareButton);
			}

			if (getNextButtonPress() == TriangleButton)
			{
				GiveCommand(ref TriangleButton);
			}

			if (getNextButtonPress() == DPadUp)
			{
				GiveCommand(ref DPadUp);
			}

			if (getNextButtonPress() == DPadDown)
			{
				GiveCommand(ref DPadDown);
			}

			if (getNextButtonPress() == DPadLeft)
			{
				GiveCommand(ref DPadLeft);
			}

			if (getNextButtonPress() == DPadRight)
			{
				GiveCommand(ref DPadRight);
			}

			if (getNextButtonPress() == L1)
			{
				GiveCommand(ref L1);
			}

			if (getNextButtonPress() == R1)
			{
				GiveCommand(ref R1);
			}

			if (getNextButtonPress() == LStickPress)
			{
				GiveCommand(ref LStickPress);
			}

			if (getNextButtonPress() == RStickPress)
			{
				GiveCommand(ref RStickPress);
			}

			if (getNextButtonPress() == Pause)
			{
				GiveCommand(ref Pause);
			}

			if (getNextButtonPress() == Select)
			{
				GiveCommand(ref Select);
			}

			if (getNextButtonPress() == LeftTrigger)
			{
				GiveCommand(ref LeftTrigger);
			}

			if (getNextButtonPress() == RightTrigger)
			{
				GiveCommand(ref RightTrigger);
			}
		}

		//gives last button pressed new command
		private void GiveCommand(ref Command command)
		{
			switch (buttonBeingRemapped)
			{
				case 0:
					command = new Jump();
					buttonBeingRemapped++;
					break;
				case 1:
					command = new SpawnCube();
					buttonBeingRemapped++;
					break;
				case 2:
					command = new SpawnTree();
					buttonBeingRemapped++;
					break;
				case 3:
					command = new SpawnCrystals();
					buttonBeingRemapped++;
					break;
				case 4:
					command = new SpawnTower();
					buttonBeingRemapped++;
					break;
				case 5:
					command = new UndoButton();
					buttonBeingRemapped++;
					break;
				case 6:
					command = new RemapButton();
					buttonBeingRemapped++;
					break;
			}
		}

		//takes in the last button pressed 
		public Command getNextButtonPress()
		{
			if (ControllerPluginWrapper.GetButtonDown(0, 0))
			{
				cooldown = maxCD;
				return XButton;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 1))
			{
				cooldown = maxCD;
				return CircleButton;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 2))
			{
				cooldown = maxCD;
				return SquareButton;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 3))
			{
				cooldown = maxCD;
				return TriangleButton;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 4))
			{
				cooldown = maxCD;
				return DPadUp;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 5))
			{
				cooldown = maxCD;
				return DPadDown;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 6))
			{
				cooldown = maxCD;
				return DPadLeft;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 7))
			{
				cooldown = maxCD;
				return DPadRight;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 8))
			{
				cooldown = maxCD;
				return L1;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 9))
			{
				cooldown = maxCD;
				return R1;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 10))
			{
				cooldown = maxCD;
				return LStickPress;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 11))
			{
				cooldown = maxCD;
				return RStickPress;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 12))
			{
				cooldown = maxCD;
				return Pause;
			}

			else if (ControllerPluginWrapper.GetButtonDown(0, 13))
			{
				cooldown = maxCD;
				return Select;
			}

			else if (ControllerPluginWrapper.LeftTrigger(0) > 0.9f)
			{
				cooldown = maxCD;
				return LeftTrigger;
			}

			else if (ControllerPluginWrapper.RightTrigger(0) > 0.9f)
			{
				cooldown = maxCD;
				return RightTrigger;
			}

			return Blank;
		}
	}
}
