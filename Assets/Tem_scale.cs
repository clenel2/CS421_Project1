using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

using System;
using System.Net;
using System.IO;

public class Tem_scale : MonoBehaviour
{
	public GameObject Tem_scaleObject;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTem_scale", 0f, 10f);
    }
    // API key from openweathermap.org
	private const string API_KEY = "ee3df36f04223adc674677fd6d1e35d5";

	// Query URL
	private const string url =
	    "http://api.openweathermap.org/data/2.5/weather?" +
  	 "q=Chicago&units=imperial&APPID=" + API_KEY;

    // Update is called once per frame
    void UpdateTem_scale()
    {
    	using (WebClient client = new WebClient()) 
       	{
    		try 
    		{
    			string weatherJson = client.DownloadString(url);

    			JToken obj = JObject.Parse(weatherJson).GetValue("main");

    			string tem_string = obj["temp"].ToString();
    			float x = (float)1.2;
    			float z = (float)1.2;
    			float y = float.Parse(tem_string)/100;

        		Tem_scaleObject.gameObject.transform.localScale = new Vector3(x,y,z);
        	}
        	catch (WebException ex) 
    		{
    			Debug.Log(ex.ToString());
    		}

    	}
    }
}
