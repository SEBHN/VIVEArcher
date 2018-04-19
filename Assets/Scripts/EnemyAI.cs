using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int hitPoints;
    private float defaultSpeed;

    // Use this for initialization
    void Start()
    {
        defaultSpeed = GetComponent<NavMeshAgent>().speed;
        if (hitPoints <= 0)
        {
            hitPoints = 2;
        }
        GameObject targetObject = GameObject.FindGameObjectWithTag("Target");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReduceHitPoints(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ResetSpeed()
    {
        GetComponent<NavMeshAgent>().speed = defaultSpeed;
    }
}