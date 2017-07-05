using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectCollider : MonoBehaviour {

	private List<ObstacleObject> obstacleObjectList;

	public List<ObstacleObject> obstacleList
	{

		get {
			return obstacleObjectList;
		}

		set{
			obstacleObjectList = value;
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "Obstacle") 
		{
			if (obstacleObjectList [obstacleList.FindIndex (obstacjeobj => obstacjeobj.returnName ().Equals (collider.gameObject.name))].Life > 0) {
				obstacleObjectList [obstacleList.FindIndex (obstacjeobj => obstacjeobj.returnName ().Equals (collider.gameObject.name))].Life--;
				Debug.Log ("KOLIZJA JESZCZE RAZ");
				Destroy (gameObject);
			}
			else 
			{
				obstacleObjectList.RemoveAt (obstacleList.FindIndex (obstacjeobj => obstacjeobj.returnName ().Equals (collider.gameObject.name)));
				Destroy (collider.gameObject);
				Debug.Log ("KOLIZJA KONIEC");
				Destroy (gameObject);
			}
		}
	}
}
