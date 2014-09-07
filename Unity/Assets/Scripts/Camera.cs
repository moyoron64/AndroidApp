using UnityEngine;
using System;
using System.Collections;

public class Camera : MonoBehaviour {

	public float timer;
	public int now;

	// Use this for initialization
	void Start () {
		timer = 10.0f;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		now = (int)Math.Floor(timer);

		if (now == 0) {
			// 終了画面
		}
	}

	void OnGUI() {
    GUI.Label (new Rect (0, 0, 100, 30), now.ToString());
    GUI.Label (new Rect (300, 0, 100, 30), Player.life.ToString());
    }
}
