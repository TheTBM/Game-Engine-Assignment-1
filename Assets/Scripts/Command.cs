using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I used the following website to help write this namespace
//https://www.habrador.com/tutorials/programming-patterns/1-command-pattern/
//First accessed September 25th, 2018

namespace CommandPattern
{
	public abstract class Command
	{
		public abstract void Execute(GameObject gameObject, GameObject other, Command command);

		public virtual void Undo(GameObject gameObject)
		{

		}
	}

	public class Jump : Command
	{
		public override void Execute(GameObject gameObject, GameObject other, Command command)
		{
			jump(gameObject, other, command);
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}

		private void jump(GameObject gameObject, GameObject other, Command command)
		{
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

			if (rigidbody.velocity.y < 0.01f && rigidbody.velocity.y > -0.01f)
			{
				rigidbody.AddForce(new Vector3(0, 17.5f, 0), ForceMode.Impulse);
			}
		}
	}

	public class SpawnCube : Command
	{
		GameObject copy;

		public override void Execute(GameObject player, GameObject cube, Command command)
		{
			spawnCube(player, cube,  command);
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}

		private void spawnCube(GameObject gameObject, GameObject cube,  Command command)
		{
			copy = GameObject.Instantiate(cube, gameObject.transform.position + gameObject.transform.forward * 2.0f, gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnTree : Command
	{
		GameObject tree;
		GameObject copy;

		public override void Execute(GameObject gameObject, GameObject tree, Command command)
		{
			spawnTree(gameObject, tree, command);
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}

		private void spawnTree(GameObject gameObject, GameObject tree, Command command)
		{
			copy = GameObject.Instantiate(tree, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -1, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnCrystals : Command
	{
		GameObject crystal;
		GameObject copy;

		public override void Execute(GameObject gameObject, GameObject crystal, Command command)
		{
			spawnCrystals(gameObject, crystal, command);
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}

		private void spawnCrystals(GameObject gameObject, GameObject crystal, Command command)
		{
			copy = GameObject.Instantiate(crystal, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -0.75f, 0), gameObject.transform.rotation) as GameObject;
		}
	}

	public class SpawnTower : Command
	{
		GameObject tower;
		GameObject copy;

		public override void Execute(GameObject gameObject, GameObject tower, Command command)
		{
			spawnTower(gameObject, tower, command);
		}

		public override void Undo(GameObject gameObject)
		{
			base.Undo(gameObject);
		}

		private void spawnTower(GameObject gameObject, GameObject tower, Command command)
		{
			copy = GameObject.Instantiate(tower, (gameObject.transform.position + gameObject.transform.forward * 2.0f) + new Vector3(0, -1, 0), gameObject.transform.rotation) as GameObject;
		}
	}
}