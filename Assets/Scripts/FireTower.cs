using UnityEngine;

public class FireTower : Tower
{
    public float cooldown;
    public GameObject[] fireAreas;

    private bool isActive;

    // Use this for initialization
    void Start()
    {
        if (fireAreas.Length <= 0)
        {
            gameObject.SetActive(false);
        }
        if (shootTime <= 0.0f)
        {
            shootTime = 2.0f;
        }
        if (cooldown <= 0.0f)
        {
            cooldown = 5.0f;
        }
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            // Set fire effect active
            //GetComponent<MeshRenderer>().material = activeMaterial;
            isActive = true;
            // Activate all trigger areas
            foreach (GameObject fireArea in fireAreas)
            {
                fireArea.SetActive(true);
            }
            // Start timer
            Invoke("DeactivateTower", shootTime);
        }
    }

    private void DeactivateTower()
    {
        // Deactivate fire effect
        //GetComponent<MeshRenderer>().material = inactiveMaterial;
        foreach (GameObject fireArea in fireAreas)
        {
            fireArea.SetActive(false);
        }
        Invoke("ResetTower", cooldown);
    }

    private void ResetTower()
    {
        isActive = false;
    }
}