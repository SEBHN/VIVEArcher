using UnityEngine;

/// <summary>
/// A door to prevent enemies to pass
/// </summary>
public class Door : MonoBehaviour
{
    public int hitPoints;

    // Use this for initialization
    void Start()
    {
        if(hitPoints <= 0)
        {
            hitPoints = 25;
        }
    }

    public void DamageDoor(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}