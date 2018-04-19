using UnityEngine;

public class ExplosionTrap : Trap
{
    public GameObject stunArea;
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
                stunArea.SetActive(true);
                // Start timer
                Invoke("DeactivateTrap", duration);
            }
        }
    }

    private void DeactivateTrap()
    {
        GetComponent<MeshRenderer>().material = inactiveMaterial;
        stunArea.SetActive(false);
        foreach (EnemyAI enemy in FindObjectsOfType<EnemyAI>())
        {
            enemy.ResetSpeed();
        }
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

    // Update is called once per frame
    void Update()
    {

    }
}