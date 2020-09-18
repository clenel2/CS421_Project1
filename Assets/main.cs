using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;

using System;
using System.Net;
using System.IO;
public class main : MonoBehaviour
{
	public GameObject mainText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateMain", 0f, 10f);
    }
     // API key from openweathermap.org
	private const string API_KEY = "ee3df36f04223adc674677fd6d1e35d5";

	// Query URL
	private const string url =
	    "http://api.openweathermap.org/data/2.5/weather?" +
  	 "q=Chicago&units=imperial&APPID=" + API_KEY;

    // Update is called once per frame
    void UpdateMain()
    {
        using (WebClient client = new WebClient()) 
       	{
    		try 
    		{
    			string weatherJson = client.DownloadString(url);

    			JToken obj = JObject.Parse(weatherJson).GetValue("main");

    			//string tem_string = obj["temp"].ToString();
    			//string humdid_string = obj["humidity"].ToString();
    			
    			mainText.GetComponent<TextMeshPro>().text = obj.ToString();
    		}
    		catch (WebException ex) 
    		{
    			Debug.Log(ex.ToString());
    		}
    	}
    }
}
