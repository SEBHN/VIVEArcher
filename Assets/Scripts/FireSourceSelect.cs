using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class FireSourceSelect : MonoBehaviour
{

    public FireSource fire;
    public FireSource ice;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetActiveFireSource(FireSourceType type)
    {
        switch (type)
        {
            case FireSourceType.FIRE: 
                fire.gameObject.SetActive(true);
                fire.SendMessageUpwards("FireExposure", SendMessageOptions.DontRequireReceiver);
                ice.gameObject.SetActive(false);
                break;
            case FireSourceType.ICE:
                ice.gameObject.SetActive(true);
                ice.SendMessageUpwards("FireExposure", SendMessageOptions.DontRequireReceiver);
                fire.gameObject.SetActive(false);
                break;
        }
    }
}
