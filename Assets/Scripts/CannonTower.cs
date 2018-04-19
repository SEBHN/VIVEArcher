using UnityEngine;

public class CannonTower : Tower
{
    public GameObject projectilePrefab;

    private bool readyToShoot;

    // Use this for initialization
    void Start()
    {
        if (shootTime <= 0.0f)
        {
            shootTime = 2.0f;
        }
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToShoot)
        {
            Invoke("ShootOnEnemy", shootTime);
            readyToShoot = false;
        }
    }

    private void ShootOnEnemy()
    {
        GameObject target = FindClosestEnemy();
        if(target != null)
        {
            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileObject.GetComponent<ProjectileAI>().target = target;
        }
        readyToShoot = true;
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
