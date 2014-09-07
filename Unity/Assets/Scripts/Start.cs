using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {



	
	
		if (Input.touchCount == 1) {
	
			Touch touch = Input.GetTouch (0);

				
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(touch.position);
				Collider2D colition2d = Physics2D.OverlapPoint(tapPoint);
				
				if(colition2d) {
					RaycastHit2D hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
				if(hitObject.collider.gameObject.name =="START"){
					Application.LoadLevel("Scene1");
				}
				if(hitObject.collider.gameObject.name =="OPTION"){
					Application.LoadLevel("Option");
				}
				if(hitObject.collider.gameObject.name =="BACK"){
					Application.LoadLevel("Title");
				}
			}
		}

}
}

