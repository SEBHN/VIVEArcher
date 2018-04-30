using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabProvider : MonoBehaviour
{

    public static PrefabProvider instance;

    public GameObject floorFirePrefab;
    public GameObject floorIcePrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
