using UnityEngine;
using System.Collections;

public class SeControle : MonoBehaviour {


	public float speed = 60.0f;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount == 1) {
			
			Touch touch = Input.GetTouch (0);
			
			
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(touch.position);
			Collider2D colition2d = Physics2D.OverlapPoint(tapPoint);
			
			if(colition2d) {
				RaycastHit2D hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
				if(hitObject.collider.gameObject.name =="SE"){
					if (Input.touchCount > 0 && 
					    Input.GetTouch(0).phase == TouchPhase.Moved) {
						
						
						Vector3 position = Input.GetTouch(0).position;
						
						Vector3 target = Camera.main.ScreenToWorldPoint(position);
						//gameObject.transform.position += (screenToWorldPointPosition - gameObject.transform.position)/speed;

					

						transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.x, transform.position.y), speed );


					}

				}

			}
		}



	}



}

