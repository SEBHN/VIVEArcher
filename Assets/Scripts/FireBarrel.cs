using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarrel : MonoBehaviour
{

    public GameObject fireArePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            GameObject fireFloor = Instantiate(fireArePrefab, transform.position - new Vector3(0, transform.position.y, 0) + new Vector3(0, fireArePrefab.transform.position.y, 0), Quaternion.identity);
            Destroy(fireFloor, 10f);
            Destroy(gameObject);
        }
    }
}
