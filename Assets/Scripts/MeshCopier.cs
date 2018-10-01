using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCopier : MonoBehaviour
{
	public GameObject circleTree;
	public GameObject tree;
	public GameObject crystals;
	public GameObject tower;

	public Mesh circleTreeMesh;
	public Mesh treeMesh;
	public Mesh crystalsMesh;
	public Mesh towerMesh;

	// Use this for initialization
	void Start ()
	{
		circleTreeMesh = circleTree.GetComponent<MeshFilter>().sharedMesh;
		treeMesh = tree.GetComponent<MeshFilter>().sharedMesh;
		crystalsMesh = crystals.GetComponent<MeshFilter>().sharedMesh;
		towerMesh = tower.GetComponent<MeshFilter>().sharedMesh;
	}
}
