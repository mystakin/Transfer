using UnityEngine;
using System.Collections;

public class Terminate : MonoBehaviour {

	public float counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Escape) ){
			Application.Quit();
		}

		if( Application.loadedLevelName == "Level3" ){
			counter += Time.deltaTime;
			Debug.Log (counter);
		}

		if( counter > 10 ){
			Application.Quit();
		}
	}
}
