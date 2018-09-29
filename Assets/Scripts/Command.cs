using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using CommandPattern;

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
		public abstract void Execute(GameObject gameObject, Command command);

		//function meant to be overwritten, can be executed
		public virtual void Undo(GameObject gameObject)
		{
			return;
		}
	}

	//child class of namespace CommandPattern
	public class Jump : Command
	{
		//take base class and overwrite function
		public override void Execute(GameObject gameObject, Command command)
		{
			//inside execute, call jump
			jump(gameObject, command);
		}

		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class Undo
			base.Undo(gameObject);
		}

		private void jump(GameObject gameObject, Command command)
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
		GameObject cube;
		List<GameObject> spawns = new List<GameObject>();

		//take base class and overwrite function
		public override void Execute(GameObject player, Command command)
		{
			//passing arguements
			spawnCube(player, command);
		}

		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class Undo
			base.Undo(gameObject);
		}

		//instantiate object
		private void spawnCube(GameObject gameObject, Command command)
		{
			cube = GameObject.FindGameObjectWithTag("Cube");
			copy = GameObject.Instantiate(cube, gameObject.transform.position + gameObject.transform.forward * 2.0f, gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnTree : Command
	{
		//object to be instantiated later
		GameObject copy;
		GameObject tree;
		List<GameObject> spawns = new List<GameObject>();

		//take base class and overwrite function
		public override void Execute(GameObject gameObject, Command command)
		{
			//passing arguements
			spawnTree(gameObject, command);
		}


		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class undo 
			base.Undo(gameObject);
		}

		//instantiate object
		private void spawnTree(GameObject gameObject, Command command)
		{
			tree = GameObject.FindGameObjectWithTag("Tree");
			copy = GameObject.Instantiate(tree, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -1, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnCrystals : Command
	{
		//object to be instantiated later
		GameObject copy;
		GameObject crystals;
		List<GameObject> spawns = new List<GameObject>();

		//take base class and overwrite function
		public override void Execute(GameObject gameObject, Command command)
		{
			//passing arguements
			spawnCrystals(gameObject, command);
		}

		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class undo
			base.Undo(gameObject);
		}

		//instantiate object
		private void spawnCrystals(GameObject gameObject, Command command)
		{
			crystals = GameObject.FindGameObjectWithTag("Crystals");
			copy = GameObject.Instantiate(crystals, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -0.75f, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnTower : Command
	{
		//object to be instantiated later
		GameObject copy;
		GameObject tower;
		List<GameObject> spawns = new List<GameObject>();

		//take base class and overwrite function
		public override void Execute(GameObject gameObject, Command command)
		{
			//passing arguements
			spawnTower(gameObject, command);
		}


		//take base class and overwrite function
		public override void Undo(GameObject gameObject)
		{
			//run base class undo
			base.Undo(gameObject);
		}

		//instantiate object 
		private void spawnTower(GameObject gameObject, Command command)
		{
			tower = GameObject.FindGameObjectWithTag("Tower");
			copy = GameObject.Instantiate(tower, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -1, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class UndoButton : Command
	{
		public override void Execute(GameObject gameObject, Command command)
		{
			return;
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}
	}

	public class DoNothing : Command
	{
		public override void Execute(GameObject gameObject, Command command)
		{
			return;
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}
	}
}