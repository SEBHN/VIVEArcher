﻿using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections.Generic;
using UnityEngine;

public class HandRayCast : MonoBehaviour
{

    InteractionHand leftInteractionHand;
    Hand leapHand;
    Finger finger;

    // Use this for initialization
    void Start()
    {

        leftInteractionHand = GetComponent<InteractionHand>();
        leapHand = leftInteractionHand.leapHand;
        if (leapHand == null) Debug.LogError("No leap_hand founded");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        finger = leapHand.Fingers[1]; // just index finger
        if (Physics.Raycast(finger.TipPosition.ToVector3(), finger.Direction.ToVector3(), out hit, Mathf.Infinity) && hit.collider.tag == "Respawn")
        {
            hit.collider.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }
        Debug.DrawRay(finger.TipPosition.ToVector3(), finger.Direction.ToVector3(), Color.red, Time.deltaTime, true);
    }
}