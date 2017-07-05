using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShipMove : MonoBehaviour {
	public Camera gameCamera;

	// Use this for initialization
	void Start () {
		//gameCamera = FindObjectOfType<Camera>().transform.Translate(0f;0f;0f);
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (0.0f, 0.0f, 0.0f);

		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.Translate (0.0f, 0.2f, 0.0f);

		} else if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.Translate (0.0f, -0.2f, 0.0f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Translate (0.2f, 0.0f, 0.0f);

		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Translate (-0.2f, 0.0f, 0.0f);

		}


	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "wall") {
			Debug.Log ("KOLIZJA");
		}


	}

}
