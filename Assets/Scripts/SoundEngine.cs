using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundEnginePluginWrapper;

public class SoundEngine : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		SoundEngineWrapper.Initialize();
		SoundEngineWrapper.LoadSound("music", false, true, true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (SoundEngineWrapper.IsPlaying(0).ToInt32() == 0)
		{
			SoundEngineWrapper.PlayASound("music", 0, false, 0);
		}

		SoundEngineWrapper.UpdateSE();
	}

	void OnApplicationQuit()
	{
		SoundEngineWrapper.StopAllChannels();
	}
}
