using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using obj1;
using UnityEngine.UI;

public class LoadResults : MonoBehaviour
{
    List<pnts> results;
    Text top5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://51.15.86.111:9090/api/puntuaciones/"));
        top5 = GameObject.Find("top").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;
            top5.text = "";


            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                JObject json = JObject.Parse(webRequest.downloadHandler.text);
                results = json["objects"].ToObject<List<pnts>>();
                for (int i = 0; i < results.Count; i++)
                {
                    top5.text = top5.text+"\n"+(i+1)+". "+results[0].info();
                }
            }
        }
    }
}
