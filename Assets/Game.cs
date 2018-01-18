using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game{
	public static string Char1;
	public static string Char2;
	private static float pauseTime = 12.0f;
	public enum Ending {
		None,
		PlayerOneWin,
		PlayerTwoWin
	}
	public static Ending end;
	public static StageInfo stage;

	public Game(){

		end = Ending.None;
	}

}



