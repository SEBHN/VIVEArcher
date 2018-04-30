using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApplyFloorIceDamage : MonoBehaviour {

    private float originalSpeed;

    public void ApplySlow(float slowFactor)
    {
        var navMeshAgent = GetComponent<NavMeshAgent>();
        originalSpeed = navMeshAgent.speed;
        navMeshAgent.speed /= slowFactor;
        Invoke("RemoveSlow", 5f);
    }

    private void RemoveSlow()
    {
        var navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = originalSpeed;
        Destroy(this);
    }
}
