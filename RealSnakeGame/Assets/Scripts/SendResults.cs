using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using obj1;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using System.IO;
using UnityEngine.SceneManagement;

public class SendResults : MonoBehaviour
{
    List<pnts> results;
    InputField nom;
    Text top5;
    int punts;
    private Text score_Text;

    void Start()
    {
        score_Text = GameObject.Find("Titulo").GetComponent<Text>();
        score_Text.text = "Score: "+GameplayController.scoreCount+" Points";
    }

    public void send()
    {
        //Importar aqui en "punts" el valor de los puntos optenidos en el juego
        punts = GameplayController.scoreCount;
        nom = GameObject.Find("nombre").GetComponent<InputField>();
        StartCoroutine(PostRequest("http://51.15.86.111:9090/api/puntuaciones/"));
        SceneManager.LoadScene("Resultados");
    }

    string PostRequest(string uri)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
        httpWebRequest.ContentType = "application/json; charset=utf-8";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{ \"nombre\" : \""+nom.text+"\", \"puntuacion\" : "+punts+" }";

            streamWriter.Write(json);
            streamWriter.Flush();
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var responseText = streamReader.ReadToEnd();
            Debug.Log(responseText);
            //bueno aqui peta por una vaina que ya mirare mas adelante, problemas de alberto del futuro <3
            return "croquetamagica";
        }
    }
}
