using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Adds Score to database
    /// </summary>
    /// <param name="name"></param>
    /// <param name="id"></param>
    /// <param name="score"></param>
    /// <returns></returns>
    private IEnumerator AddScore(string name, string id, string score)
    {
        WWWForm f = new WWWForm();
        f.AddField("ScoreID", id);
        f.AddField("Name", name);
        f.AddField("Point", score);
        WWW w = new WWW("demo/theappguruz/score/add", f);
        yield return w;
        if (w.error == null)
        {
            JSONObject jsonObject = new JSONObject(w.text);
            string data = jsonObject.GetField("Status").str;
            if (data != null && data.Equals("Success"))
            {
                Debug.Log("Successfull");
            }
            else
            {
                Debug.Log("Fatel Error");
            }
        }
        else
        {
            Debug.Log("No Internet Or Other Network Issue" + w.error);
        }
    }

    /// <summary>
    /// Gets the score list form the database .
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetAllScoreList()
    {
        string url = "demo/theappguruz/score/get";
        WWW w = new WWW(url);
        yield return w;
        if (w.error == null)
        {
            JSONObject jsonObject = new JSONObject(w.text);
            for (int i = 0; i < jsonObject.GetField("ScorList").Count - 1; i++)
            {
                Debug.Log(jsonObject.GetField("ScorList")[i].GetField("Name").str + " : " + jsonObject.GetField("ScorList")[i].GetField("Point").str);
            }
        }
        else
        {
            Debug.Log("No Internet Or Other Network Issue : " + w.error);
        }
    }

}
