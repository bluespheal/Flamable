using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {

	public float startTime;
	private string currentTime;

	public float timerHit=0;

	public GameObject shot;
	public Transform shotSpawn;
	
	public bool vulnerable=false;

	public bool facingRight = true;

	Animator anim;

	public Rect timerRect;

	public float timeIncrease = 10;
	public bool timeElapsed = false;


	public bool walledL = false;
	public bool walledR = false;

	bool grounded = false;

	public Transform groundCheck;
	float groundRadius = 0.02f;
	public LayerMask whatIsGround;


	public Transform wallCheckL;
	public Transform wallCheckR;

	float wallRadius = 0.02f;
	public LayerMask whatIsWall;


	public float jumpforce = 700f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool ("Mediano", false);
		anim.SetBool ("Pequeno", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		anim.SetBool ("Ground", grounded);

		walledL = Physics2D.OverlapCircle(wallCheckL.position,wallRadius,whatIsWall);
		anim.SetBool ("Wall", walledL);

		walledR = Physics2D.OverlapCircle(wallCheckR.position,wallRadius,whatIsWall);
		anim.SetBool ("Wall", walledR);



    
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		

		if(move > 0 && !facingRight)
		         Flip ();
		else if (move < 0 && facingRight)
		                           Flip ();
		 

		                         
	}
	

	void Update(){

		if (startTime <= 0) {

			Application.LoadLevel("Main");
		}
		
		if(!vulnerable&&Time.time-timerHit>2.0F){
			vulnerable=true;
		}
		
		startTime -= Time.deltaTime;
		currentTime = string.Format("{0:0.0}",startTime);


		if (startTime == 66  )
		{
			anim.SetBool ("Mediano", false);
			anim.SetBool ("Pequeno", false);
			anim.SetBool ("Temporal", true);
			
			
		}

		if (startTime == 33  )
		{
			anim.SetBool ("Mediano", false);
			anim.SetBool ("Pequeno", false);
			anim.SetBool ("Temporal", true);
			
			
		}

		if (startTime >= 66  )
		{
			anim.SetBool ("Mediano", false);
			anim.SetBool ("Pequeno", false);
			anim.SetBool ("Temporal", false);

			
			
		}

		if (startTime <= 66 && startTime >= 33  )
		{
			anim.SetBool ("Mediano", true);
			anim.SetBool ("Pequeno", false);
			anim.SetBool ("Temporal", false);

			
		}

		if (startTime <= 33 )
		{
			anim.SetBool ("Mediano", false);
			anim.SetBool ("Pequeno", true);
			anim.SetBool ("Temporal", false);

		}


		if (startTime <= 0 )
		{
			startTime = 0;
			Application.LoadLevel("Main");
		}


        if (grounded && Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Ground", false);
            GetComponent<AudioSource>().Play();


            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce));
        }
		if (Input.GetKeyDown(KeyCode.X))
		{
			shoot();
			startTime -= 3;
		}
		
		
	}
	
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag=="enemigo"&&vulnerable){
			startTime-=10;
			timerHit=Time.time;
			vulnerable=false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-1), ForceMode2D.Impulse);
		}

		if (coll.gameObject.tag=="Agua"){

			Application.LoadLevel("Main");

		}
		if (coll.gameObject.tag=="disparoE"&&vulnerable){
			Destroy(coll.gameObject , 0.0f);
			startTime-=5;

		}
		if (coll.gameObject.tag=="Paja"){
			Destroy(coll.gameObject , 0.0f);
			startTime+=20;
			
		}
		
	}



	void shoot (){
		Instantiate(shot, shotSpawn.position, Quaternion.identity);
	}


	void Flip (){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
			transform.localScale = theScale;
		}


	void OnGUI()
	{
		GUI.Label (timerRect, currentTime);
	}

}