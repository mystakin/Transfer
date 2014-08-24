using UnityEngine;
using System.Collections;

public class SwitchInteraction : MonoBehaviour {

	public GameObject redChar;
	public GameObject blueChar;
	public bool orange;
	public bool purple;
	public AudioClip purpleSwitch;

	// Use this for initialization
	void Start () {
		redChar = GameObject.FindGameObjectWithTag("RedChar");
		blueChar = GameObject.FindGameObjectWithTag("BlueChar");

		if( orange )
			Physics2D.IgnoreCollision( collider2D, redChar.collider2D );
		else if( !purple )
			Physics2D.IgnoreCollision( collider2D, blueChar.collider2D );
	}
	
	// Update is called once per frame
	void Update () {
		if( orange ){
			if( Global.orangeSwitch && Vector2.Distance( redChar.transform.position, transform.position ) < 7f  )
				TurnOff();
			else
				TurnOn();
		}
		else if( !purple ){
			if( Global.blueSwitch && Vector2.Distance( blueChar.transform.position, transform.position ) < 7f )
				TurnOff();
			else
				TurnOn();
		}
		else{
			if( Global.purpleSwitch >= 2 ){
				if( Vector2.Distance( blueChar.transform.position, transform.position ) < 10f || 
				   Vector2.Distance( redChar.transform.position, transform.position ) < 10f ){
					TurnOff();
				}
			}
		}
	}

	void TurnOff(){
		GetComponent<SpriteRenderer>().enabled = false;
		collider2D.enabled = false;
	}

	void TurnOn(){
		GetComponent<SpriteRenderer>().enabled = true;
		collider2D.enabled = true;
	}


}
