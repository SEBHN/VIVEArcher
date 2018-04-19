using UnityEngine;

public class SlowdownTrap : Trap
{
    public GameObject slowdownArea;
    private bool isActive;
    
    public override void TrapTriggered(GameObject enemy)
    {
        if(!isActive)
        {
            GetComponent<MeshRenderer>().material = activeMaterial;
            isActive = true;
            // Activate second trigger area
            slowdownArea.SetActive(true);
            // Start timer
            Invoke("DeactivateTrap", duration);
        }
    }

    private void DeactivateTrap()
    {
        GetComponent<MeshRenderer>().material = inactiveMaterial;
        slowdownArea.SetActive(false);
        foreach(EnemyAI enemy in FindObjectsOfType<EnemyAI>())
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
            duration = 1.0f;
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