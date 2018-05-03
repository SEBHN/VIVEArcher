using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class ApplyFloorFireDamage : MonoBehaviour
{

    public int burnTime = 5;
    public bool burning = false;
    public int damage = 1;
    private GameObject fire;

    public void Start()
    {
        Destroy(this, burnTime);
        StartCoroutine(DamageEach(1.0f));
    }

    public void OnDestroy()
    {
        if (fire != null)
        {
            Destroy(fire);
        }
    }


    public void SetBurning(bool burn)
    {
        burning = burn;
        fire = Instantiate(PrefabProvider.instance.bigFirePrefab, transform);
    }

    IEnumerator DamageEach(float waitTime)
    {
        while (burning)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.GetComponent<EnemyAI>().ReduceHitPoints(damage);
        }
    }
}
