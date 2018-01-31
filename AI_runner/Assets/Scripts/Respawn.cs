using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	 
	public GameObject collectible_obj;

	public void respawn(float z = 0f, float offset = 0)
	{
		var randX = Random.Range (-5, 5);

		collectible_obj.transform.position = new Vector3(randX, 0f, z+offset);
	}
}
