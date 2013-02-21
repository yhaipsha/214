using UnityEngine;
using System.Collections;

public class DecorateNextGame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void Initialization()
    {

    }

    public Transform transGamePanel;

    void OnClick()
    {
        //next level
        int currentLevel = PlayerPrefs.GetInt("NowPlay");
        int currentMode = PlayerPrefs.GetInt("NowMode");
        string lastlevelName = Globe.jsonLableNames[currentMode - 1] + currentLevel;
        print(currentLevel + ",lastLevelName = " + lastlevelName);

        PlayerPrefs.SetInt(lastlevelName, 3);
        PlayerPrefs.SetInt("NowPlay", currentLevel + 1);
        PlayerPrefs.Save();
        //		if (transGamePanel != null)
        //			transGamePanel.GetComponent<GamePlayLayer> ().initGameWindow (PlayerPrefs.GetInt ("NowPlay"));


        //		transGamePanel.GetComponent<TweenPosition>().Play(true);
        //		Globe.getPanelOfParent(transGamePanel,1,"Panel - GameWin").GetComponent<TweenPosition>().Reset();
    }
}
