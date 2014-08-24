using UnityEngine;
using System.Collections;

public class SceneSetup : MonoBehaviour {

	public SpriteRenderer fader;

	// Use this for initialization
	void Awake () {
		if( Application.loadedLevelName == "Level1" )
			Global.curState = Global.GameState.RedChar;
		else if( Application.loadedLevelName == "Level2" )
			Global.curState = Global.GameState.BlueChar;

		fader.color = new Color(1f,1f,1f,1f);

		StartCoroutine( FadeIn() );
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FadeIn(){
		for ( float i = 0; i < 30; i++ ){
			Color oldColor = new Color(1f,1f,1f,1f);
			Color newColor = new Color(1f,1f,1f,0f);

			fader.color = Color.Lerp( oldColor, newColor, (i / 30f) );
			
			yield return new WaitForFixedUpdate();
		}
	}
}
