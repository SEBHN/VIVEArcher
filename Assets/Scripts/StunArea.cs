using UnityEngine;
using UnityEngine.AI;

public class StunArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<NavMeshAgent>().speed = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<NavMeshAgent>().speed = 0;
        }
    }
}