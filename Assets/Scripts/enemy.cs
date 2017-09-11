using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	GameObject path;
	Transform targetPathNode;
	int pathNodeIndex = 0;

	public float speed = 5f;

	public float health = 1f;
	// Use this for initialization
	void Start () {
		path = GameObject.Find ("Path");
	}

	void GetNextPathNode() {
		targetPathNode = path.transform.GetChild(pathNodeIndex);
		pathNodeIndex++;
	}
	
	// Update is called once per frame
	void Update () {
		if (targetPathNode == null) {
			GetNextPathNode ();
			if (targetPathNode == null) {
				//Game Over:
				endOfPath ();
			}
		}

		Vector3 dir = targetPathNode.position - this.transform.localPosition;
		float disThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= disThisFrame) {
			targetPathNode = null;
		} else {
			//move
			transform.Translate( dir.normalized * disThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation (dir);
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, Time.deltaTime * 3);

		}
	}

	void endOfPath() {
		//Destroy(gameObject);
	}

}
