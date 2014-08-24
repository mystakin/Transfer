using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	public enum GameState{
		NoControl,
		RedChar,
		BlueChar,
		Transfer,
	};

	public static GameState curState;
	public static bool orangeSwitch = false;
	public static bool blueSwitch = false;
	public static int purpleSwitch = 0;
}
