using UnityEngine;
using System.Collections;

public class creaPaja : MonoBehaviour {

	public GameObject shot;
    	public Transform shotSpawn;
    	public float timerRespawn=15;
	float timer;
	
	// Use this for initialization
	void Start () {
		timer=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time-timer>=timerRespawn){
			Instantiate(shot, shotSpawn.position, Quaternion.identity);
			timer=Time.time;
		}
		
	}
}
