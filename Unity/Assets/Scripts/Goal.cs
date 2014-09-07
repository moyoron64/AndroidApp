using UnityEngine;
using System.Collections;



public class Goal : MonoBehaviour {
	public GameObject objA;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float distance = objA.transform.position.x - transform.position.x;

		if (distance <= 0) {
			Debug.Log("Clear!!!!");
		}
	}
}
