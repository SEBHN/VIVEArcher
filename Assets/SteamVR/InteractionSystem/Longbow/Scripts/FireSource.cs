//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: This object can be set on fire
//
//=============================================================================

using UnityEngine;
using System.Collections;
using Assets.Scripts;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class FireSource : MonoBehaviour
	{
		public GameObject fireParticlePrefab;
		public bool startActive;
		private GameObject fireObject;
	    public FireSourceType type;

		public ParticleSystem customParticles;

		public bool isBurning;

		public float burnTime;
	    public float coolDownTime;
		public float ignitionDelay = 0;
		private float ignitionTime;
        private float coolDownStart;
        private Hand hand;

		public AudioSource ignitionSound;

		public bool canSpreadFromThisSource = true;

		//-------------------------------------------------
		void Start()
		{
			if ( startActive )
			{
				StartBurning();
			}
		}


		//-------------------------------------------------
		void Update()
		{
			if ( ( burnTime != 0 ) && ( Time.time > ( ignitionTime + burnTime ) ) && isBurning )
			{
			    StopBurning();
			}

		    if (coolDownTime != 0 && !canSpreadFromThisSource &&  Time.time > (coolDownStart + coolDownTime))
		    {
		        canSpreadFromThisSource = true;
                StartBurning();
		    }
		}

	    private void StopBurning()
	    {
	        isBurning = false;
	        if (customParticles != null)
	        {
	            customParticles.Stop();
	        }
	        else
	        {
	            Destroy(fireObject);
	        }
	    }


	    //-------------------------------------------------
		void OnTriggerEnter( Collider other )
		{
			if ( isBurning && canSpreadFromThisSource)
			{
                FireSource otherSource = other.GetComponent<FireSource>();

			    if (otherSource == null)
			    {
                    other.SendMessageUpwards("FireExposure", SendMessageOptions.DontRequireReceiver);
                    coolDownStart = Time.time;
			        canSpreadFromThisSource = false;
			        StopBurning();
			    }
                else if (this.type == otherSource.type)
			    {
			        other.SendMessageUpwards("FireExposure", SendMessageOptions.DontRequireReceiver);
			        coolDownStart = Time.time;
			        canSpreadFromThisSource = false;
                    StopBurning();
                }
                else if (this.type != otherSource.type)
                { 
                    if (otherSource.isBurning)
                    {
                        otherSource.StopBurning();
                    }
                }

            }
		}


		//-------------------------------------------------
		private void FireExposure()
		{
			if ( fireObject == null )
			{
				Invoke( "StartBurning", ignitionDelay );
			}

			if ( hand = GetComponentInParent<Hand>() )
			{
				hand.controller.TriggerHapticPulse( 1000 );
			}
		}


		//-------------------------------------------------
		private void StartBurning()
		{
			isBurning = true;
			ignitionTime = Time.time;

            // Play the fire ignition sound if there is one
            if ( ignitionSound != null )
			{
				ignitionSound.Play();
			}

			if ( customParticles != null )
			{
				customParticles.Play();
			}
			else
			{
				if ( fireParticlePrefab != null )
				{
					fireObject = Instantiate( fireParticlePrefab, transform.position, transform.rotation ) as GameObject;
					fireObject.transform.parent = transform;
				}
			}
		}
	}
}
