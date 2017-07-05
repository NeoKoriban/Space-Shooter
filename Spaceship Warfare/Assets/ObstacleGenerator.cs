using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject
{
	
	private int life;
	private string name;

	public ObstacleObject (int lifeObject, string nameObject)
	{
		life = lifeObject;
		name = nameObject;

	}

	public int Life
	{
		get 
		{
			return life;
		}

		set
		{
			life = value;
		}
	}
	public string returnName()
	{
		return name;
	}

}



public class ObstacleGenerator : MonoBehaviour {

	private List <ObstacleObject> obstacleObjectList;
	public List<GameObject> obstacleList;
	private float timer = 0.0f;
	public string nameEjectedObstacle = "";
	private float timerBorder = 5.0f;
	private WallCollision wallCollision;
	private Shooting bulletCollider;
	private int enemyIncoming = 5;
	private int level = 1;
	// Use this for initialization
	void Start () {
		obstacleObjectList = new List<ObstacleObject>();
		wallCollision = GameObject.FindWithTag ("DownWall").GetComponent<WallCollision> ();
		bulletCollider = GameObject.Find ("starShip").GetComponent<Shooting> ();
	}
	// Update is called once per frame
	void Update () {
	//	obstacleObjectList = wallCollision.obsList;
		//Debug.Log("ListObjectObstacle Count" + obstacleObjectList.Count);
		timer += Time.deltaTime;
		if (timer >= timerBorder && GameObject.Find("Enemy").Equals(null)) {
			if (enemyIncoming == 0) {
				float minPlace = gameObject.GetComponent<BoxCollider> ().bounds.min.x;
				float maxPlace = gameObject.GetComponent<BoxCollider> ().bounds.max.x;
				float deltaPlace = (maxPlace - minPlace) / 9;
				int objectCounter = Random.Range (1, 4);

				if (objectCounter <= 5) {
					List<int> temporarySpaceList = new List<int> ();

					for (int i = 0; i < objectCounter; i++) {
						int objectSpace = 0;
						do {
							objectSpace = Random.Range (1, 5);

						} while(temporarySpaceList.Contains (objectSpace));

						temporarySpaceList.Add (objectSpace);
						GameObject newObstacle = Instantiate (obstacleList [0]) as GameObject;
						newObstacle.transform.position = new Vector3 (minPlace + (objectSpace + 1) * deltaPlace, gameObject.transform.position.y, gameObject.transform.position.z);
						int obstacleRange = Random.Range (1, 3);

						switch (obstacleRange) {
						case 1:
							newObstacle.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
							obstacleObjectList.Add (new ObstacleObject (1, "Obstacle" + obstacleObjectList.Count));
							break;
						case 2:
							newObstacle.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
							obstacleObjectList.Add (new ObstacleObject (2, "Obstacle" + obstacleObjectList.Count));
							break;
						case 3:
							newObstacle.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
							obstacleObjectList.Add (new ObstacleObject (3, "Obstacle" + obstacleObjectList.Count));
							break;
						}

						newObstacle.name = obstacleObjectList [obstacleObjectList.Count - 1].returnName ();
						newObstacle.tag = "Obstacle";
						newObstacle.AddComponent<ObstacleMovement> ();
						newObstacle.AddComponent<Rigidbody> ().useGravity = false;
						newObstacle.AddComponent<SphereCollider> ();
						newObstacle.GetComponent<SphereCollider> ().isTrigger = true;
						newObstacle.GetComponent<SphereCollider> ().radius = 1.5f;
						newObstacle.AddComponent<ObstacleCollider> ();
					}
					temporarySpaceList.Clear ();

				} else {
					for (int i = 0; i < objectCounter; i++) {
						//	listOfObstacle.Add (new ObstacleObject (1, "asteroid" + listOfObstacle.Count.ToString ()));
						GameObject newObstacle = Instantiate (obstacleList [0]) as GameObject;
						newObstacle.transform.position = new Vector3 (minPlace + (i + 1) * deltaPlace, gameObject.transform.position.y, gameObject.transform.position.z);
						newObstacle.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
						obstacleObjectList.Add (new ObstacleObject (2, "Obstacle" + obstacleList.Count));
						newObstacle.name = obstacleObjectList [obstacleList.Count - 1].returnName ();
						newObstacle.tag = "Obstacle";
						newObstacle.AddComponent<ObstacleMovement> ();
						newObstacle.AddComponent<Rigidbody> ().useGravity = false;
						newObstacle.GetComponent<SphereCollider> ().isTrigger = true;
						newObstacle.GetComponent<SphereCollider> ().radius = 1.5f;
						newObstacle.AddComponent<ObstacleCollider> ();
					}
				}
				timer = 0;
				wallCollision.obsList = obstacleObjectList;
				bulletCollider.obstacleObjectList = obstacleObjectList;
				enemyIncoming--;
			} else {
				enemyIncoming += level * 5;
			}
		}
	}
}
