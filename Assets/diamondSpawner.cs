using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondSpawner : MonoBehaviour {
    [Header("Spawn Settings")]
    public GameObject resourcePrefab;
    public float spawnChance;
  

    [Header("Raycast Settings")]
    public float distanceBetweenCheck;
    public float heightOfCheck = 10f, rangeOfCheck = 30f;
    public LayerMask layerMask;
    public Vector2 positivePosition, negativePosition;

    private void Awake()
    {
        SpawnResources();
        Debug.Log("spawnerWorking");
    }
    private void Start()
    {
        
    }
    private float nextSpawnTime = 5f; // Assuming character lands at 5 seconds
 

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            
            SpawnResources();
            nextSpawnTime += 300f; // Schedule next spawn after 30 seconds
            Debug.Log("spawn");
        }
    }
    void SpawnResources()
    {
        for (float x = negativePosition.x; x < positivePosition.x; x += distanceBetweenCheck)
        {
            Debug.Log("spawn1");
            for (float z = negativePosition.y; z < positivePosition.y; z += distanceBetweenCheck)
            {
                Debug.Log("spawn2");
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(x, heightOfCheck, z), Vector3.down, out hit, rangeOfCheck, layerMask))
                {
                    Debug.Log("spawn3");
                    if (spawnChance > Random.Range(0, 101))
                    {
                        Instantiate(resourcePrefab, hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);
                        
                        Debug.Log("spawn4");

                    }
                }
            }
        }
    }
}

