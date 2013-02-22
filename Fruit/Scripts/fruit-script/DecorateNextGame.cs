using UnityEngine;
using System.Collections;

public class DecorateNextGame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	public void Initialization ()
	{
		
	}

	public Transform transGamePanel;

	void OnClick ()
	{
		//next level
		int nextLevel = PlayerPrefs.GetInt ("NowPlay")+1;
		int currentMode = PlayerPrefs.GetInt ("NowMode") - 1;
		string lastlevelName = Globe.jsonLableNames [currentMode] + (nextLevel-1);
		print (nextLevel + ",lastLevelName = " + lastlevelName);
		
		PlayerPrefs.SetInt (lastlevelName, 3);
		PlayerPrefs.SetInt ("NowPlay", nextLevel);
		
//		if (transGamePanel != null)
//			transGamePanel.GetComponent<GamePlayLayer> ().initGameWindow (PlayerPrefs.GetInt ("NowPlay"));
		
		
//		transGamePanel.GetComponent<TweenPosition>().Play(true);
//		Globe.getPanelOfParent(transGamePanel,1,"Panel - GameWin").GetComponent<TweenPosition>().Reset();
	}
}
