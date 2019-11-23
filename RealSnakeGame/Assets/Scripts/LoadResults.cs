using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using obj1;
using UnityEngine.UI;
using System.Linq;

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
                IEnumerable<pnts> op = results.OrderByDescending(pnts => pnts.puntuacion);
                int top = 0;
                foreach (pnts ss in op)
                {
                    Debug.Log(ss.nombre + " - " + ss.puntuacion);
                    if (top<5) {
                        top5.text = top5.text + "\n" + (top + 1) + ". " + ss.puntuacion + " Puntos - " + ss.nombre;
                    }
                    top++;
                }
            }
        }
    }
}
