using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ObserverPluginWrapper : MonoBehaviour
{
	const string DLL_NAME = "ObserverPlugin";

	[DllImport(DLL_NAME)]
	public static extern void CreateObserverEvent();

	[DllImport(DLL_NAME)]
	public static extern void Initiate();

	[DllImport(DLL_NAME)]
	public static extern void Trigger(int index);

	[DllImport(DLL_NAME)]
	public static extern void Untrigger(int index);

	[DllImport(DLL_NAME)]
	public static extern void CreatePlayerJumpObserver(int index);

	[DllImport(DLL_NAME)]
	public static extern void CreateCubeJumpObserver(int index);

	[DllImport(DLL_NAME)]
	public static extern bool GetTriggered(int eventIndex, int observerIndex);
}
