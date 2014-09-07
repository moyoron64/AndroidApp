using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {
	/*----------------------
	  グラスのステータス
	----------------------*/
	public static int life = 3; // グラス残機
	public static int waterLife = 13; // グラス内の残量
	public int jumpForce = 1;
	private bool jump = false;
	private bool isGrounded  = true ;

	public static Vector3 startPosition;
	public static Vector3 startRotation;
	float lastZ;


	void Start(){
		this.lastZ = 0;
		startPosition = transform.localPosition;
		startRotation = transform.localEulerAngles;
	}

/*-----------------------------------------
  DEBUG
/*-----------------------------------------*/
 // 移動スピード
 /*
        public float speed = 5;

        void Update ()
        {
                // 右・左
                float x = Input.GetAxisRaw ("Horizontal");

                // 上・下
                float y = Input.GetAxisRaw ("Vertical");

                // 移動する向きを求める
                Vector2 direction = new Vector2 (x, y).normalized;

                // 移動する向きとスピードを代入する
                rigidbody2D.velocity = direction * speed;
        }
        */
/*-----------------------------------------
  DEBUG END
/*-----------------------------------------*/


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

		/*-----------------------
		  ゴール地点に関する終了判定
		------------------------*/
		float glassPosition = transform.localPosition.x;
		float goalPosition = GameObject.Find("goal").transform.localPosition.x;
		if (rigidbody2D.velocity.x < 0.1 && (glassPosition - goalPosition) < 0.6) {
			// 一時停止
			Time.timeScale = 0;
		}



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
	}






	void Move()
	{
			cRigidbody2D.velocity = new Vector2(moveSpeed * Input.acceleration.x,
                        cRigidbody2D.velocity.y);
	}
}