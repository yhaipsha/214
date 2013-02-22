using UnityEngine;
using System.Collections.Generic;

public class GamePlayLayer : MonoBehaviour
{
    //定义委托，显示关卡和错误次数。	
    public delegate void showLevel(string levelname);
    public event showLevel EventShowLevel;

    private Transform goButtons = null;
    UILabel lbl = null;
    // Use this for initialization
    void Start()
    {
        //		Globe.sameSize = new System.Collections.Generic.Dictionary<string, int> ();
        //		createButtons ();
    }

    public void cleanButtons()
    {
        if (goButtons != null)
            for (int i = 0; i < goButtons.GetChildCount(); i++)
            {
                foreach (UIButtonTween item in goButtons.GetComponentsInChildren<UIButtonTween>())
                {
                    DestroyImmediate(item, true);
                }
                Destroy(goButtons.GetChild(i).gameObject, 1.0f);
            }
    }

    void OnLayer()
    {
        //当前关卡

        int currentLevel = PlayerPrefs.GetInt("NowPlay");
        print("current leve is " + currentLevel);
        initGameWindow(currentLevel);
        createButtons();

    }
    public void initGameWindow(int cLevel)
    {
        lbl = transform.FindChild("LabelTime").GetComponent<UILabel>();
        if (PlayerPrefs.GetInt("NowMode") == 1)
        {
            lbl.text = "3";
        }
        else
            lbl.text = "";

        lbl = transform.FindChild("LabelShow").GetComponent<UILabel>();
        lbl.text = PlayerPrefs.GetInt("NowMode") + "-" + (cLevel);


        //头图片个数
        int maxCard = Globe.askbox[cLevel-1].Length;

        Globe.box = new ArrayRandom(maxCard).NonRepeatArray(1, 16);
        Globe.cards = new List<string>();
        Globe.askatlases = new List<string>();

        for (int j = 0; j < maxCard; j++)
        {
            int __count = int.Parse(Globe.askbox[cLevel-1][j]);
            if (j == maxCard - 1)
            {
                Globe.findCount = __count;
            }
            string[] temp = new string[__count];
            for (int k = 0; k < temp.Length; k++)
            {
                temp[k] = "box" + Globe.box[j];
                //				print (temp [k]);
                Globe.cards.Add(temp[k]);
            }

            Globe.askatlases.Add("boxfind" + Globe.box[j]);
        }
        print("current level is " + cLevel + " from 1 ,and findCount = " + Globe.findCount);

        Transform transFruit = transform.FindChild("ExampleFruit");
        UISlicedSprite ssp = transFruit.GetComponent<UISlicedSprite>();
        ssp.spriteName = Globe.askatlases[Globe.askatlases.Count - 1];
        print("look for sprite =" + ssp.spriteName);

        string[] names = Globe.cards.ToArray();
        ArrayRandom.FillRandomArray(ref names);
        DecorateGamePlay(names);

        /*
        for (int i = 0; i < arrSp.Length; i++) {
            arrSp [i] = "box" + Globe.box [box1_1 [i]];		
			
            string boxfind = "boxfind" + Globe.box [box1_1 [i]];	
            if (Globe.sameSize.ContainsKey (boxfind)) {
                Globe.sameSize [boxfind]++;
            } else
                Globe.sameSize.Add (boxfind, 1);
        }
		
        foreach (KeyValuePair<string, int> kvp in Globe.sameSize) {
            print (kvp.Key + ":" + kvp.Value);
        }*/

    }
	
	void createButtons()
    {
        Transform transPause = transform.FindChild("PanelPause");
        transPause.localPosition = new Vector3(0f, -680f, -5f);
        goButtons = transPause.FindChild("Buttons");
        GameObject[] panels = Globe.getPanelObject(transform, new string[] { "Panel - Main", "Panel - Shop", "Panel - Level" });

        if (goButtons.GetChildCount() <= 0)
            addButtons(transPause, goButtons, panels);

    }

