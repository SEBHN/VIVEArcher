using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableBowMenu : MonoBehaviour {

    public GameObject menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.rotation.eulerAngles.z > 90)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
	}
}
