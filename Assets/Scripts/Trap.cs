using UnityEngine;

/// <summary>
/// It's a trap!
/// </summary>
public abstract class Trap : MonoBehaviour
{
    public float duration;
    public float cooldown;
    public Material activeMaterial;
    public Material inactiveMaterial;

    private void OnTriggerEnter(Collider other)
    {
        TrapTriggered(other.gameObject);
    }

    abstract public void TrapTriggered(GameObject enemy);
}