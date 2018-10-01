using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverCube : MonoBehaviour
{
	public GameObject jumper;
	int index;
	bool initiated = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (!initiated)
		{
			Init();
		}

		int.TryParse(gameObject.tag, out index);

		if ((jumper.transform.position.y >= 2.0) && (gameObject.GetComponent<Rigidbody>().velocity.y == 0.0f))
		{
			ObserverPluginWrapper.Trigger(index);
		}

		if (ObserverPluginWrapper.GetTriggered(index, 0))
		{
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

			rigidbody.AddForce(new Vector3(0, 7.5f, 0), ForceMode.Impulse);

			ObserverPluginWrapper.Untrigger(index);
		}
	}

	void Init()
	{
		int.TryParse(gameObject.tag, out index);

		if (index == 0)
		{
			ObserverPluginWrapper.Initiate();

			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();

			ObserverPluginWrapper.CreatePlayerJumpObserver(0);
			ObserverPluginWrapper.CreatePlayerJumpObserver(1);
			ObserverPluginWrapper.CreatePlayerJumpObserver(2);
			ObserverPluginWrapper.CreatePlayerJumpObserver(3);
			ObserverPluginWrapper.CreatePlayerJumpObserver(4);
		}

		initiated = true;
	}
}
