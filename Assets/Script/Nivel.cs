using UnityEngine;
using System.Collections;

public class Nivel : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Play") {
			Application.LoadLevel("3");
		}
	}
}
