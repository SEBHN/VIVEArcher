using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyFloorFireDamage : MonoBehaviour {


    private List<GameObject> enemiesInArea = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyAI>().ReduceHitPoints(1);
        }
    }


}
