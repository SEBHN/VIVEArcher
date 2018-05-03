using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int hitPoints;
    public int damage;
    private float defaultSpeed;

    // Use this for initialization
    void Start()
    {
        defaultSpeed = GetComponent<NavMeshAgent>().speed;
        if (hitPoints <= 0)
        {
            hitPoints = 2;
        }
        if(damage <= 0)
        {
            damage = 1;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("FloorFire") || other.gameObject.tag == "Fire")
        {
            ApplyFloorFireDamage fireFloor = gameObject.GetComponent<ApplyFloorFireDamage>();
            if (fireFloor == null)
            {
                fireFloor = gameObject.AddComponent<ApplyFloorFireDamage>();
                fireFloor.SetBurning(true);
            }
        }
        else if (other.gameObject.name.StartsWith("FloorIce") || other.gameObject.tag == "Ice")
        {
            gameObject.AddComponent<ApplyFloorIceDamage>().ApplySlow(1.7f);
        }
    }
}