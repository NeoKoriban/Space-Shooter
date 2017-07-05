using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour {
	void Start()
	{
		gameObject.AddComponent<Rigidbody> ();
		gameObject.GetComponent<Rigidbody> ().useGravity = false;
	
	}
	void OnCollisionEnter(Collision collisionObject)
	{
		if (collisionObject.gameObject.name == "wall") {
			Destroy (gameObject);
			Debug.Log ("KOLIZJA ŚCIANA");
		}
	}

}
