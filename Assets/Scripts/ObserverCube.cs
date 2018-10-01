using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for observer design pattern
public class ObserverCube : MonoBehaviour
{
	public GameObject jumper;
	int index;
	bool initiated = false;
	
	void Start()
	{
		//if you can, turn string into int 
		int.TryParse(gameObject.tag, out index);

		if (index == 0)
		{
			ObserverPluginWrapper.Initiate();

			//creates events
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();
			ObserverPluginWrapper.CreateObserverEvent();

			//creates observers
			ObserverPluginWrapper.CreatePlayerJumpObserver(0);
			ObserverPluginWrapper.CreatePlayerJumpObserver(1);
			ObserverPluginWrapper.CreatePlayerJumpObserver(2);
			ObserverPluginWrapper.CreatePlayerJumpObserver(3);
			ObserverPluginWrapper.CreatePlayerJumpObserver(4);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		//if you can, turn string into int 
		int.TryParse(gameObject.tag, out index);

		//if player is in the air, and the object isn't, then jump
		if ((jumper.transform.position.y >= 2.0) && (gameObject.GetComponent<Rigidbody>().velocity.y == 0.0f))
		{
			ObserverPluginWrapper.Trigger(index);
		}

		//checks if observerd is triggered, then tells it to go
		if (ObserverPluginWrapper.GetTriggered(index, 0))
		{
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

			rigidbody.AddForce(new Vector3(0, 7.5f, 0), ForceMode.Impulse);

			ObserverPluginWrapper.Untrigger(index);
		}
	}
}
