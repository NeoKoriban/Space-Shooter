using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour {
	public List<ObstacleObject> objectList;

	void OnTriggerEnter(Collider collider)
	{
		
		if (collider.gameObject.tag == "DownWall") 
		{
			Destroy (gameObject);

		}

		if (collider.gameObject.name == "starShip") 
		{
			Destroy (gameObject);
			//dodać odejmowanie punktów zdrowia w tym miejscu
		}
	}

}
