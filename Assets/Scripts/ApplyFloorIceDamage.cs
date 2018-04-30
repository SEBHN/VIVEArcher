using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApplyFloorIceDamage : MonoBehaviour {

    private Dictionary<GameObject, float> enemiesInArea = new Dictionary<GameObject, float>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestroy()
    {
        foreach (var enemy in enemiesInArea)
        {
            var navMeshAgent = enemy.Key.GetComponent<NavMeshAgent>();
            navMeshAgent.speed = enemy.Value;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
           
            var navMeshAgent = other.gameObject.GetComponent<NavMeshAgent>();
            enemiesInArea.Add(other.gameObject, navMeshAgent.speed);
            navMeshAgent.speed /= 1.5f;
        }
    }
}
