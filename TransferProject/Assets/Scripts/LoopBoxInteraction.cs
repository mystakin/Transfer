using UnityEngine;
using System.Collections;

public class LoopBoxInteraction : MonoBehaviour {

	public GameObject topBox;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D ( Collider2D col ) {
		if( col.tag == "LoopBox" ){
			transform.position = new Vector3( transform.position.x, 
			                                  topBox.transform.position.y,
			                                  transform.position.z);
		}
	}

	void Update(){
		if( rigidbody2D.velocity.y < -15 ){
			rigidbody2D.velocity = new Vector2( rigidbody2D.velocity.x, -15f);
		}
	}
}
