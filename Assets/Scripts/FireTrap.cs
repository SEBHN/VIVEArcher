using UnityEngine;

public class FireTrap : Trap
{
    public GameObject fireArea;
    private bool isActive;

    public override void TrapTriggered(GameObject enemy)
    {
        if (!isActive)
        {
            if (enemy.tag == "Enemy")
            {
                GetComponent<MeshRenderer>().material = activeMaterial;
                isActive = true;
                // Activate second trigger area
                fireArea.SetActive(true);
                // Start timer
                Invoke("DeactivateTrap", duration);
            }
        }
    }

    private void DeactivateTrap()
    {
        GetComponent<MeshRenderer>().material = inactiveMaterial;
        fireArea.SetActive(false);
        Invoke("ResetTrap", cooldown);
    }

    private void ResetTrap()
    {
        isActive = false;
    }

    // Use this for initialization
    void Start()
    {
        isActive = false;
        if (duration <= 0.0f)
        {
            duration = 2.5f;
        }
        if (cooldown <= 0.0f)
        {
            cooldown = 5.0f;
        }
    }
}