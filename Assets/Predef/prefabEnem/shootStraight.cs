using UnityEngine;
using System.Collections;
using System;

public class shootStraight : MonoBehaviour {

    public Rigidbody2D rb2D;
    Vector2 velProy=new Vector2(-3,0);

    float timer;
    
    public Transform ownPos;
    public GameObject player1;
	// Use this for initialization
	void Start () {
        ownPos=GetComponent<Transform>();
        player1=GameObject.FindGameObjectsWithTag("Play")[0];
        
        velProy=new Vector2(3*(player1.transform.position.x-ownPos.position.x)/Math.Abs(player1.transform.position.x-ownPos.position.x),0);
        
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(velProy, ForceMode2D.Impulse);
        timer=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        	if(Time.time-timer>1)
			Destroy(gameObject,0.0f);
	}
	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Plataforma") {
			Destroy (gameObject, 0.0f);
		}
	}
}
