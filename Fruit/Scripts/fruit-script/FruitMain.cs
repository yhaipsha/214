using UnityEngine;
using System.Collections;
using LitJson;

public class FruitMain : MonoBehaviour
{

    IEnumerator Start()
    {
        WWW www = new WWW("file://" + Application.dataPath + @"/Fruit/Data/SystemData.assetbundle");
        yield return www;
        SystemData sd = www.assetBundle.mainAsset as SystemData;
        Globe.askbox = new System.Collections.Generic.List<string[]>();


        foreach (string item in sd.arrInt)
        {
            Globe.askbox.Add(item.Split(','));
        }
        print("loading all level = " + Globe.askbox.Count);
        //StartCoroutine ("GetTwitterUpdate");     


        ;
        //		LitJsonUtil.addNextLevel(3,0);
        //		print (LitJsonUtil.WriteJson());
        //		print (Application.dataPath + @"/StreamingAssets/json.txt");
        ;
    }

    IEnumerator GetTwitterUpdate()//IEnumerator
    {
        WWW www = new WWW(Globe.jsonURL);
        yield return www;

        /*
        float elapsedTime = 0.0f;
        while (!www.isDone) {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 10.0f)
                break;			
            yield return null;  
        } 
        if (!www.isDone || !string.IsNullOrEmpty (www.error)) {
            Debug.LogError (string.Format ("Fail Whale!\n{0}", www.error));
            yield break;
        }*/

        JsonData root = JsonMapper.ToObject(www.data);

        JsonData lf = root["level"];
        ICollection keyss = (lf as IDictionary).Keys;
        string[] array = new string[keyss.Count];
        keyss.CopyTo(array, 0);

        for (int i = 0; i < array.Length; i++)
        {
            if (lf[i].IsArray)
            {
                JsonData[] jarr = JsonMapper.ToObject<JsonData[]>(lf[i].ToJson());
                for (int j = 1; j <= jarr.Length; j++)
                {
                    PlayerPrefs.SetInt("star-" + array[i] + j, (int)jarr[j - 1]);
                    //					print (("star-" + array [i] + j) + "==" + (int)jarr [j-1]);
                }
            }
        }

        /*
        if(lf["star"].IsArray)
        {
            for (int i = 0; i < lf["star"].Count; i++) 
            {
                PlayerPrefs.SetInt("star-first"+i,(int)lf["star"][i]);
            }

        }*/
    }

    public static void WriteJson(string path)
    {
        WWW www = new WWW(Globe.jsonURL);

        JsonData root = JsonMapper.ToObject(www.data);

        JsonData lf = root["level"];//root["level"]["first"];
        JsonData dt = lf[0]["star"];
        dt.Add(3);
        print(lf[0]["star"].ToJson() + " ** " + dt.Count);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        JsonWriter writer = new JsonWriter(sb);
        writer.WriteArrayStart();
        writer.Write(1);
        writer.Write(2);
        writer.Write(3);
        writer.WriteObjectStart();
        writer.WritePropertyName("color");
        writer.Write("blue");
        writer.WriteObjectEnd();
        writer.WriteArrayEnd();


        print(sb.ToString());

        //输出：[1,2,3,{"color":"blue"}]
    }

}
