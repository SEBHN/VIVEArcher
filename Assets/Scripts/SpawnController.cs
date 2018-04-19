using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public float spawnTime;
    public int counterToBig;
    public GameObject smallEnemyPrefab;
    public GameObject bigEnemyPrefab;

    private bool spawnEnemy;
    private int currentCounter;

    // Use this for initialization
    void Start()
    {
        currentCounter = 0;
        if (spawnTime <= 0.0f)
        {
            spawnTime = 10.0f;
        }
        if(counterToBig <= 0)
        {
            counterToBig = 10;
        }
        spawnEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemy)
        {
            if(currentCounter >= counterToBig)
            {
                currentCounter = 0;
                Invoke("SpawnBigEnemy", spawnTime);
            }
            else
            {
                currentCounter++;
                Invoke("SpawnSmallEnemy", spawnTime);
            }
            spawnEnemy = false;
        }
    }

    private void SpawnSmallEnemy()
    {
        Instantiate(smallEnemyPrefab, transform.position, Quaternion.identity);
        spawnEnemy = true;
    }

    private void SpawnBigEnemy()
    {
        Instantiate(bigEnemyPrefab, transform.position, Quaternion.identity);
        spawnEnemy = true;
    }
}