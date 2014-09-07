using UnityEngine;
using System.Collections;

public class DrinkMove : MonoBehaviour {

	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		//if (transform.position.x >= -0.5) {

			//transform.position.y = transform.position.x;

			transform.position = Vector2.MoveTowards(transform.position, new Vector2( transform.position.x, transform.position.x/20+1), speed );

		//}



	
	}
}
