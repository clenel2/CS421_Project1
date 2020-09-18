using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;

using System;
using System.Net;
using System.IO;
public class Wind : MonoBehaviour
{
	public GameObject WindText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateWind", 0f, 10f);

    }
    // API key from openweathermap.org
	private const string API_KEY = "ee3df36f04223adc674677fd6d1e35d5";

	// Query URL
	private const string url =
	    "http://api.openweathermap.org/data/2.5/weather?" +
  	 "q=Chicago&units=imperial&APPID=" + API_KEY;

    // Update is called once per frame
    void UpdateWind()
    {
        using (WebClient client = new WebClient()) 
       	{
    		try 
    		{
    			string weatherJson = client.DownloadString(url);

    			JToken obj = JObject.Parse(weatherJson).GetValue("wind");

    			string wind_string = obj["speed"].ToString();
    			//string wind_direction_string = obj["deg"].ToString();
    			
    			WindText.GetComponent<TextMeshPro>().text = wind_string + " mph";//\n" + wind_direction_string + "°";
    		}
    		catch (WebException ex) 
    		{
    			Debug.Log(ex.ToString());
    		}
    	}
    }
}
