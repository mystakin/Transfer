using UnityEngine;
using System.Collections;

public class TileReference : MonoBehaviour {

	public Sprite[] blueWorld;
	public Sprite[] redWorld;
	public SpriteRenderer[] tileRends;
	public GameObject tileContainer;
	public Global.GameState tileState;

	void Awake(){
		tileContainer = GameObject.FindGameObjectWithTag("TileContainer");

		tileRends = tileContainer.GetComponentsInChildren<SpriteRenderer>();
		tileState = Global.curState;
	}

	void Update(){
		if( Global.curState == Global.GameState.BlueChar || Global.curState == Global.GameState.RedChar ){
			if( tileState != Global.curState ){
				tileState = Global.curState;

				if( tileState == Global.GameState.BlueChar )
					ChangeTilesToRed( tileRends );
				else if( tileState == Global.GameState.RedChar )
					ChangeTilesToBlue( tileRends );
			}
		}
	}

	public void ChangeTilesToRed( SpriteRenderer[] rends ){
		for ( int i = 0; i < rends.Length; i++ ){
			int spriteIndex = 0;
			bool success = false;

			for( int j = 0; j < blueWorld.Length; j++ ){
				if( rends[i].sprite == blueWorld[j] ){
					spriteIndex = j;
					success = true;
					break;
				}
			}
			if( success )
				rends[i].sprite = redWorld[spriteIndex];
		}
	}

	public void ChangeTilesToBlue( SpriteRenderer[] rends ){
		for ( int i = 0; i < rends.Length; i++ ){
			int spriteIndex = 0;
			bool success = false;
			
			for( int j = 0; j < redWorld.Length; j++ ){
				if( rends[i].sprite == redWorld[j] ){
					spriteIndex = j;
					success = true;
					break;
				}
			}
			if( success )
				rends[i].sprite = blueWorld[spriteIndex];
		}
	}
}
