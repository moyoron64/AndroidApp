using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {
	
	public int jumpForce = 1;
	
	private bool jump = false;
	private bool isGrounded  = true ;
	float lastZ;

	void Start(){
				this.lastZ = 0;
		}


	public Rigidbody2D cRigidbody2D
	{
		get
		{
			if(!_cRigidbody2D)
				_cRigidbody2D = rigidbody2D;
			return _cRigidbody2D;
		}
	}
	Rigidbody2D _cRigidbody2D;
	
	public float moveSpeed = 5;

	void FixedUpdate()
	{
		Move();
		Jump();

		float g = Input.acceleration.magnitude - 1.0f;
		lastZ = (lastZ + g) * 0.9f;


		
		/*if (Input.acceleration.x > 0.5f || Input.acceleration.x < 0.3f )
						return;*/

		
		if ( lastZ > 0.7f && jump == false) {
						jump = true;
						Debug.Log("spaceon");
		} 
		/*if (jump == true) {
			cRigidbody2D.velocity = new Vector2(1000000,
			                                    100000000000000);
		
		}*/



	}


	void Jump()
	{
		if(jump == true &&  isGrounded)
		{
			rigidbody2D.AddForce(Vector2.up * 600f);
			Debug.Log("spaceon");
			isGrounded=false;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "yuka")
			isGrounded = true;
			jump = false;
		Debug.Log("spaceonaaaaaaaaaaa");
	}






	void Move()
	{
			cRigidbody2D.velocity = new Vector2(moveSpeed * Input.acceleration.x,
		                                    cRigidbody2D.velocity.y);
		




	}
}