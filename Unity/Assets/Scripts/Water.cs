using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	public GameObject  g;
	public float watertY;
	public float glassY;
	public bool isActive;

	public Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;
		isActive = true;
		g = GameObject.Find("glass");
	}

	// Update is called once per frame
	void Update () {
		watertY = transform.localPosition.y;
		glassY = g.transform.localPosition.y;

		if ( isActive == true && watertY < glassY) {
			isActive = false;
			Player.waterLife --;
		}

		if (Player.waterLife < 1) {
			Invoke("resertPosition", 3);
		}
	}

	public void resertPosition()
	{
			g.transform.localPosition = Player.startPosition;
			g.transform.localEulerAngles = Player.startRotation;
			transform.localPosition = startPosition;
	}


}
