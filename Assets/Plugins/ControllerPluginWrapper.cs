using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace ControllerInputs
{
	/*
	
	A = 0;
	B = 1;
	X = 2;
	Y = 3;

	DPad_Up = 4;
	DPad_Down = 5;
	DPad_Left = 6;
	DPad_Right = 7;

	L_Shoulder = 8;
	R_Shoulder = 9;

	L_Thumbstick = 10;
	R_Thumbstick = 11;

	Start = 12;
	Back = 13;

	*/

		//external functions for controller
	public class ControllerPluginWrapper : MonoBehaviour
	{
		const string DLL_NAME = "ControllerPlugin";

		[DllImport(DLL_NAME)]
		public static extern void Initiate();

		[DllImport(DLL_NAME)]
		public static extern void UpdateControllers();

		[DllImport(DLL_NAME)]
		public static extern void RefreshStates();

		[DllImport(DLL_NAME)]
		public static extern bool LStick_InDeadZone(int index);

		[DllImport(DLL_NAME)]
		public static extern bool RStick_InDeadZone(int index);

		[DllImport(DLL_NAME)]
		public static extern float LeftStick_X(int index);

		[DllImport(DLL_NAME)]
		public static extern float LeftStick_Y(int index);

		[DllImport(DLL_NAME)]
		public static extern float RightStick_X(int index);

		[DllImport(DLL_NAME)]
		public static extern float RightStick_Y(int index);

		[DllImport(DLL_NAME)]
		public static extern float LeftTrigger(int index);

		[DllImport(DLL_NAME)]
		public static extern float RightTrigger(int index);

		[DllImport(DLL_NAME)]
		public static extern bool GetButtonPressed(int index, int button);

		[DllImport(DLL_NAME)]
		public static extern bool GetButtonDown(int index, int button);

		[DllImport(DLL_NAME)]
		public static extern bool GetPrevButtonDown(int index, int button);

		[DllImport(DLL_NAME)]
		public static extern bool GetPrevLeftStickMoveX(int index, float threshold);

		[DllImport(DLL_NAME)]
		public static extern bool GetPrevLeftStickMoveY(int index, float threshold);

		[DllImport(DLL_NAME)]
		public static extern bool GetPrevRightStickMoveX(int index, float threshold);

		[DllImport(DLL_NAME)]
		public static extern bool GetPrevRightStickMoveY(int index, float threshold);

		[DllImport(DLL_NAME)]
		public static extern int GetIndex(int index);

		[DllImport(DLL_NAME)]
		public static extern bool Connected(int index);

		[DllImport(DLL_NAME)]
		public static extern void Rumble(int index, float leftMotor = 0.0f, float rightMotor = 0.0f);
	}
}
