using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    public float fireCooldown;
    private List<GameObject> enemiesInArea = new List<GameObject>();
    private bool isActive;

    private void OnTriggerEnter(Collider other)
    {
        enemiesInArea.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        enemiesInArea.Remove(other.gameObject);
    }

    private void Start()
    {
        enemiesInArea.Clear();
        isActive = false;
        if (fireCooldown <= 0.0f)
        {
            fireCooldown = 2.0f;
        }
    }

    private void Update()
    {
        if (!isActive)
        {
            isActive = true;
            foreach(GameObject enemy in enemiesInArea)
            {
                if(enemy != null)
                {
                    enemy.GetComponent<EnemyAI>().ReduceHitPoints(1);
                }
            }
            Invoke("ReactivateFire", fireCooldown);
        }
    }

    private void ReactivateFire()
    {
        enemiesInArea.Clear();
        isActive = false;
    }
}