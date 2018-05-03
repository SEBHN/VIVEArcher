using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class OnFire : MonoBehaviour
{

    public int burnTime = 5;
    public bool burning = false;
    public int damage = 1;
    private GameObject fire;

    public void Start()
    {
        Invoke("DisableBurning", burnTime);
        StartCoroutine(DamageEach(1.0f));
    }


    public void SetBurning(bool burn)
    {
        burning = burn;
        if (burning)
        {
            fire = Instantiate(PrefabProvider.instance.bigFirePrefab, transform);
        }else if (fire != null)
        {
            Destroy(fire);
            Destroy(this);
        }
    }

    private void DisableBurning()
    {
        SetBurning(false);
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
