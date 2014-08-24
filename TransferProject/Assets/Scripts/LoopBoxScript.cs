using UnityEngine;
using System.Collections;

public class LoopBoxScript : MonoBehaviour {

	public GameObject blueBox;
	public GameObject redBox;
	public GameObject blueChar;
	public GameObject redChar;

	// Use this for initialization
	void Start () {
		redChar = GameObject.FindGameObjectWithTag("RedChar");
		blueChar = GameObject.FindGameObjectWithTag("BlueChar");
	}
	
	// Update is called once per frame
	void Update () {
		blueBox.transform.position = new Vector3( blueChar.transform.position.x, 
		                                         blueBox.transform.position.y,
		                                         blueBox.transform.position.z);

		redBox.transform.position = new Vector3( redChar.transform.position.x, 
		                                        redBox.transform.position.y,
		                                        redBox.transform.position.z);
	}
}
