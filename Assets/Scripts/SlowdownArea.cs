using UnityEngine;
using UnityEngine.AI;

public class SlowdownArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<NavMeshAgent>().speed /= 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<NavMeshAgent>().speed *= 2;
        }
    }
}