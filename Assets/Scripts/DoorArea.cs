using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A door to prevent enemies to pass
/// </summary>
public class DoorArea : MonoBehaviour
{
    public Door door;
    public float coolDown;
    private bool isActive;
    private List<GameObject> enemiesInArea = new List<GameObject>();

    // Use this for initialization
    private void Start()
    {
        if (coolDown <= 0.0f)
        {
            coolDown = 2.5f;
        }
        isActive = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(enemiesInArea.Count > 0)
        {
            if(!isActive)
            {
                CalculateDamage();
            }
        }
    }

    private void CalculateDamage()
    {
        isActive = true;
        int calculatedDamage = 0;
        foreach(GameObject enemy in enemiesInArea)
        {
            calculatedDamage += enemy.GetComponent<EnemyAI>().damage;
        }
        door.DamageDoor(calculatedDamage);
        Invoke("ResetArea", coolDown);
    }

    private void ResetArea()
    {
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInArea.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesInArea.Remove(other.gameObject);
        }
    }
}