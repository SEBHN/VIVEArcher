using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void logMessage(string message)
    {
        Debug.Log(message);
    }
}
