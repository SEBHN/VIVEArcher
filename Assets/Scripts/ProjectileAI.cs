using UnityEngine;

public class ProjectileAI : MonoBehaviour
{
    public int damage;
    public float speed;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        if(damage <= 0)
        {
            damage = 1;
        }
        if(speed <= 0.0f)
        {
            speed = 30.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == target.name)
        {
            other.GetComponent<EnemyAI>().ReduceHitPoints(damage);
            Destroy(gameObject);
        }     
    }
}