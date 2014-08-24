using UnityEngine;
using System.Collections;

public class SwitchActivate : MonoBehaviour {

	public bool orange;
	public bool purple;
	public bool played;
	public AudioClip blueSwitch;
	public AudioClip redSwitch;
	public AudioClip purpleSwitch;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D ( Collider2D col ) {
		if( orange ){
			if( col.tag == "RedChar" ){
				Global.orangeSwitch = true;
				AudioSource.PlayClipAtPoint( redSwitch, transform.position, 0.4f );
			}
		}
		else if( !purple ){
			if( col.tag == "BlueChar" ){
				Global.blueSwitch = true;
				AudioSource.PlayClipAtPoint( blueSwitch, transform.position, 0.3f );
			}
		}
		else{
			Global.purpleSwitch++;

			if( Global.purpleSwitch >= 2 && !played ){
				AudioSource.PlayClipAtPoint( purpleSwitch, transform.position, 0.3f );
				played = true;
			}
		}
	}

	void OnTriggerExit2D ( Collider2D col ){
		if( orange ){
			if( col.tag == "RedChar" )
				Global.orangeSwitch = false;
		}
		else if( !purple ){
			if( col.tag == "BlueChar" )
				Global.blueSwitch = false;
		}
		else{
			Global.purpleSwitch--;
		}
	}
}