    /// <summary>
    /// 布置游戏界面
    /// </summary>
    /// <param name='names'>
    /// Names.
    /// </param>
    void DecorateGamePlay(string[] names)
    {
        string str = string.Empty;
        foreach (string item in names)
        {
            str += item + ",";
        }
        print(str.Substring(0, str.Length - 1) + " findName = " + Globe.askatlases[Globe.askatlases.Count - 1]);
        UIItemStorageTest ut = transform.FindChild("GameWindow").GetComponent<UIItemStorageTest>();
        ut.maxRows = 4;

        //		Globe.cards.Count
        if (PlayerPrefs.GetInt("NowPlay") <= 4)
        {
            ut.maxColumns = 3;
            ut.transform.localPosition = Globe.cardPanel1;
        }
        else if (PlayerPrefs.GetInt("NowPlay") > 4 && PlayerPrefs.GetInt("NowPlay") <= 12)
        {
            ut.maxColumns = 5;
            ut.transform.localPosition = Globe.cardPanel2;
        }
        else if (PlayerPrefs.GetInt("NowPlay") > 12)
        {
            ut.maxColumns = 6;
            ut.transform.localPosition = Globe.cardPanel3;
        }

        if (ut.transform.GetChildCount() == 0)
        {
            ut.createTemp(names);
        }
        else
        {
            ut.cleaner();
            ut.createTemp(names);
        }
		PlayerPrefs.SetInt("GameWindow",1);

        //		else if (PlayerPrefs.GetInt ("PanelGamePlay") == -1) {
        //			//中途退出
        //			print("exit from  ");
        //			//ut.cleaner();
        //			
        //			ut.maxRows = 4;
        //			ut.maxColumns = 3;
        //			
        //			ut.transform.localPosition = new Vector3 (-256f, 128f, -0.5f);
        //			ut.createTemp (names);
        //			PlayerPrefs.SetInt("PanelGamePlay",0);
        //			
        //		}


    }
    void addButtons(Transform transPause, Transform goButtons, GameObject[] panels)
    {
        string[] prefabs = new string[] { "BtnHome", "BtnShop", "BtnLevel", "BtnReplay", "BtnCancel" };
        GameObject[] gos = Globe.getPrefabButtons(prefabs);

        for (int i = 0; i < gos.Length; i++)
        {
            GameObject goh = (GameObject)Instantiate(gos[i]);
            goh.transform.parent = goButtons;
            goh.transform.localScale = new Vector3(1f, 1f, 0.0025f);
            goh.transform.localPosition = new Vector3(0f, 0f, 0f);
            goh.name = "p" + i + prefabs[i];
            if (i < 3)
                addUIButtonTween(goh, panels[i], gameObject);
        }

        UIGrid ug = goButtons.gameObject.AddComponent<UIGrid>();
        ug.arrangement = UIGrid.Arrangement.Horizontal;
        ug.cellWidth = 110;
        ug.cellHeight = 200;
        ug.sorted = true;
        ug.hideInactive = true;

        foreach (GamePauseAftermath item in transPause.GetComponentsInChildren<GamePauseAftermath>())
        {
            item.transLevelPanel = panels[2].transform;
            item.transPausePanel = transform.FindChild("PanelPause");
            switch (item.transform.name)
            {
                case "p2BtnLevel":
                    item.resetLevel = false;
                    item.resetPause = true;
                    item.resetPlay = false;
                    item.removeCard = true;
                    break;
                case "p3BtnReplay":
                    item.resetLevel = false;
                    item.resetPause = true;
                    item.resetPlay = true;
                    item.removeCard = false;
                    break;
                case "p4BtnCancel":
                    item.resetLevel = false;
                    item.resetPause = true;
                    item.resetPlay = false;
                    item.removeCard = false;
                    break;
            }
        }
    }

    void addUIButtonTween(GameObject obj3, GameObject targets, GameObject targetSelf)
    {
        UIButtonTween bt = null;

        if (obj3.GetComponent<UIButtonTween>() != null)
        {
            foreach (UIButtonTween item in obj3.GetComponents<UIButtonTween>())
            {
                DestroyImmediate(item, true);
            }
        }

        bt = obj3.AddComponent<UIButtonTween>();//obj3[i].GetComponent<UIButtonTween>();//
        bt.tweenTarget = targetSelf;
        bt.includeChildren = true;
        bt.resetOnPlay = false;
        bt.ifDisabledOnPlay = AnimationOrTween.EnableCondition.EnableThenPlay;
        bt.disableWhenFinished = AnimationOrTween.DisableCondition.DisableAfterForward;
        bt.trigger = AnimationOrTween.Trigger.OnClick;
        bt.playDirection = AnimationOrTween.Direction.Forward;

        bt = obj3.AddComponent<UIButtonTween>();//obj3[i].GetComponent<UIButtonTween>();//
        bt.tweenTarget = targets;
        bt.includeChildren = true;
        bt.resetOnPlay = false;
        bt.ifDisabledOnPlay = AnimationOrTween.EnableCondition.EnableThenPlay;
        bt.disableWhenFinished = AnimationOrTween.DisableCondition.DisableAfterReverse;
        bt.trigger = AnimationOrTween.Trigger.OnClick;
        bt.playDirection = AnimationOrTween.Direction.Forward;

    }
    /// <summary>
    /// 重置卡牌
    /// </summary>
    public void resetCards()
    {
        //清理卡牌
        removeCards();
        initGameWindow(PlayerPrefs.GetInt("NowPlay") - 1);
    }
    /// <summary>
    /// 清理卡牌
    /// </summary>
    public void removeCards()
    {
        //清理卡牌
        transform.FindChild("GameWindow").GetComponent<UIItemStorageTest>().cleaner();//PanelPause		
    }


}
