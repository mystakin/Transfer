using UnityEngine;
using System.Collections;

public class ActiveUnitSprite : MonoBehaviour {

	public SpriteRenderer[] renders;
	public Sprite[] blueSprites;
	public Sprite[] redSprites;
	
	void Update(){
		if( Global.curState == Global.GameState.BlueChar ){
			if( renders[0].sprite != redSprites[0] ){
				renders[0].sprite = redSprites[0];
				renders[0].color = new Color(1, 1, 1, 0.5f);
			}
				

			if( renders[1].sprite != blueSprites[1] ){
				renders[1].sprite = blueSprites[1];
				renders[1].color = new Color(1, 1, 1, 1f);
			}
				
		}
		else if(  Global.curState == Global.GameState.RedChar ){
			if( renders[0].sprite != redSprites[1] ){
				renders[0].sprite = redSprites[1];
				renders[0].color = new Color(1, 1, 1, 1f);
			}
				
			
			if( renders[1].sprite != blueSprites[0] ){
				renders[1].sprite = blueSprites[0];
				renders[1].color = new Color(1, 1, 1, 0.5f);
			}
				
		}
		else{
			if( renders[0].sprite != redSprites[0] ){
				renders[0].sprite = redSprites[0];
				renders[0].color = new Color(1, 1, 1, 0.5f);
			}
			
			if( renders[1].sprite != blueSprites[0] ){
				renders[1].sprite = blueSprites[0];
				renders[1].color = new Color(1, 1, 1, 0.5f);
			}
		}
	}
}
