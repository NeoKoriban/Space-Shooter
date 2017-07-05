using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject bullet;
	private GameObject bulletObjectLeft;
	private GameObject bulletObjectRight;
	private List<ObstacleObject> obsObjectList;

	public List<ObstacleObject> obstacleObjectList
	{
		get {
			return obsObjectList;
		}

		set {
			obsObjectList = value;
		}

	}


	// Use this for initialization
	void Start () {
		bulletObjectLeft = new GameObject ("leftBullet");
		bulletObjectRight = new GameObject ("rightBullet");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			
			BoxCollider starshipMesh = (BoxCollider)gameObject.GetComponent<BoxCollider> ();

			GameObject newBulletL;
			GameObject newBulletR;

			newBulletL = Instantiate (bullet, bulletObjectLeft.transform) as GameObject;
			newBulletL.transform.localScale = new Vector3 (0.1f, 0.03f, 0.03f);
			newBulletL.transform.position = new Vector3(starshipMesh.bounds.min.x,transform.position.y,starshipMesh.bounds.max.z+0.5f);
			newBulletL.transform.Rotate(new Vector3(0.0f,0.0f,90.0f));
			newBulletL.name = "bullet";
			newBulletL.AddComponent<Light> ().intensity = 1.0f;
			newBulletL.GetComponent<Light> ().color = Color.yellow;
			newBulletL.GetComponent<MeshRenderer> ().material.color = Color.yellow;
			newBulletL.AddComponent<BulletMovement> ();
			newBulletL.AddComponent<BulletLife> ();
			newBulletL.AddComponent<BulletObjectCollider> ().obstacleList = obsObjectList;

			newBulletL.AddComponent<BoxCollider> ();
			newBulletR = Instantiate (bullet, bulletObjectRight.transform) as GameObject;
			newBulletR.transform.localScale = new Vector3 (0.1f, 0.03f, 0.03f);
			newBulletR.GetComponent<MeshRenderer> ().material.color = Color.yellow;
			newBulletR.AddComponent<Light> ().intensity = 1.0f;
			newBulletR.GetComponent<Light> ().color = Color.yellow;
			newBulletR.transform.position = new Vector3(starshipMesh.bounds.max.x,transform.position.y,starshipMesh.bounds.max.z+0.5f);
			newBulletR.transform.Rotate(new Vector3(0.1f,0.0f,90.0f));
			newBulletR.name = "bullet";
			newBulletR.AddComponent<BoxCollider> ();
			newBulletR.AddComponent<BulletLife> ();
			newBulletR.AddComponent<BulletMovement> ();
			newBulletR.AddComponent<BulletObjectCollider> ().obstacleList = obsObjectList;


		}
	}
}
