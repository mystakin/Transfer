using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject blueChar;
	public GameObject redChar;
	public Global.GameState camState;
	public bool insideLoop;
	public SpriteRenderer sky;
	public Color skyBlue;
	public Color skyRed;
	public GameObject tileContainer;
	public GameObject fadeContainer;
	public GameObject spritePref;
	public TileReference tileRef;
	public SpriteRenderer[] fadeRends;

	// Use this for initialization
	void Start () {
		camState = Global.curState;
		tileContainer = GameObject.FindGameObjectWithTag("TileContainer");
		fadeContainer = GameObject.FindGameObjectWithTag("FadeContainer");
		tileRef = GameObject.FindGameObjectWithTag("DataController").GetComponent<TileReference>();

		redChar = GameObject.FindGameObjectWithTag("RedChar");
		blueChar = GameObject.FindGameObjectWithTag("BlueChar");

		Transform[] tiles = tileContainer.GetComponentsInChildren<Transform>();

		for ( int i = 0; i < tiles.Length; i++ ){
			if( tiles[i].GetComponent<SpriteRenderer>() != null ){
				GameObject newObj = (GameObject)Instantiate( spritePref );
				
				newObj.transform.position = tiles[i].transform.position;
				newObj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
				newObj.GetComponent<SpriteRenderer>().sprite = tiles[i].GetComponent<SpriteRenderer>().sprite;
				newObj.GetComponent<SpriteRenderer>().sortingLayerName = "Tile";
				newObj.transform.parent = fadeContainer.transform;
			}
		}

		fadeRends = fadeContainer.GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if( !insideLoop ){
			if( Global.curState == Global.GameState.Transfer )
				StartCoroutine( CamTransfer() );
			
			if( camState == Global.GameState.BlueChar ){
				Camera.main.transform.position = blueChar.transform.position;
			}
			else if( camState == Global.GameState.RedChar ){
				Camera.main.transform.position = redChar.transform.position;
			}
			
			CameraOffset();
		}
	}

	void CameraOffset(){
		Camera.main.transform.position = new Vector3( Camera.main.transform.position.x, 0f, -10 );
	}

	IEnumerator CamTransfer(){
		insideLoop = true;
		Vector3 oldPos = Camera.main.transform.position;
		Vector3 newPos = oldPos;
		Color oldColor = Color.white;
		Color newColor = Color.white;

		if( camState == Global.GameState.RedChar ){
			newPos = new Vector3( blueChar.transform.position.x, newPos.y, newPos.z );
			newColor = skyRed;
			oldColor = skyBlue;

			tileRef.ChangeTilesToRed( fadeRends );
		}
		else if( camState == Global.GameState.BlueChar ){
			newPos = new Vector3( redChar.transform.position.x, newPos.y, newPos.z );
			newColor = skyBlue;
			oldColor = skyRed;

			tileRef.ChangeTilesToBlue( fadeRends );
		}

		for ( float i = 0; i < 30; i++ ){
			Camera.main.transform.position = Vector3.Lerp( oldPos, newPos, (i / 30f) );
			sky.color = Color.Lerp( oldColor, newColor, (i / 30f) );

			for( int j = 0; j < fadeRends.Length; j++ ){
				fadeRends[j].color = Color.Lerp( new Color(1f,1f,1f,0f), new Color(1f,1f,1f,1f), (i / 30f) );
			}

			yield return new WaitForFixedUpdate();
		}

		if( camState == Global.GameState.RedChar ){
			Global.curState = Global.GameState.BlueChar;
		}
		else if( camState == Global.GameState.BlueChar ){
			Global.curState = Global.GameState.RedChar;
		}

		camState = Global.curState;
		insideLoop = false;

		for( int i = 0; i < fadeRends.Length; i++ ){
			fadeRends[i].color = new Color(1f,1f,1f,0f);
		}
	}
}
