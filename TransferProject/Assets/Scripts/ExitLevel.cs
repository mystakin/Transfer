using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	public bool redReady;
	public bool blueReady;
	public SpriteRenderer fader;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D ( Collider2D col ) {
		if( col.tag == "RedChar" )
			redReady = true;

		if( col.tag == "BlueChar" )
			blueReady = true;
	}
	
	void OnTriggerExit2D ( Collider2D col ){
		if( col.tag == "RedChar" )
			redReady = false;
		
		if( col.tag == "BlueChar" )
			blueReady = false;
	}

	void Update(){
		if( Global.curState != Global.GameState.NoControl ){
			if( redReady && blueReady ){
				StartCoroutine( FadeOut() );
			}
		}
	}

	IEnumerator FadeOut(){
		Global.curState = Global.GameState.NoControl;

		for ( float i = 0; i < 30; i++ ){
			Color oldColor = new Color(1f,1f,1f,0f);
			Color newColor = new Color(1f,1f,1f,1f);
			
			fader.color = Color.Lerp( oldColor, newColor, (i / 30f) );
			
			yield return new WaitForFixedUpdate();
		}

		yield return new WaitForSeconds(1);

		Application.LoadLevel( Application.loadedLevel + 1 );
	}
}
