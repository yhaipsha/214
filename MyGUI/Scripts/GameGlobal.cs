using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace YeeTong.com
{
	public enum CheckBoxStatus
    {
		CkNOFAIL,
		CkEASY,
		CkMEDIUM,
		CkHARD,
		CkINSANE
		
		
		//"NO FAIL", "EASY", "MEDIUM", "HARD", "INSANE"
    }   
	
	
	public class GameGlobal : MonoBehaviour
	{	
		public static int someGlobal = 5;
		public static int difficulty = 1;

		public void Awake ()
		{
			Debug.Log(someGlobal+"|2");
		}
		
		

	}
}
