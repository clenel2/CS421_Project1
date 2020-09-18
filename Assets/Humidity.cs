using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;

using System;
using System.Net;
using System.IO;
public class Humidity : MonoBehaviour
{
	public GameObject HumidityObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTem", 0f, 10f);   
    }

	// API key from openweathermap.org
	private const string API_KEY = "ee3df36f04223adc674677fd6d1e35d5";

	// Query URL
	private const string url =
	    "http://api.openweathermap.org/data/2.5/weather?" +
  	 "q=Chicago&units=imperial&APPID=" + API_KEY;
	

    // Update is called once per frame
    void UpdateTem()
    {
    	using (WebClient client = new WebClient()) 
       	{
    		try 
    		{
    			string weatherJson = client.DownloadString(url);

    			JToken obj = JObject.Parse(weatherJson).GetValue("main");

    			string humid_string = obj["humidity"].ToString();
    			
    			HumidityObject.GetComponent<TextMeshPro>().text = humid_string + "%";
    		}
    		catch (WebException ex) 
    		{
    			Debug.Log(ex.ToString());
    		}
    	}

    }
}
