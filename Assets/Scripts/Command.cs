using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I used the following website to help write this namespace
//https://www.habrador.com/tutorials/programming-patterns/1-command-pattern/
//First accessed September 25th, 2018

//custom namespace for command design pattern
namespace CommandPattern
{
	//abstract class to be inherited from 
	public abstract class Command
	{
		//public function meant to be inherited from
		public abstract void Execute(GameObject gameObject, GameObject other, Command command);

		//function meant to be overwritten, can be executed
		public virtual void Undo(GameObject gameObject)
		{

		}
	}

	//child class of namespace CommandPattern
	public class Jump : Command
	{
		//take base class and overwrite function
		public override void Execute(GameObject gameObject, GameObject other, Command command)
		{
			//inside execute, call jump
			jump(gameObject, other, command);
		}

		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class Undo
			base.Undo(gameObject);
		}

		private void jump(GameObject gameObject, GameObject other, Command command)
		{
			//take the physics component and jump
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

			if (rigidbody.velocity.y < 0.01f && rigidbody.velocity.y > -0.01f)
			{
				rigidbody.AddForce(new Vector3(0, 17.5f, 0), ForceMode.Impulse);
			}
		}
	}

	//child class of namespace commandPattern
	public class SpawnCube : Command
	{
		//object to be instantiated later
		GameObject copy;

		//take base class and overwrite function
		public override void Execute(GameObject player, GameObject cube, Command command)
		{
			//passing arguements
			spawnCube(player, cube,  command);
		}

		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class Undo
			base.Undo(gameObject);
		}

		//instantiate object
		private void spawnCube(GameObject gameObject, GameObject cube,  Command command)
		{
			copy = GameObject.Instantiate(cube, gameObject.transform.position + gameObject.transform.forward * 2.0f, gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnTree : Command
	{
		//object to be instantiated later
		GameObject copy;

		//take base class and overwrite function
		public override void Execute(GameObject gameObject, GameObject tree, Command command)
		{
			//passing arguements
			spawnTree(gameObject, tree, command);
		}


		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class undo 
			base.Undo(gameObject);
		}

		//instantiate object
		private void spawnTree(GameObject gameObject, GameObject tree, Command command)
		{
			copy = GameObject.Instantiate(tree, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -1, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnCrystals : Command
	{
		//object to be instantiated later
		GameObject copy;

		//take base class and overwrite function
		public override void Execute(GameObject gameObject, GameObject crystal, Command command)
		{
			//passing arguements
			spawnCrystals(gameObject, crystal, command);
		}

		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class undo
			base.Undo(gameObject);
		}

		//instantiate object
		private void spawnCrystals(GameObject gameObject, GameObject crystal, Command command)
		{
			copy = GameObject.Instantiate(crystal, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -0.75f, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnTower : Command
	{
		//object to be instantiated later
		GameObject copy;

		//take base class and overwrite function
		public override void Execute(GameObject gameObject, GameObject tower, Command command)
		{
			//passing arguements
			spawnTower(gameObject, tower, command);
		}


		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class undo
			base.Undo(gameObject);
		}

		//instantiate object 
		private void spawnTower(GameObject gameObject, GameObject tower, Command command)
		{
			copy = GameObject.Instantiate(tower, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -1, 0), gameObject.transform.rotation) as GameObject;
		}
	}
}