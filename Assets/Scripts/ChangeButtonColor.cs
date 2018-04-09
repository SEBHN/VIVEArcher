using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeColorOfButton(Renderer renderer)
    {
        renderer.material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
    }
}
