using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableEnableBowMenu : MonoBehaviour {

    public UnityEvent ShowMenuAnimation;
    public UnityEvent DisableMenuAnimation;
    public GameObject BowMenu;
    private bool bowWasLeft;
    private bool bowWasRight;
    
	
	// Update is called once per frame
	void Update () {
        bool bowHorizontalLeft = transform.rotation.eulerAngles.z > 70 && transform.rotation.eulerAngles.z < 100;
        bool bowHorizontalRight = transform.rotation.eulerAngles.z > 250 && transform.rotation.eulerAngles.z < 280;

        if (bowHorizontalLeft || bowHorizontalRight)
        {   
            BowMenu.SetActive(true);          
            if (bowHorizontalRight && bowWasLeft)
            {
                // transform position
              //  BowMenu.transform.Rotate(0f, 0f, 180f); // rotate z 180°
               // BowMenu.transform.position = new Vector3(0, BowMenu.transform.position.y, BowMenu.transform.position.z);
            }
            else if(bowHorizontalLeft && bowWasRight)
            {
                // transform position
            }

            ShowMenuAnimation.Invoke();
            bowWasLeft = bowHorizontalLeft;
            bowWasRight = bowHorizontalRight;

        }
        else
        {             
            DisableMenuAnimation.Invoke();
            BowMenu.SetActive(false);
        }
	}
}
