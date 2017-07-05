using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {
	private List<ObstacleObject> obstacleList;

	public List<ObstacleObject> obsList
	{
		get 
		{
			return obstacleList;
		}
		set
		{
			obstacleList = value;
		}

	}


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Obstacle") 
		{
			obstacleList.RemoveAt (obstacleList.FindIndex (obstacle => obstacle.returnName ().Equals (col.gameObject.name)));
		}
	}


}
