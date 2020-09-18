using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;

using System;
using System.Net;
using System.IO;
public class Wind_Direction_text : MonoBehaviour
{
	public GameObject WindDirectionText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateWindDirection", 0f, 10f);

    }
    // API key from openweathermap.org
	private const string API_KEY = "ee3df36f04223adc674677fd6d1e35d5";

	// Query URL
	private const string url =
	    "http://api.openweathermap.org/data/2.5/weather?" +
  	 "q=Chicago&units=imperial&APPID=" + API_KEY;

    // Update is called once per frame
    void UpdateWindDirection()
    {
        using (WebClient client = new WebClient()) 
       	{
    		try 
    		{
    			string weatherJson = client.DownloadString(url);

    			JToken obj = JObject.Parse(weatherJson).GetValue("wind");

    			string wind_string = obj["deg"].ToString();
    			//string wind_direction_string = obj["deg"].ToString();
    			
                Debug.Log(wind_string);
                float wind_direction = float.Parse(wind_string);
                if(wind_direction <= 45 && wind_direction >= 315 )  // north
                    WindDirectionText.GetComponent<TextMeshPro>().text = "↑";
                else if(wind_direction > 45 && wind_direction < 145) // east
                    WindDirectionText.GetComponent<TextMeshPro>().text = "→";
                else if(wind_direction >= 145 && wind_direction <= 225) // south
                    WindDirectionText.GetComponent<TextMeshPro>().text = "↓";
                else if(wind_direction > 225 && wind_direction < 315) // west
                    WindDirectionText.GetComponent<TextMeshPro>().text = "←";
                else 
                    WindDirectionText.GetComponent<TextMeshPro>().text = "Error";
    		}
    		catch (WebException ex) 
    		{
    			Debug.Log(ex.ToString());
    		}
    	}
    }
}
