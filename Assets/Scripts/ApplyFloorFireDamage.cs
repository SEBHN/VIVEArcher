using System.Collections.Generic;
using UnityEngine;

public class ApplyFloorFireDamage : MonoBehaviour
{
    public void ApplyDamage(int damage)
    {
        gameObject.GetComponent<EnemyAI>().ReduceHitPoints(damage);
    }
}
