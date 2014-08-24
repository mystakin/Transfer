using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public GameObject redChar;
	public GameObject blueChar;

	public float speed;
	public float horizMove;
	public Vector2 frameMovement;
	public AudioClip transferAudio;

	// Use this for initialization
	void Awake () {
		redChar = GameObject.FindGameObjectWithTag("RedChar");
		blueChar = GameObject.FindGameObjectWithTag("BlueChar");

		Physics2D.IgnoreCollision( redChar.collider2D, blueChar.collider2D );
	}
	
	// Update is called once per frame
	void Update () {
		float inputHor = Input.GetAxisRaw( "Horizontal" );
		bool inputShift = Input.GetButtonDown( "Shift" );

		if( inputHor != 0 ){
			horizMove = inputHor * speed;
		}
		else{
			horizMove = 0;
		}

		if( inputShift ){
			if( Global.curState != Global.GameState.NoControl )
				Shift ();
		}

		if( Global.curState == Global.GameState.NoControl ){
			StopChar( redChar.rigidbody2D );
			StopChar( blueChar.rigidbody2D );
		}
	}

	void FixedUpdate(){
		if( Global.curState == Global.GameState.BlueChar ){
			MoveChar( blueChar.rigidbody2D );
		}
			
		else if( Global.curState == Global.GameState.RedChar ){
			MoveChar( redChar.rigidbody2D );
		}
	}

	void MoveChar( Rigidbody2D player ){
		player.velocity = new Vector2( horizMove, player.velocity.y );
	}

	void StopChar( Rigidbody2D nonPlayer ){
		nonPlayer.velocity = new Vector2( 0f, nonPlayer.velocity.y );
	}

	void Shift(){
		Global.curState = Global.GameState.Transfer;
		AudioSource.PlayClipAtPoint( transferAudio, transform.position, 0.3f );
		StopChar( redChar.rigidbody2D );
		StopChar( blueChar.rigidbody2D );
	}
}
