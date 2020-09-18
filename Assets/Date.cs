using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Date : MonoBehaviour
{
	public GameObject DateObject;

    // Start is called before the first frame update
    void Start()
    {
    InvokeRepeating("UpdateTime", 0f, 10f);   
    }

    // Update is called once per frame
    void UpdateTime()
    {
    DateObject.GetComponent<TextMeshPro>().text = System.DateTime.Now.ToString("d");
    }
}
